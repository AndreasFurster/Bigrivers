﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bigrivers.Server.Model
{
    public class Artist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Avatar { get; set; }

        [DefaultValue(true)]
        public bool YoutubeChannelStatus { get; set; }
        public string YoutubeChannel { get; set; }

        [DefaultValue(true)]
        public bool WebsiteStatus { get; set; }
        public string Website { get; set; }

        [DefaultValue(true)]
        public bool FacebookStatus { get; set; }
        public string Facebook { get; set; }

        [DefaultValue(true)]
        public bool TwitterStatus { get; set; }
        public string Twitter { get; set; }

        [DefaultValue(true)]
        public bool Status { get; set; }
        public virtual List<Performance> Performances { get; set; }
        public virtual List<Genre> Genres { get; set; }
    }
}
