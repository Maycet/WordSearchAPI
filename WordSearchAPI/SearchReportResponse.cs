using System.Text.Json.Serialization;

namespace WordSearchAPI
{
    public class SearchReportResponse
    {
        [JsonPropertyName("cuenta_contieneNombre")]
        public int TotalFoundedRecords { get; set; }

        [JsonPropertyName("cuenta_noContieneNombre")]
        public int TotalNotFoundedRecords { get; set; }

        [JsonPropertyName("relacion")]
        public decimal ResultRatio { get; set; }
    }
}