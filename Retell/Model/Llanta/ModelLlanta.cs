using Newtonsoft.Json;

namespace Retell.Model.Llanta
{
    public class ModelLlanta
    {
        [JsonProperty("LLANTAID")] public string LLANTAID { get; set; }
        [JsonProperty("NUMERO")] public string NUMERO { get; set; }
        [JsonProperty("FECHA")] public string FECHA { get; set; }
        [JsonProperty("FECHAING")] public string FECHAING { get; set; }
        [JsonProperty("FECHAENT")] public string FECHAENT { get; set; }
        [JsonProperty("USERCODE")] public string USERCODE { get; set; }
        [JsonProperty("OBSERVACION")] public string OBSERVACION { get; set; }
        [JsonProperty("NOMPROP")] public string NOMPROP { get; set; }
    }
    public class DeLlanta
    {
        [JsonProperty("DELLANTAID")] public string DELLANTAID { get; set; }
        [JsonProperty("FECHA")] public string FECHA { get; set; }
        [JsonProperty("OBSERVACION")] public string OBSERVACION { get; set; }
        [JsonProperty("USUARIOACT")] public string USUARIOACT { get; set; }
        [JsonProperty("USUARIOANT")] public string USUARIOANT { get; set; }
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
    public class LlantaDoc
    {
        [JsonProperty("DOCLLANTAID")] public string DOCLLANTAID { get; set; }
        [JsonProperty("DELLANTAID")] public string DELLANTAID { get; set; }
        [JsonProperty("FECHA")] public string FECHA { get; set; }
        [JsonProperty("OBSERVACION")] public string OBSERVACION { get; set; }
        [JsonProperty("KEYANEXO")] public string KEYANEXO { get; set; }
        [JsonProperty("NOMANEXO")] public string NOMANEXO { get; set; }

    }
}
