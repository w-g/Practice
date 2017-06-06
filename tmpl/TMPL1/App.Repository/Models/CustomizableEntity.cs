using NPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Repository.Models
{
    // 可自定义属性的Entity基类
    public abstract class CustomizableEntity
    {
        [Ignore]
        private IList<CustomizableEntityProperty> _properties;

        //protected abstract string TableName { get; }

        //protected abstract object IdentityValue { get; }

        [Ignore]
        public string this[string name]
        {
            get
            {
                return Properties?.FirstOrDefault(p => p.Name == name)?.Value;
            }

            set
            {
                var property = Properties?.FirstOrDefault(p => p.Name == name);
                if (property != null)
                {
                    property.Value = value;
                }
                else
                {
                    property = new CustomizableEntityProperty
                    {
                        Name = name,
                        Value = value
                    };
                }

                if (_properties == null)
                {
                    _properties = new List<CustomizableEntityProperty>();
                }

                _properties.Add(property);
            }
        }

        [Ignore]
        public IEnumerable<CustomizableEntityProperty> Properties
        {
            get
            {
                if (_properties == null)
                {
                    // 根据TableName和IdentityValue从数据库查询此实体的所有自定义属性

                    //var sql = Sql.Builder
                    //    .Append(@"SELECT DEF.ColumnName AS Name, DEF.ColumnName AS Label, VAL.ColumnValue As Value
	                   //             FROM ExtendedColumnValue VAL
		                  //              INNER JOIN ExtendedColumn DEF
			                 //               ON VAL.ColumnId = DEF.Id
	                   //             WHERE DEF.TableName = @0
		                  //              AND VAL.IdentityValue = @1", );


                }

                return _properties;
            }

            set
            {
                _properties = value?.ToList();
            }
        }
    }

    // 自定义属性
    public class CustomizableEntityProperty
    {
        public string Name { get; set; }

        public string Label { get; set; }

        // public CustomizableEntityPropertyType Type { get; set; }

        public string Value { get; set; }
    }

    // 数据库实体
    [TableName("ExtendedColumn")]
    [PrimaryKey("Id")]
    public class ExtendedColumn
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("TableName")]
        public string TableName { get; set; }

        [Column("ColumnName")]
        public string ColumnName { get; set; }

        [Column("ColumnLabel")]
        public string ColumnLabel { get; set; }
    }

    [TableName("ExtendedColumnValue")]
    [PrimaryKey("Id")]
    public class ExtendedColumnValue
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("ColumnId")]
        public int ColumnId { get; set; }

        [Column("IdentityValue")]
        public string IdentityValue { get; set; }

        [Column("ColumnValue")]
        public string ColumnValue { get; set; }
    }

    //public abstract class CustomizableEntityPropertyType
    //{
    //    // 数据类型的完全限定名
    //    public string Type { get; set; }

    //    public int Length { get; set; }
    //}
}
