namespace Lesson7;
internal class Program
{
    static Random rnd = new Random();
    static Field field = new Field(11,11);
    static List<Object> objects = new List<Object>();
    static List<Object> bufferlist = new List<Object>();
    static List<Hit> hitlist = new List<Hit>();
    static List<Miss> misslist = new List<Miss>();
    static void Main()
    {
        Player p = new Player(0,0);
        for (int i = 0; i < 5; i++)
        {
            Ship s = new Ship(rnd.Next(0, 10), rnd.Next(0, 10));
            objects.Add(s);
        }        
        objects.Add(p);

        while(true)
        {
            field.InitializeField();

            ConsoleKeyInfo pushedKey = Console.ReadKey();
            int dirPlayer = 0;
            int shot = 0;
            if (pushedKey.Key == ConsoleKey.RightArrow)
                dirPlayer = 0;
            else if (pushedKey.Key == ConsoleKey.DownArrow)
                dirPlayer = 1;
            else if (pushedKey.Key == ConsoleKey.LeftArrow)
                dirPlayer = 2;
            else if (pushedKey.Key == ConsoleKey.UpArrow)
                dirPlayer = 3;
            else if (pushedKey.Key == ConsoleKey.Enter)
                 shot = 1;
            
            foreach (Object o in objects)
            {
                if (o.Name == "Player" & shot == 1)
                {
                    Miss miss = new Miss(p.X, p.Y);
                    misslist.Add(miss);
                    p.Move(dirPlayer);
                }
                else if (o.Name == "Player" & shot == 0)
                {                    
                    p.Move(dirPlayer);
                    if (p.X >= 0 & p.Y == 0)
                        p.Move(1);
                    else if (p.X == 0 & p.Y >= 0)
                        p.Move(0);
                    else if (p.X >= 0 & p.Y == 10)
                        p.Move(3);
                    else if (p.X == 10 & p.Y >= 0)
                        p.Move(2);
                }
                else if (o.Name == "Ship" & o.X == p.X & o.Y == p.Y & shot == 1)
                {
                    bufferlist.Add(o);
                    Hit hit = new Hit(p.X, p.Y);
                    hitlist.Add(hit);
                }

            }
            foreach (Object miss in misslist)
            {
                objects.Add(miss);
            }
            foreach (Object hit in hitlist)
            {
                objects.Add(hit);
            }
            foreach (Object o in bufferlist)
            {
                objects.Remove(o);
            }

            PlaceObjects();
            RenderField();
        }
    }
    static void PlaceObjects()
    {
        foreach (Object a in objects)
        {
            char sprite = '\0';
            switch (a.Name)
            {
                case "Ship":
                    {
                        sprite = 's';
                        break;
                    }
                case "Player":
                    {
                        sprite = '.';
                        break;
                    }
                case "Hit":
                    {
                        sprite = '+';
                        break;
                    }
                case "Miss":
                    {
                        sprite = 'x';
                        break;
                    }
            }
            field.Space[a.X, a.Y] = sprite;
        }
    }
    static void RenderField()
    {
        Console.Clear();
        for (int y = 0; y < field.Space.GetLength(1); y++)
        {
            for (int x = 0; x < field.Space.GetLength(0); x++)
            {
                if (field.Space[x, y] == 's')
                {
                    Console.Write('.');
                }
                else if (field.Space[x, y] == '.')
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.Write(field.Space[x, y]);
                    Console.ResetColor();
                }
                else if (field.Space[x, y] == '+')
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.Write(field.Space[x, y]);
                    Console.ResetColor();
                }
                else if (field.Space[x, y] == 'x')
                {                    
                    Console.Write(field.Space[x, y]);
                }
                else if (field.Space[x, y] == '\0')
                {
                    Console.Write('.');
                }
            }
            Console.WriteLine();
        }
    }
}
