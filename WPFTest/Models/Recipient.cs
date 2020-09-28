﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WPFTest.Models
{
    class Recipient
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public Recipient(string name, string address)
        {
            Name = name;
            Address = address;
        }
    }
}
