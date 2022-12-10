namespace Lesson7;
internal class Field
{
    public char[,] Space { get; set; }
    public Field(int length, int width)
    {
        Space = new char[length, width];
        InitializeField();
    }

    public void InitializeField()
    {
        for (int y = 0; y < Space.GetLength(1); y++)
        {
            for (int x = 0; x < Space.GetLength(0); x++)
            {
                Space[x, y] = '\0';
            }
        }
    }
}
