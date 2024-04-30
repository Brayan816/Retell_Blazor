using Newtonsoft.Json;

namespace Retell.Model.Llanta
{
    public class ModelPersona
    {
        [JsonProperty("PERSONAID")] public string PERSONAID { get; set; }
        [JsonProperty("CODIGO")] public string CODIGO { get; set; }
        [JsonProperty("FECHA")] public string FECHA { get; set; }
        [JsonProperty("TIPODOC")] public string TIPODOC { get; set; }
        [JsonProperty("NOMBRE")] public string NOMBRE { get; set; }
        [JsonProperty("DIRECCION")] public string DIRECCION { get; set; }        
    }
}
