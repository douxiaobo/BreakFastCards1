using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BreakfastCards1.Core
{
    public class Holidays
    {
        [JsonProperty("code", NullValueHandling = NullValueHandling.Ignore)]
        public long? Code { get; set; }

        [JsonProperty("holiday", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, Holiday> Holiday { get; set; }
    }
    public partial class Holiday
    {
        [JsonProperty("holiday", NullValueHandling = NullValueHandling.Ignore)]
        public bool? HolidayHoliday { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("wage", NullValueHandling = NullValueHandling.Ignore)]
        public long? Wage { get; set; }

        [JsonProperty("date", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? Date { get; set; }

        [JsonProperty("rest", NullValueHandling = NullValueHandling.Ignore)]
        public long? Rest { get; set; }
    }
}