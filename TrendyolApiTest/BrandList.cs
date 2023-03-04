﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrendyolApiTest
{
    [Serializable]
    public class BrandList
    {
        [JsonProperty("brands")]
        public IEnumerable<Brand> Brands { get; set; }
    }
}