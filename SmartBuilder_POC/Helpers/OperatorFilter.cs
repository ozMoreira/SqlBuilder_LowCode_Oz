namespace SmartBuilder_POC.Helpers
{
    internal class OperatorFilter
    {
        public string Description { get; set; }   // Ex: = (Igual)
        public string SqlOperator { get; set; } // Ex: =

        public OperatorFilter(string description, string sqlOperator)
        {
            Description = description;
            SqlOperator = sqlOperator;
        }

        public override string ToString()
        {
            return Description; // Assim aparece bonito no ComboBox!
        }
    }
}
