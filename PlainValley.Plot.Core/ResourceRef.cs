﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlainValley.Plot.Core
{
    public class ResourceRef: Entity
    {
        [JsonProperty("R")]
        public string Reference { get; set; }
    }
}
