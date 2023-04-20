using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_Console
{
    public static class Drawing
    {

        /// <summary>
        /// Отрисовать рисунок
        /// </summary>
        /// <param name="left"></param>
        /// <param name="top"></param>
        /// <param name="sym"></param>
        public static void DrawPoint(int left, int top, string sym)
        {
            Console.SetCursorPosition(left, top);
            Console.Write(sym);
        }

        /// <summary>
        /// Отрисовать по горизантали
        /// </summary>
        /// <param name="left"></param>
        /// <param name="top"></param>
        /// <param name="sym"></param>
        /// <param name="length"></param>
        public static void DrawHorizontalLine(int left, int top, string sym, int length)
        {
            for (int i = 0; i < length; i++)
            {
                DrawPoint(left + i, top, sym);
            }
        }

        /// <summary>
        /// Отрисовать по вертикали
        /// </summary>
        /// <param name="left"></param>
        /// <param name="top"></param>
        /// <param name="sym"></param>
        /// <param name="length"></param>
        public static void DrawVerticalLine(int left, int top, string sym, int length)
        {
            for (int i = 0; i < length; i++)
            {
                DrawPoint(left, top + i, sym);
            }
        }

        /// <summary>
        /// Отрисовать границы
        /// </summary>
        /// <param name="left"></param>
        /// <param name="top"></param>
        /// <param name="sym"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public static void DrawRectangle(int left, int top, string sym, int width, int height)
        {
            DrawHorizontalLine(left, top, sym, width);
            DrawHorizontalLine(left, top + height - 1, sym, width);
            DrawVerticalLine(left, top, sym, height);
            DrawVerticalLine(left + width - 1, top, sym, height);
        }
    }

}
