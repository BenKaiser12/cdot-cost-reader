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
        public float Qty { get; set; }
        public float EngEst { get; set; }
        public float AvgBid { get; set; }
        public float AwdBid { get; set; }

    }
}
