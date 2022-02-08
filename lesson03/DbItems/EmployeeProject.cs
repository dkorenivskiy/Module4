using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson03.DbItems
{
    class EmployeeProject
    {
        public int EmployeeProjectId { get; set; }
        public int Rate { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public DateTime StertedTime { get; set; }
    }
}
