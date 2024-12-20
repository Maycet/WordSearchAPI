
using Microsoft.EntityFrameworkCore;

namespace WordSearchAPI.BusinessMethods
{
    public class WordSearchManager
    {
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

        private Dictionary<char, List<(int, int)>> CreateCharIndex(string[] WordSearchMatrix)
        {
            Dictionary<char, List<(int, int)>> Indexes = new Dictionary<char, List<(int, int)>>();

            for (int RowIndex = 0; RowIndex < WordSearchMatrix.Length; RowIndex++)
            {
                for (int ColumnIndex = 0; ColumnIndex < WordSearchMatrix[RowIndex].Length; ColumnIndex++)
                {
                    char Character = WordSearchMatrix[RowIndex][ColumnIndex];
                    if (!Indexes.ContainsKey(Character)) Indexes[Character] = [];
                    Indexes[Character].Add((RowIndex, ColumnIndex));
                }
            }
            return Indexes;
        }

        private bool CanSearch(int row,
                                      int column,
                                      int rowDelta,
                                      int columnDelta,
                                      int lenght,
                                      int totalRows,
                                      int totalColumns)
        {
            int LastRow = row + (lenght - 1) * rowDelta;
            int FirstRow = column + (lenght - 1) * columnDelta;
            return LastRow >= 0 && LastRow < totalRows && FirstRow >= 0 && FirstRow < totalColumns;
        }

        private bool Search(string[] matrix, string request, int row, int column, int rowDelta, int columnDelta)
        {
            for (int Row = 0; Row < request.Length; Row++)
            {
                int NextRow = row + Row * rowDelta;
                int NextColumn = column + Row * columnDelta;

                if (matrix[NextRow][NextColumn] != request[Row]) return false;
            }

            return true;
        }
    }
}