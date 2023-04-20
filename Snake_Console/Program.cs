namespace Snake_Console;
public class Program
{
    public static void Main(string[] args)
    {

        Console.CursorVisible = false;

        int width = 100;
        int height = 30;
        int score = 0;

        Console.SetWindowSize(width, height);
        Console.Title = "Snake";

        Drawing.DrawRectangle(0, 0, "#", width, height);

        var random = new Random();
        int foodX = random.Next(1, width - 2);
        int foodY = random.Next(1, height - 2);

        Drawing.DrawPoint(foodX, foodY, "$");

        List<int> LeftCoordinnates = CreateSnakeXCoordinates(width / 2, 5);
        List<int> TopCoordinnates = CreateSnakeYCoordinates(height / 2, 5);

        DrawSnake(LeftCoordinnates, TopCoordinnates);

        var currentDirection = ConsoleKey.LeftArrow;

        while (true)
        {
            Thread.Sleep(50);
            var isEatBoard = Eat.EatBoardValidation(LeftCoordinnates, TopCoordinnates, width, height);
            if (isEatBoard)
            {
                break;
            }
            var isEat = Eat.SnakeEat(LeftCoordinnates, TopCoordinnates, foodX, foodY, currentDirection);
            if (isEat)
            {
                score++;
                foodX = CreateFoodLeftCoordinate(random, width);
                foodY = CreateFoodTopCoordinate(random, height);
                while (!FoodCoordinatesValidation(foodX, foodY, LeftCoordinnates, TopCoordinnates))
                {
                    foodX = CreateFoodLeftCoordinate(random, width);
                    foodY = CreateFoodTopCoordinate(random, height);
                }
                Drawing.DrawPoint(foodX, foodY, "$");
            }
            var newDirection = Game(LeftCoordinnates, TopCoordinnates, currentDirection);
            var isEatBody = Eat.EatBodyValidation(LeftCoordinnates, TopCoordinnates);
            if (isEatBody)
            {
                break;
            }
            currentDirection = newDirection;
        }
        Console.SetCursorPosition(width / 2 - 10, height / 2);
        Console.Write("Игра окончена, ваш результат: " + score);
        Console.SetCursorPosition(width / 2 - 10, height / 2 + 1);
        Console.Write("Для завершения нажмите на любую клавишу");
        Console.ReadKey();
    }

    public static bool FoodCoordinatesValidation(int left, int top, List<int> leftCoordinates, List<int> topCoordinates)
    {
        for (int i = 0; i < leftCoordinates.Count; i++)
        {
            if (left == leftCoordinates[i] && top == topCoordinates[i])
            {
                return false;
            }
        }
        return true;
    }

   

    public static int CreateFoodLeftCoordinate(Random random, int width)
    {
        return random.Next(1, width - 2);
    }

    public static int CreateFoodTopCoordinate(Random random, int height)
    {
        return random.Next(1, height - 2);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="direction"></param>
    /// <returns></returns>
    public static ConsoleKey Game(List<int> x, List<int> y, ConsoleKey direction)
    {
        if (Console.KeyAvailable)
        {
            var key = Console.ReadKey();
            var directionValidate = DirectionValidation(direction, key.Key);
            if (key.Key != direction && directionValidate)
            {
                Move(x, y, direction);
                return key.Key;
            }
        }

        Move(x, y, direction);
        return direction;
    }

    public static bool DirectionValidation(ConsoleKey pressKey, ConsoleKey currentKey)
    {
        if (pressKey == ConsoleKey.LeftArrow)
        {
            return currentKey != ConsoleKey.RightArrow;
        }
        else if (pressKey == ConsoleKey.RightArrow)
        {
            return currentKey != ConsoleKey.LeftArrow;
        }
        else if (pressKey == ConsoleKey.UpArrow)
        {
            return currentKey != ConsoleKey.DownArrow;
        }
        else if (pressKey == ConsoleKey.DownArrow)
        {
            return currentKey != ConsoleKey.UpArrow;
        }
        return false;
    }

    /// <summary>
    /// Координаты X
    /// </summary>
    /// <param name="startIndex"></param>
    /// <param name="length"></param>
    /// <returns></returns>
    public static List<int> CreateSnakeXCoordinates(int startIndex, int length)
    {
        List<int> coordinates = new List<int>();

        for (int i = 0; i < length; i++)
        {
            coordinates.Add(startIndex + i);
        }

        return coordinates;
    }

    /// <summary>
    /// Координаты Y
    /// </summary>
    /// <param name="startIndex"></param>
    /// <param name="length"></param>
    /// <returns></returns>
    public static List<int> CreateSnakeYCoordinates(int startIndex, int length)
    {
        List<int> coordinates = new List<int>();
        for (int i = 0; i < length; i++)
        {
            coordinates.Add(startIndex);
        }

        return coordinates;
    }

    /// <summary>
    /// Очистка консоли
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    public static void Clean(int left, int right)
    {
        Console.SetCursorPosition(left, right);
        Console.Write(" ");
    }

    public static void DrawSnake(List<int> leftCoordinates, List<int> topCoordinates)
    {
        var count = leftCoordinates.Count;

        for (int i = 0; i < count; i++)
        {
            Drawing.DrawPoint(leftCoordinates[i], topCoordinates[i], "*");
        }
    }

    public static void Move(List<int> coordinatesX, List<int> coordinatesY, ConsoleKey direction)
    {
        var headX = coordinatesX.First();
        var headY = coordinatesY.First();
        var tailX = coordinatesX.Last();
        var tailY = coordinatesY.Last();

        headX = GetNextCoordinate.GetNextXCoordinate(headX, direction);
        headY = GetNextCoordinate.GetNextYCoordinate(headY, direction);

        coordinatesX.RemoveAt(coordinatesX.Count - 1);
        coordinatesY.RemoveAt(coordinatesY.Count - 1);

        Clean(tailX, tailY);

        coordinatesX.Insert(0, headX);
        coordinatesY.Insert(0, headY);

        Drawing.DrawPoint(headX, headY, "*");
    }

    
}

