using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_Console
{
    public static class GetNextCoordinate
    {
        /// <summary>
        /// Координаты для следующего шага по X
        /// </summary>
        /// <param name="x"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        public static int GetNextXCoordinate(int x, ConsoleKey direction)
        {
            if (direction == ConsoleKey.LeftArrow)
            {
                x--;
            }
            else if (direction == ConsoleKey.RightArrow)
            {
                x++;
            }

            return x;
        }

        /// <summary>
        /// Координаты для следующего шага по Y
        /// </summary>
        /// <param name="x"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        public static int GetNextYCoordinate(int x, ConsoleKey direction)
        {
            if (direction == ConsoleKey.UpArrow)
            {
                x--;
            }
            else if (direction == ConsoleKey.DownArrow)
            {
                x++;
            }

            return x;
        }
    }
}
