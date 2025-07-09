using System.Linq;

namespace SmartBuilder_POC.Models
{
    public class WhereCondition
    {
        public string Field { get; set; }
        public string Operator { get; set; }
        public string Value { get; set; }

        public override string ToString()
        {
            if (Operator.ToUpper() == "LIKE")
                return string.Format("{0} {1} '%{2}%'", Field, Operator, Value);
            else if (Value.All(char.IsDigit))
                return string.Format("{0} {1} {2}", Field, Operator, Value);
            else
                return string.Format("{0} {1} '{2}'", Field, Operator, Value);
        }
    }
}
