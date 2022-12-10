namespace Lesson7;
public abstract class Object
{
    public int X { get; private set; }
    public int Y { get; private set; }
    public string Name { get; protected set; }
    public Object (int x,int y)
    {
        X = x;
        Y = y;
    }
    public void Move(int direction)
    {
        if (direction == 0)
            //Вправо
            X += 1;
        else if (direction == 1)
            //Вниз
            Y += 1;
        else if (direction == 2)
            //Влево
            X -= 1;
        else if (direction == 3)
            //Вверх
            Y -= 1;
    }
}
