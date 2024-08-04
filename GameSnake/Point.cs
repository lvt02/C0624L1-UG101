namespace GameSnake;
class Point
{
    public int X {get; set;}
    public int Y {get; set;}
    public string DisplayHead = "*";
    public string DisplayFood = "@";
    public Point(int x, int y)
    {
        X = x; Y = y;
    }
}