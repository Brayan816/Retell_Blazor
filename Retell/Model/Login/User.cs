using Newtonsoft.Json;
using System.Globalization;

namespace Retell.Model.Login
{
    public class User
    {
        [JsonProperty("SUCCESS")] public bool SUCCESS { get; set; }
        [JsonProperty("MENSAJE")] public string MENSAJE { get; set; }
        [JsonProperty("USURIOID")] public string USURIOID { get; set; }
        [JsonProperty("EMPRESAID")] public string EMPRESAID { get; set; }
        [JsonProperty("EMPRESA")] public string EMPRESA { get; set; }
        [JsonProperty("USERNAME")] public string USERNAME { get; set; }
        [JsonProperty("PASSWORD")] public string PASSWORD { get; set; }
    }
}
