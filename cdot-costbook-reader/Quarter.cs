using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cdot_costbook_reader
{
    public class Quarter
    {
        public List<Project> qProjectList { get; set; }
        public float qUnit { get; set; }
        public float qEngEst { get; set; }
        public float qAvgBid { get; set; }
        public float qAwdBid { get; set; }
    }
}
