using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BreakfastCards1.Core
{
    public partial class WorkDay
    {
        [JsonProperty("code")]
        public long Code { get; set; }

        [JsonProperty("type")]
        public TypeClass Type { get; set; }

        [JsonProperty("holiday")]
        public Holiday Holiday { get; set; }
    }

    public partial class Holiday
    {
        [JsonProperty("holiday")]
        public bool HolidayHoliday { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("wage")]
        public long Wage { get; set; }

        [JsonProperty("date")]
        public DateTimeOffset Date { get; set; }

        [JsonProperty("rest")]
        public long Rest { get; set; }
    }

    public partial class TypeClass
    {
        [JsonProperty("type")]
        public long Type { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("week")]
        public long Week { get; set; }
    }
}