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
    }
}

