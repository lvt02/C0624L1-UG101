using System.ComponentModel.DataAnnotations;
using System.Net.WebSockets;
using System.Reflection.Metadata.Ecma335;

namespace GameSnake;

class Program
{
    static string direction = "RIGHT";
    static int speed = 500;
    static int rows = 20;
    static int cols = 40;
    static string[,] screen = new string[20, 40];
    static Point head = new Point(5, 4);
    static Point food = new Point(-1, -1);
    static bool foodExist = false;

    static void Main(string[] args)
    {
        Thread game = new Thread(LisenKey);
        game.Start();
        do
        {
            Console.Clear();
            SetupValue();
            DrawScreen();
            MoveSnakeHead();
            RandomFood();
            Task.Delay(speed).Wait();
        } while (true);
    }
    public static void RandomFood()
    {
        if (foodExist == false)
        {
            Random random = new Random();
            int FoodX = random.Next(1, rows - 2);
            int FoodY = random.Next(1, cols - 2);
            food = new Point(FoodX, FoodY);
            foodExist = true;
        }
    }
    public static void EatFood()
    {
        if (head.X == food.X && head.Y == food.Y)
        {
            foodExist = false;
        }
    }
    public static void SetupValue()
    {
        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                if (r == 0 || r == rows - 1 || c == 0 || c == cols - 1)
                {
                    screen[r, c] = "#";
                }
                else if (r == head.X && c == head.Y)
                {
                    screen[r, c] = head.DisplayHead;
                }
                else if (r == food.X && c == food.Y)
                {
                    screen[r, c] = food.DisplayFood;
                }
                else
                {
                    screen[r, c] = " ";
                }
            }
        }
    }
    public static void DrawScreen()
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write(screen[i, j]);
            }
            Console.WriteLine();
        }
    }
    public static void MoveSnakeHead()
    {
        switch (direction)
        {
            case "RIGHT":
                if (head.Y == cols - 1)
                {
                    head.Y = 1;
                }
                else head.Y++;
                break;
            case "LEFT":
                if (head.Y == 0)
                {
                    head.Y = cols - 1;
                }
                else head.Y--;
                break;
            case "UP":
                if (head.X == 0)
                {
                    head.X = rows - 1;
                }
                else head.X--;
                break;
            case "DOWN":
                if (head.X == rows - 1)
                {
                    head.X = 1;
                }
                else head.X++;
                break;
        }
        EatFood();
    }
    public static void LisenKey()
    {
        while (true)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            switch (keyInfo.Key)
            {
                case ConsoleKey.RightArrow:
                    if (direction != "LEFT")
                        direction = "RIGHT";
                    break;
                case ConsoleKey.LeftArrow:
                    if (direction != "RIGHT")
                        direction = "LEFT";
                    break;
                case ConsoleKey.UpArrow:
                    if (direction != "DOWN")
                        direction = "UP";
                    break;
                case ConsoleKey.DownArrow:
                    if (direction != "UP")
                        direction = "DOWN";
                    break;
            }
            Console.WriteLine(direction);
        }
    }
}
