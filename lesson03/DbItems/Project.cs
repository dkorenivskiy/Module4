using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson03.DbItems
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public int Budget { get; set; }
        public DateTime StartedTime { get; set; }

        public List<EmployeeProject> EmployeeProjects { get; set; } = new List<EmployeeProject>();
    }
}
