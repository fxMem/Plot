﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlainValley.Plot.Core
{
    public class Language: Entity
    {
        [JsonProperty("D")]
        public string Description { get; set; }
    }
}
