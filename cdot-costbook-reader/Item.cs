using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cdot_costbook_reader
{
    public class Item
    {
        public string Code { get; set; }
        public string Desc { get; set; }
        public string Unit { get; set; }
        public string Qty { get; set; }
        public string EngEst { get; set; }
        public string AvgBid { get; set; }
        public string AwdBid { get; set; }

    }
}
