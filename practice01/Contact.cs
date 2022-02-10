using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice01
{
    public class Contact
    {
        public int ContactId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
    }
}
