using System.Text.Json.Serialization;

namespace WordSearchAPI
{
    public class WordSearchRequest
    {
        /// <summary>
        /// Colección con los caracteres de la sopa de letras
        /// </summary>
        [JsonPropertyName("info")]
        public List<string>? WordSearchContent { get; set; } =  new List<string>();

        /// <summary>
        /// Palabras a buscar en la sopa de letras
        /// </summary>
        [JsonPropertyName("nombre")]
        public string? SearchedWord { get; set; } = string.Empty;
    }
}