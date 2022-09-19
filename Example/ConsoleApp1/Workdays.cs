using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ConsoleApp1
{
    internal class Workdays
    {
        [JsonProperty("code")]
        public long Code { get; set; }

        [JsonProperty("type")]
        public TypeClass Type { get; set; }

        [JsonProperty("holiday")]
        public Holiday_Workday Holiday_Workdays { get; set; }
    }
    public partial class Holiday_Workday
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
