using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson03.DbItems
{
    public class EmployeeProject
    {
        public int EmployeeProjectId { get; set; }
        public int Rate { get; set; }
        public int EmployeeId { get; set; }
        public List<Employee> Employees { get; set; } = new List<Employee>();
        public int ProjectId { get; set; }
        public List<Project> Projects { get; set; } = new List<Project>();
        public DateTime StertedTime { get; set; }
    }
}
