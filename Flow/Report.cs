using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Malshinon.Data;

namespace Malshinon.Flow
{
    internal class Report
    {
        public int Id { get; set;}
        public Reporter reporter { get; set; }
        public Target target { get; set; }
        public string text { get; set; }
        public DateTime timeOfReport { get; set; } = DateTime.Now;












    }
}
