using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sutoss.Domain.Services.Domain.Filters.Base
{
    public class Operand
    {
        public string Property { get; set; }
        public EqualityComparer? Comparer { get; set; }
        public string Value { get; set; }
        public DataType? Type { get; set; }
        public Expression Expression { get; set; }

        public string GetStringValue()
        {
            if (Expression != null)
            {
                return Expression.GetStringValue();
            }
            else
            {
                return BuildOperandString(Property, Comparer, Value, Type);
            }
        }

        private string BuildOperandString(string property, EqualityComparer? equalityComparer, string value, DataType? dataType)
        {
            switch (equalityComparer.Value)
            {
                case EqualityComparer.Eq: return $"{property} == {GetFormattedValue(value,dataType)}";
                case EqualityComparer.Gt: return $"{property} > {GetFormattedValue(value,dataType)}";
                case EqualityComparer.Gte: return $"{property} >= {GetFormattedValue(value,dataType)}";
                case EqualityComparer.Lt: return $"{property} < {GetFormattedValue(value,dataType)}";
                case EqualityComparer.Lte: return $"{property} <= {GetFormattedValue(value,dataType)}";
                case EqualityComparer.Ne: return $"{property} != {GetFormattedValue(value,dataType)}";
                case EqualityComparer.Like: return $"{property}.ToUpper().Contains({GetFormattedValue(value,dataType)})";
                default: return "";
            }
        }

        private string GetFormattedValue(string value, DataType? dataType)
        {
            switch (dataType)
            {
                case DataType.Integer: return value;
                case DataType.FloatingPoint: return value;
                case DataType.Text: return $"\"{value}\"";
                default: return $"\"{value}\"";
            }
        }
    }

    public enum EqualityComparer
    {
        Eq,
        Gt,
        Lt,
        Gte,
        Lte,
        Ne,
        Like
    }

    public enum DataType
    {
        Integer,
        FloatingPoint,
        Text
    }
}
