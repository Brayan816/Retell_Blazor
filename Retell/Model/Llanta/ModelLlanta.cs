using Newtonsoft.Json;

namespace Retell.Model.Llanta
{
    public class ModelLlanta
    {
        [JsonProperty("CODIGO")] public string CODIGO { get; set; }
        [JsonProperty("FECHAING")] public string FECHAIN{ get; set; }
        [JsonProperty("FECHAENT")] public string FECHAENT { get; set; }
        [JsonProperty("OBSERVACION")] public string OBSERVACION { get; set; }
    }
    public class LlantaGrid
    {
        [JsonProperty("LLANTAID")] public string LLANTAID { get; set; }
        [JsonProperty("NUMERO")] public string NUMERO { get; set; }
        [JsonProperty("FECHAING")] public string FECHAING { get; set; }
        [JsonProperty("FECHAENT")] public string FECHAENT { get; set; }
        [JsonProperty("ASIGNADO")] public string ASIGNADO { get; set; }
        [JsonProperty("ESTADO")] public string ESTADO { get; set; }
    }
}
