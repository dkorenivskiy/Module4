using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson03.DbItems
{
    public class Title
    {
        public int TitleId { get; set; }
        public string Name { get; set; }

        public Employee Employee { get; set; }
    }
}
