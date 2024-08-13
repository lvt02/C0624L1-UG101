using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.WebSockets;
using System.Reflection.Metadata.Ecma335;

namespace GameSnake;

class Program
{
    #region fields
    static string direction = "RIGHT";
    static int speed = 350;
    static int rows = 20;
    static int cols = 40;
    static string[,] screen = new string[20, 40];
    static Point head = new Point(5, 4);
    static Point food = new Point(-1, -1);
    static bool foodExist = false;
    static bool bodyIncrease = false;
    static Point[] bodySnake = new Point[2]
    {
        new Point(5, 3),
        new Point(5, 2),
    };
    static Point lastBodySnake = new Point(-1, -1);
    static int CountEatFood = 0;
    static DateTime startTime = DateTime.Now;
    static DateTime endTime;
    static int durationTime = 0;
    static Point[] rain = new Point[0]
    {
    };
    #endregion
    static void Main(string[] args)
    {
        Thread game = new Thread(LisenKey);
        game.Start();
        do
        {
            Console.Clear();
            SetupValue();
            SetupBodySnake();
            DrawScreen();
            Point();
            ShowTimer();
            MoveSnakeBody();
            MoveSnakeHead();
            MoveRain();
            BodyIncrease();
            RandomFood();
            Task.Delay(speed).Wait();
        } while (true);
    }
    #region method
    static void MoveRain()
    {
        Random randomRainBack = new Random();
        for (int i = 0; i < rain.Length; i++)
        {
            if (rain[i].X == rows - 2)
            {
                rain[i].X = 1;
                rain[i].Y = randomRainBack.Next(1, cols - 2);
            }
            else
                rain[i].X++;
        }
    }
    static void SetupRain()
    {
        CreateRain();
        for (int i = 0; i < rain.Length; i++)
        {
            screen[rain[i].X, rain[i].Y] = "I";
        }
    }
    static void CreateRain()
    {
        Random randomNewRain = new Random();
        if (rain.Length < 19)
        {
            Array.Resize(ref rain, (rain.Length + 1));
            rain[rain.Length - 1] = new Point(1, randomNewRain.Next(1, cols - 2));
        }
    }
    public static void Point()
    {
        Console.WriteLine($"Scores = {CountEatFood}");
    }
    public static void BodyIncrease()
    {
        if (bodyIncrease)
        {
            Array.Resize(ref bodySnake, (bodySnake.Length + 1));
            bodySnake[bodySnake.Length - 1] = new Point(lastBodySnake.X, lastBodySnake.Y);
            bodySnake[bodySnake.Length - 1].DisplayBody = lastBodySnake.DisplayBody;
            bodyIncrease = false;
        }
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
        SetupRain();
    }
    public static void SetupBodySnake()
    {
        for (int countBody = 0; countBody < bodySnake.Length; countBody++)
        {
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    if (r == bodySnake[countBody].X && c == bodySnake[countBody].Y)
                    {
                        screen[r, c] = bodySnake[countBody].DisplayBody;
                    }
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
                head.Y++;
                if (head.Y == cols - 1)
                {
                    head.Y = 1;
                }
                break;
            case "LEFT":
                head.Y--;
                if (head.Y == 0)
                {
                    head.Y = cols - 2;
                }
                break;
            case "UP":
                head.X--;
                if (head.X == 0)
                {
                    head.X = rows - 2;
                }
                break;
            case "DOWN":
                head.X++;
                if (head.X == rows - 1)
                {
                    head.X = 1;
                }
                break;
        }
        EatFood();
        EatBody();
        EatRain();
    }
    public static void MoveSnakeBody()
    {
        for (int i = bodySnake.Length - 1; i >= 0; i--)
        {
            if (i == 0)
            {
                bodySnake[i].X = head.X;
                bodySnake[i].Y = head.Y;
            }
            else
            {
                bodySnake[i].X = bodySnake[i - 1].X;
                bodySnake[i].Y = bodySnake[i - 1].Y;
            }
            if (i == bodySnake.Length - 1)
            {
                lastBodySnake.X = bodySnake[i].X;
                lastBodySnake.Y = bodySnake[i].Y;
            }
        }
    }
    static void EatRain()
    {
        for (int i = 0; i < rain.Length; i++)
        {
            if (head.X == rain[i].X && head.Y == rain[i].Y)
            {
                DrawLose(i);
                Console.WriteLine(head.X);
                Console.WriteLine(rain[i].X);
                Console.WriteLine(head.Y);
                Console.WriteLine(rain[i].Y);
                Console.WriteLine("Game Over But Rain");
                Console.WriteLine("Your Scores = " + CountEatFood);
                Environment.Exit(0);
            }
        }
    }
    static void DrawLose(int c)
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (head.X == i && head.Y == j)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(screen[i, j]);
                }
                else if (rain[c].X == i && rain[c].Y == j)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(screen[i, j]);
                }
                else Console.Write(screen[i, j]);
                Console.ResetColor();
            }
            Console.WriteLine();
        }
    }
    public static void EatFood()
    {
        if (head.X == food.X && head.Y == food.Y)
        {
            foodExist = false;
            bodyIncrease = true;
            speed -= 50;
            CountEatFood++;
        }
    }
    public static void EatBody()
    {
        for (int i = 0; i < bodySnake.Length; i++)
        {
            if (head.X == bodySnake[i].X && head.Y == bodySnake[i].Y)
            {
                Console.WriteLine("Game Over Body");
                Console.WriteLine("Your Scores = " + CountEatFood);
                Environment.Exit(0);
            }
        }
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
            //Console.WriteLine(direction);
        }
    }
    static void ShowTimer()
    {
        endTime = DateTime.Now;
        durationTime = Convert.ToInt32(Math.Round((endTime - startTime).TotalSeconds, 0));
        Console.WriteLine($"{TimeSpan.FromSeconds(durationTime)}");
    }
    #endregion
}
