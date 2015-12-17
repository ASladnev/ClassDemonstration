using System;

namespace Shape1
{
  // Shape --------------------------------------------------------------------------------------------------------------------
  class Shape 
  {
    protected string _shapeName;

    // Shape ------------------------------------------------------------------------------------------------------------------
    public Shape ()
    {
      _shapeName = "Абстрактная фигура";
    }

    protected Shape (string shapeName)
    {
      _shapeName = shapeName;
    }

    public string GetShapeName ()
    {
      return _shapeName;
    }

  }

  // Point --------------------------------------------------------------------------------------------------------------------
  class Point : Shape 
  {
    private int _x, _y, _color;

    public Point (int x, int y, int color) : base ("Точка")
    {
      _x = x;
      _y = y;
      _color = color;
    }

    public Point(int x, int y, int color, string shapeName) : base(shapeName)
    {
      _x = x;
      _y = y;
      _color = color;
    }

    public int GetX ()
    {
      return _x;
    }

    public int GetY ()
    {
      return _y;
    }

  }

  // Circle -------------------------------------------------------------------------------------------------------------------
  class Circle: Point
  {
    private int _radius;

    public Circle (int x, int y, int color, int radius) : base (x, y, color, "Окружность")
    {
      _radius = radius;
    }

    public int GetRadius()
    {
      return _radius;
    }

  }

  // ConsoleShape -------------------------------------------------------------------------------------------------------------
  static class ConsoleShape
  {
    static public void WriteResult ()
    {
      Console.WriteLine("\n\rShape1 ----------------------------------------------------------");
      var shape = new Shape();
      Console.WriteLine($"Имя фигуры {shape.GetShapeName ()}");

      var point = new Point(5, 10, 34223);
      Console.WriteLine($"Имя для точки {point.GetShapeName()}, размещенной в {point.GetX ()}, {point.GetY ()}");

      var circle = new Circle (55, 17, 2234223, 15);
      Console.WriteLine($"Имя для окружности {circle.GetShapeName()}, размещенной в {circle.GetX()}, {circle.GetY()} радиусом {circle.GetRadius ()}");
    }

  }

}