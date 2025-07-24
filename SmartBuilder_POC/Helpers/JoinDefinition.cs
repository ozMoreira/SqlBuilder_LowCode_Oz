using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBuilder_POC.Helpers
{
    internal class JoinDefinition
    {
        public string SourceTable { get; set; }
        public string SourceAlias { get; set; }
        public string SourceField { get; set; }
        public string TargetTable { get; set; }
        public string TargetAlias { get; set; }
        public string TargetField { get; set; }
        public string JoinType { get; set; } // "INNER JOIN", "LEFT JOIN", etc.
    }
}
