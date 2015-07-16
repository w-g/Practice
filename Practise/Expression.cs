using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Sediment.Practise
{
    class Person
    {
        public string Name { get; set; }

        public short Age { get; set; }
    }

    class Program
    {
        static void DisplayTree(int indent, string message, Expression expression)
        {
            string output = string.Format("{0} {1} ! NodeType: {2}; Expression: {3};",
                "".PadLeft(indent, '>'), message, expression.NodeType, expression);

            indent++;
            switch (expression.NodeType)
            {
                case ExpressionType.Lambda:
                    Console.WriteLine(output);
                    var lambdaExpr = expression as LambdaExpression;
                    foreach (var parameter in lambdaExpr.Parameters)
                    {
                        DisplayTree(indent, "Parameter", parameter);
                    }
                    DisplayTree(indent, "Body", lambdaExpr.Body);
                    break;

                case ExpressionType.Parameter:
                    var paramExpr = expression as ParameterExpression;
                    Console.WriteLine("{0} Param Type: {1}", output, paramExpr.Type.Name);
                    break;

                case ExpressionType.Constant:
                    var constExpr = expression as ConstantExpression;
                    Console.WriteLine("{0} Const Value: {1}", output, constExpr.Value);
                    break;

                // 适用于所有的二目运算符（Binary Operator）
                case ExpressionType.Equal:
                case ExpressionType.NotEqual:
                case ExpressionType.GreaterThan:
                case ExpressionType.LessThan:
                case ExpressionType.AndAlso:
                case ExpressionType.OrElse:
                    var binExpr = expression as BinaryExpression;
                    if (binExpr.Method != null)
                    {
                        Console.WriteLine("{0} Method: {1}", output, binExpr.Method.Name);
                    }
                    else
                    {
                        Console.WriteLine(output);
                    }
                    DisplayTree(indent, "Binary", binExpr.Left);
                    DisplayTree(indent, "Binary", binExpr.Right);
                    break;

                case ExpressionType.MemberAccess:
                    var memExpr = expression as MemberExpression;
                    Console.WriteLine("{0} MemberName: {1}; Type: {2};",
                        output, memExpr.Member.Name, memExpr.Type.Name);
                    DisplayTree(indent, "Member", memExpr.Expression);
                    break;

                default:
                    Console.WriteLine();
                    Console.WriteLine("{0} {1}", expression.NodeType, expression.Type.Name);
                    break;
            }
        }

        static void Main(string[] args)
        {
            Func<Person, bool> func = x => x.Age > 21;
            Expression<Func<Person, bool>> expression = x => (long)x.Age >= 21 || x.Name == "王志斌";

            DisplayTree(0, "Lambda", expression);

            Console.ReadKey();
        }
    }
}
