using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Filters.Base
{
    public class Expression
    {
        public LogicalOperator Operation { get; set; }
        public List<Operand> OperandList { get; set; }
        public bool All { get; set; }

        public string GetStringValue()
        {
            if (OperandList == null)
            {
                return "";
            }

            if (OperandList.Count == 1)
            {
                return OperandList[0].GetStringValue();
            }

            string result = "";
            for(int i = 0; i < OperandList.Count; i++)
            {
                if (i != 0)
                {
                    result = OperandList[i].GetStringValue() + LogicalOperatorEnumToString(Operation) + result;
                }
                else
                {
                    result = OperandList[i].GetStringValue();
                }
                
            }

            return result;
        }

        private string LogicalOperatorEnumToString(LogicalOperator logicalOperator)
        {
            return (logicalOperator == LogicalOperator.And) ? " && " : " || ";
        }
    }

    public enum LogicalOperator
    {
        And,
        Or
    }
}
