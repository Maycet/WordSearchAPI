using System.Text.Json.Serialization;

public class WordSearchResponse
{
    /// <summary>
    /// Indica si la palabra buscada se encuentra en la sopa de letras
    /// </summary>
    [JsonPropertyName("resultado")]
    public bool Result { get; set; }
}