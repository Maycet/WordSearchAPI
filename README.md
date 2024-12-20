# WordSearchAPI

WordSearchAPI es una API que permite buscar palabras en una sopa de letras y registrar los resultados de las búsquedas. También proporciona un reporte de las búsquedas realizadas.

## Requisitos

- .NET 8
- Entity Framework Core
- Base de datos MySQL

## Configuración

1. Clona el repositorio:

    ```bash
    git clone https://github.com/Maycet/WordSearchAPI.git
    cd WordSearchAPI
    ```

2. Configura la cadena de conexión a la base de datos en `appsettings.json`:

    ```json
    {
        "ConnectionStrings": {
            "DefaultConnection": "Server=127.0.0.1;Port=3306;Database=word_search;User=root;Password=tu-contraseña;"
        }
    }
    ```

3. Restaura los paquetes NuGet:

    ```bash
    dotnet restore
    ```

4. Aplica las migraciones para crear y actualizar el esquema de la base de datos:

    ```bash
    dotnet ef database update
    ```

## Ejecución

Para ejecutar la API, utiliza el siguiente comando:

```bash
dotnet run
```

La API estará disponible en `https://localhost:7068` o `http://localhost:5000` o `http://localhost:5001`.

## Endpoints

### POST /WordSearch/contieneNombre

Busca una palabra en una sopa de letras y registra el resultado.

#### Request

```json
{
    "info": ["ABCD", "EFGH", "IJKL", "MNOP"],
    "nombre": "EFG"
}
```

#### Response

```json
{
    "resultado": true
}
```

### GET /WordSearch/reporte

Obtiene un reporte de las búsquedas realizadas.

#### Response

```json
{
    "cuenta_contieneNombre": 10,
    "cuenta_noContieneNombre": 5,
    "relacion": 0.5
}
```

## Método contieneNombre

El método `contieneNombre` de la clase `WordSearchManager` busca una palabra en una sopa de letras. La sopa de letras se representa como un arreglo de cadenas (`string[]`), y la palabra a buscar es una cadena (`string`).

### Descripción

1. **Crear índice de posiciones por carácter**: Se crea un diccionario que mapea cada carácter a una lista de posiciones donde aparece en la sopa de letras.
2. **Verificar existencia del primer carácter**: Si el primer carácter de la palabra no existe en la sopa de letras, se retorna `false`.
3. **Buscar en todas las direcciones**: Se buscan las palabras en todas las direcciones posibles (horizontal, vertical y diagonales).
4. **Verificar límites**: Se verifica que la búsqueda no exceda los límites de la sopa de letras.
5. **Comparar caracteres**: Se comparan los caracteres de la sopa de letras con los de la palabra en la dirección especificada.

### Código

```csharp
public bool contieneNombre(string[] info, string nombre)
{
    int Rows = info.Length;
    int Columns = info[0].Length;

    // Crear índice de posiciones por carácter
    Dictionary<char, List<(int, int)>> CharactersIndex = CreateCharIndex(info);

    // Si el primer carácter no existe en la sopa, se retorna false
    if (!CharactersIndex.TryGetValue(nombre[0], out List<(int, int)>? CharIndexes)) return false;

    // Direcciones: Horizontal, Vertical, Diagonales
    int[,] SearchDirections = new int[,]
    {
        { 0, 1 },  { 0, -1 }, { 1, 0 },  { -1, 0 },
        { 1, 1 },  { -1, -1 }, { 1, -1 }, { -1, 1 }
    };

    foreach ((int Row, int Column) in CharIndexes)
    {
        foreach (int Direction in Enumerable.Range(0, SearchDirections.GetLength(0)))
        {
            if (CanSearch(Row,
                        Column,
                        SearchDirections[Direction, 0],
                        SearchDirections[Direction, 1],
                        nombre.Length,
                        Rows,
                        Columns) &&
                Search(info,
                    nombre,
                    Row,
                    Column,
                    SearchDirections[Direction, 0],
                    SearchDirections[Direction, 1])) return true;
        }
    }

    return false;
}
```


## Licencia

Este proyecto está licenciado bajo la [Licencia MIT](https://opensource.org/license/mit).