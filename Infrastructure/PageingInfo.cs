using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class PageingInfo
    {
        public int Take { get; set; }
        public int Skip { get; set; }
        public string? Search { get; set; }
        public string? OrderBy { get; set; }
        public bool Reverse { get; set; } = false;
    }
}
