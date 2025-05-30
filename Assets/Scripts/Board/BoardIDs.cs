using UnityEngine;
using System.Collections.Generic;


namespace Game.Utils
{
    public static class BoardIDs
    {
        public static List<string> GenerateCellIds(int width = 10, int height = 10)
        {
            List<string> ids = new List<string>();

            for (char row = 'A'; row < 'A' + height; row++)
            {
                for (int col = 1; col <= width; col++)
                {
                    ids.Add($"{row}{col}");
                }
            }

            return ids;
        }

        public static Vector2Int IdToCoords(string id)
        {
            char row = id[0];
            int col = int.Parse(id.Substring(1));
            int y = row - 'A';
            int x = col - 1;
            return new Vector2Int(x, y);
        }

        public static string CoordsToId(Vector2Int coords)
        {
            char row = (char)('A' + coords.y);
            int col = coords.x + 1;
            return $"{row}{col}";
        }
    }
}

