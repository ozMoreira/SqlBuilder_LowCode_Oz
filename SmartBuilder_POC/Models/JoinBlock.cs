namespace SmartBuilder_POC.Models
{
    public enum JoinType { Inner, Left, Right, Full }
    public class JoinBlock : SqlBlock
    {
        public JoinType Type { get; set; }
        public string LeftTable { get; set; }
        public string LeftColumn { get; set; }
        public string RightTable { get; set; }
        public string RightColumn { get; set; }

        public override string ToSql()
        {
            string joinKeyword;

            switch (Type)
            {
                case JoinType.Inner:
                    joinKeyword = "INNER JOIN";
                    break;
                case JoinType.Left:
                    joinKeyword = "LEFT JOIN";
                    break;
                case JoinType.Right:
                    joinKeyword = "RIGHT JOIN";
                    break;
                case JoinType.Full:
                    joinKeyword = "FULL JOIN";
                    break;
                default:
                    joinKeyword = "JOIN";
                    break;
            }

            return $"{joinKeyword} {RightTable} ON {LeftTable}.{LeftColumn} = {RightTable}.{RightColumn}";
        }
    }
}
