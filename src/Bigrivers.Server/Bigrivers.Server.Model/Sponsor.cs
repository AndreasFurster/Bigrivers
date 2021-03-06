﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bigrivers.Server.Model
{
    public class Sponsor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Url { get; set; }
        public int Priority { get; set; }
        [DefaultValue(true)]
        public bool Status { get; set; }
    }
}
