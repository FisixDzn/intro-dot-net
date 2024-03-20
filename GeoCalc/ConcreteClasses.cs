public class Circle : Shape
{
    double PI = Math.PI;
    public decimal Radius {get; set;}
    public Circle(string name, decimal radius) : base(name)
    {
        Radius = radius;
    }
    public override decimal CalculateArea()
    {
        return (decimal)PI * (this.Radius * this.Radius);
    }
    public override decimal CalculatePerimeter()
    {
        return 2 * (decimal)PI * this.Radius;
    }
    public override string Describe()
    {
        decimal area = this.CalculateArea();
        decimal perimeter = this.CalculatePerimeter();
        return $"shape name: {this.Name}\narea of {this.Name}: {area}\nperimeter of {this.Name}: {perimeter}";
    }
}

public class Rectangle : Shape
{
    public decimal Height {get; set;}
    public decimal Width {get; set;}
    public Rectangle(string name, decimal height, decimal width) : base(name)
    {
        Height = height;
        Width = width;
    }
    public override decimal CalculateArea()
    {
        return this.Height * this.Width;
    }
    public override decimal CalculatePerimeter()
    {
        return 2 * (this.Width + this.Height);
    }
    public override string Describe()
    {
        decimal area = this.CalculateArea();
        decimal perimeter = this.CalculatePerimeter();
        return $"shape name: {this.Name}\narea of {this.Name}: {area}\nperimeter of {this.Name}: {perimeter}";
    }
}