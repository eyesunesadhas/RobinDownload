using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobinHoodDownload.API.Robin.DataModel
{
  
    public class RhFundamental
    {
      
            [JsonProperty("open")]
            public string Open { get; set; }

            [JsonProperty("high")]
            public string High { get; set; }

            [JsonProperty("low")]
            public string Low { get; set; }

            [JsonProperty("volume")]
            public string Volume { get; set; }

            [JsonProperty("market_date")]
            public string MarketDate { get; set; }

            [JsonProperty("average_volume_2_weeks")]
            public string AverageVolume2Weeks { get; set; }

            [JsonProperty("average_volume")]
            public string AverageVolume { get; set; }

            [JsonProperty("high_52_weeks")]
            public string High52Weeks { get; set; }

            [JsonProperty("dividend_yield")]
            public string DividendYield { get; set; }

            [JsonProperty("float")]
            public string Float { get; set; }

            [JsonProperty("low_52_weeks")]
            public string Low52Weeks { get; set; }

            [JsonProperty("market_cap")]
            public string MarketCap { get; set; }

            [JsonProperty("pb_ratio")]
            public string PbRatio { get; set; }

            [JsonProperty("pe_ratio")]
            public string PeRatio { get; set; }

            [JsonProperty("shares_outstanding")]
            public string SharesOutstanding { get; set; }

            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("instrument")]
            public string Instrument { get; set; }

            [JsonProperty("ceo")]
            public string Ceo { get; set; }

            [JsonProperty("headquarters_city")]
            public string HeadquartersCity { get; set; }

            [JsonProperty("headquarters_state")]
            public string HeadquartersState { get; set; }

            [JsonProperty("sector")]
            public string Sector { get; set; }

            [JsonProperty("industry")]
            public string Industry { get; set; }

            [JsonProperty("num_employees")]
            public int? NumEmployees { get; set; }

            [JsonProperty("year_founded")]
            public int? YearFounded { get; set; }

    }
}
