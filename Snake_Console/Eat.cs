using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_Console
{
    public class Eat
    {
        public static bool EatBodyValidation(List<int> leftCoordinates, List<int> topCoordinates)
        {
            int headLeft = leftCoordinates.First();
            int headTop = topCoordinates.First();
            for (int i = 1; i < leftCoordinates.Count; i++)
            {
                if (headLeft == leftCoordinates[i] && headTop == topCoordinates[i])
                {
                    return true;
                }
            }
            return false;
        }

        public static bool EatBoardValidation(List<int> leftCoordinates, List<int> topCoordinates, int width, int height)
        {
            int headLeft = leftCoordinates.First();
            int headTop = topCoordinates.First();
            var isEatLeftBoard = headLeft >= width - 2 || headLeft <= 1;
            var isEatRightBoard = headTop >= height - 2 || headTop <= 1;
            return isEatLeftBoard || isEatRightBoard;
        }

        public static bool SnakeEat(List<int> leftCoordinate, List<int> topCoordinate, int foodLeft, int foodTop, ConsoleKey consoleKey)
        {
            int headLeft = leftCoordinate.First();
            int headTop = topCoordinate.First();
            if (headLeft == foodLeft && headTop == foodTop)
            {
                int nextLeft = GetNextCoordinate.GetNextXCoordinate(headLeft, consoleKey);
                int nextTop = GetNextCoordinate.GetNextYCoordinate(headTop, consoleKey);
                leftCoordinate.Insert(0, nextLeft);
                topCoordinate.Insert(0, nextTop);
                Drawing.DrawPoint(nextLeft, nextTop, "*");
                return true;
            }
            return false;
        }
    }
}
