using System.Collections.Generic;
using UnityEngine;

namespace Game.Utils
{
    public static class BoardIDs
    {
        public static List<string> GenerateCellIds()
        {
            List<string> ids = new List<string>();
            char[] letters = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J' };
            for (int row = 0; row < 10; row++)
            {
                for (int col = 1; col <= 10; col++)
                {
                    ids.Add($"{letters[row]}{col}");
                }
            }
            return ids;
        }

        public static Vector2Int IdToCoords(string id)
        {
            char letter = id[0];
            int number = int.Parse(id.Substring(1));
            int x = number - 1;
            int y = letter - 'A';
            return new Vector2Int(x, y);
        }

        public static string CoordsToId(Vector2Int coords)
        {
            char letter = (char)('A' + coords.y);
            int number = coords.x + 1;
            return $"{letter}{number}";
        }
    }
}

