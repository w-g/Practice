using App.Repository.Models;
using NPoco;
using Org.Library;
using System;
using System.Linq;
using System.Data.SqlClient;
using System.Reflection;

namespace App.Repository
{
    public class NPocoRepository<T> : IRepository<T>
    {
        private IDatabase _db;

        public NPocoRepository()
        {
            
        }

        public void Insert(T entity)
        {
            var connection = new SqlConnection("server=192.168.1.200\\MSSQL2012;database=CustomizableEntity;uid=sa;pwd=123123");
            _db = new Database(connection);

            try
            {
                connection.Open();

                _db.BeginTransaction();

                _db.Insert(entity);

                var customizableEntity = entity as CustomizableEntity;
                if (customizableEntity != null)
                {
                    var customizableProperties = customizableEntity.Properties;
                    if (customizableProperties != null)
                    {
                        foreach (var property in customizableProperties)
                        {
                            var column = GetOrCreateColumn(GetTableName(), property.Name);

                            var columnValue = new ExtendedColumnValue
                            {
                                ColumnId = column.Id,
                                ColumnValue = property.Value,
                                IdentityValue = GetIdentityValue(entity)
                            };

                            _db.Insert(columnValue);
                        }
                    }
                }
            }
            catch (Exception ecp)
            {
                _db.AbortTransaction();
            }
            finally
            {
                _db.CompleteTransaction();
                _db.Dispose();

                connection.Dispose();
            }
        }

        public void Delete(T entity)
        {
            var connection = new SqlConnection("server=192.168.1.200\\MSSQL2012;database=CustomizableEntity;uid=sa;pwd=123123");
            _db = new Database(connection);

            try
            {
                connection.Open();
                _db.BeginTransaction();

                _db.Delete(entity);

                var customizableEntity = entity as CustomizableEntity;
                if (customizableEntity != null)
                {
                    var sql = Sql.Builder
                            .Append(@"DELETE FROM ExtendedColumnValue
	                                WHERE IdentityValue = @0
		                                AND ColumnId IN (
			                                SELECT ID
				                                FROM ExtendedColumn
				                                WHERE TableName = @1)", GetIdentityValue(entity), GetTableName());

                    _db.Execute(sql);
                }
            }
            catch
            {
                _db.AbortTransaction();
            }
            finally
            {
                _db.CompleteTransaction();
                _db.Dispose();

                connection.Dispose();
            }
        }

        public void Update(T entity)
        {
            var connection = new SqlConnection("server=192.168.1.200\\MSSQL2012;database=CustomizableEntity;uid=sa;pwd=123123");
            _db = new Database(connection);

            try
            {
                connection.Open();

                _db.BeginTransaction();

                _db.Update(entity);

                var customizableEntity = entity as CustomizableEntity;
                if (customizableEntity != null)
                {
                    var customizableProperties = customizableEntity.Properties;
                    if (customizableProperties != null)
                    {
                        foreach (var property in customizableProperties)
                        {
                            var sql = Sql.Builder
                                .Append(@"UPDATE EXTENDEDCOLUMNVALUE
	                                        SET COLUMNVALUE = @0
	                                        WHERE IDENTITYVALUE = @1
		                                        AND COLUMNID = (
			                                        SELECT ID 
				                                        FROM EXTENDEDCOLUMN
				                                        WHERE TABLENAME = @2
					                                        AND COLUMNNAME = @3)", property.Value, GetIdentityValue(entity), GetTableName(), property.Name);

                            _db.Execute(sql);
                        }
                    }
                }
            }
            catch (Exception ecp)
            {
                _db.AbortTransaction();
            }
            finally
            {
                _db.CompleteTransaction();
                _db.Dispose();

                connection.Dispose();
            }
        }

        public T Get(object identity)
        {
            var connection = new SqlConnection("server=192.168.1.200\\MSSQL2012;database=CustomizableEntity;uid=sa;pwd=123123");
            _db = new Database(connection);


            T entity = default(T);

            try
            {
                connection.Open();

                entity = _db.SingleOrDefaultById<T>(identity);

                var customizableEntity = entity as CustomizableEntity;
                if (customizableEntity != null)
                {
                    var sql = Sql.Builder
                        .Append(@"SELECT DEF.ColumnName AS Name, DEF.ColumnName AS Label, VAL.ColumnValue As Value
                                     FROM ExtendedColumnValue VAL
                                      INNER JOIN ExtendedColumn DEF
                                       ON VAL.ColumnId = DEF.Id
                                     WHERE DEF.TableName = @0
                                      AND VAL.IdentityValue = @1", GetTableName(), identity);

                    var properties = _db.Fetch<CustomizableEntityProperty>(sql);

                    customizableEntity.Properties = properties;
                }
            }
            catch (Exception ecp)
            {
            }
            finally
            {
                _db.Dispose();
                connection.Dispose();
            }

            return entity;
        }

        private ExtendedColumn GetOrCreateColumn(string tableName, string columnName)
        {
            var sql = Sql.Builder
                .Select("Top 1 *")
                .From("ExtendedColumn")
                .Where(@"TableName = @0
                    AND ColumnName = @1", tableName, columnName);

            var column = _db.FirstOrDefault<ExtendedColumn>(sql);

            if (column == null)
            {
                column = new ExtendedColumn
                {
                    TableName = tableName,
                    ColumnName = columnName
                };

                column.ColumnLabel = column.ColumnName;

                _db.Insert(column);
            }

            return column;
        }

        private string GetTableName()
        {
            return typeof(T)
                .GetTypeInfo()
                .GetCustomAttribute<TableNameAttribute>()
                .Value;
        }

        private string GetIdentityValue(object obj)
        {
            var type = typeof(T);

            var primaryKey = type
                .GetTypeInfo()
                .GetCustomAttribute<PrimaryKeyAttribute>()
                .Value;

            var identity = type
                .GetMembers()
                .FirstOrDefault(m => m.GetCustomAttribute<ColumnAttribute>()?.Name == primaryKey);

            return type.GetProperty(identity.Name).GetValue(obj).ToString();
        }
    }
}
