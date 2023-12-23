abstract class Figure
{
    private string name;
    public Figure(string name)
    {
        this.name = name;
    }
    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    public abstract double Area2 { get; }
    public abstract double Area();
    public virtual void Print()
    {
        Console.WriteLine("Название фигуры: {0}", name);
    }
}

class Triangle : Figure
{
    private double a;
    private double b;
    private double c;

    public Triangle(string name, double a, double b, double c) : base(name)
    {
        this.a = a;
        this.b = b;
        this.c = c;
    }

    public void SetABC(double a, double b, double c)
    {
        this.a = a;
        this.b = b;
        this.c = c;
    }

    public void GetABC(out double a, out double b, out double c)
    {
        a = this.a;
        b = this.b;
        c = this.c;
    }

    public override double Area2
    {
        get
        {
            double p = (a + b + c) / 2; 
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c)); 
        }
    }

    public override double Area()
    {
        return Area2;
    }

    public override void Print()
    {
        base.Print();
        Console.WriteLine("Стороны треугольника: {0}, {1}, {2}", a, b, c);
    }
}

class TriangleColor : Triangle
{
    private string color;

    public TriangleColor(string name, double a, double b, double c, string color) : base(name, a, b, c)
    {
        this.color = color;
    }

    public string Color
    {
        get { return color; }
        set { color = value; }
    }

    public override double Area2
    {
        get
        {
            return base.Area2;
        }
    }

    public override double Area()
    {
        return base.Area();
    }

    public override void Print()
    {
        base.Print();
        Console.WriteLine("Цвет фона треугольника: {0}", color);
    }
}