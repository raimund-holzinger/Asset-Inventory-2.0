﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagementApp.Models
{
    public class DnsRecord
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Content { get; set; }
    }
}
