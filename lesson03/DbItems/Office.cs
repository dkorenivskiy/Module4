using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson03.DbItems
{
    public class Office
    {
        public int OfficeId { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }

        public Employee Employee { get; set; }
    }
}
