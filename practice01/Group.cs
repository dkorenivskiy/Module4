﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice01
{
    public class Group
    {
        public int GroupId { get; set; }
        public string Title { get; set; }
        public List<Contact> Contacts { get; set; } = new List<Contact>();
    }
}
