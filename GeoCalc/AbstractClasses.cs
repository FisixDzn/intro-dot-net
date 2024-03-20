public abstract class Shape : IShape
{
    public string Name {get; set;}
    public Shape(string name)
    {
        Name = name;
    }
    public abstract decimal CalculateArea();
    public abstract decimal CalculatePerimeter();
    public abstract string Describe();
}