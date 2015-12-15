using System;

namespace ClassDemonstration
{
  // Draw field Exception ------------------------------------------------------------------------------------------------------
  class DrawFieldException : Exception
  {
    public DrawFieldException (Shape shape)
    {

      Console.WriteLine ("Фигура {0} {1} превысила размеры области вывода", shape.NameShape, shape.NameInstance);
    }
  }

  // Draw field ----------------------------------------------------------------------------------------------------------------
  static class DrawField
  {
    public static int Width { get; } = 1000;
    public static int Height { get; } = 500;
  }

  // Abstract class Shape ------------------------------------------------------------------------------------------------------
  abstract class Shape
  {

    public string NameShape { get; private set; }

    public string NameInstance { get; set; }

    protected Shape (string nameShape)
    {
      NameShape = nameShape;
    }

//    public string GetNameShape ()
//    {
//      return _nameShape;
//    }

    protected virtual void CheckToDrawField (int x, int y)
    {
      if (DrawField.Width < x || DrawField.Height < y || x < 0 || y < 0)
        throw new DrawFieldException(this);
    }

   // protected abstract void Clear ();

   // protected virtual void Draw ()
   // {
   //   Console.WriteLine ("Подготовка к рисованию...");
   // }

  }

  // Class Point ---------------------------------------------------------------------------------------------------------------
  class Point : Shape
  {
    protected int X { get; set; }
    protected int Y { get; set; }

    public Point (int x, int y) : base ("ТОЧКА")
    {
      CheckToDrawField (x, y);
    }

    protected Point (int x, int y, string nameShape) : base (nameShape)
    {
      
    }


    public void MoveTo(int x, int y)
    {
      if (x == X && y == Y) return;
      CheckToDrawField(x, y);
      Clear();
      X = x;
      Y = y;
      Draw();
    }


    protected virtual void Clear ()
    {
      Console.WriteLine ("Очищаем {0} в {1}, {2}",NameShape, X, Y);
    }

    protected virtual void Draw ()
    {
      Console.WriteLine ("Рисуем {0} в {1}, {2}", NameShape, X, Y);
    }
  
  }

  // Class Cercle --------------------------------------------------------------------------------------------------------------
  class Circe : Point
  {
    private int _radius;

    public Circe (int x, int y, int r) : base (x, y, "Окружность")
    {
      _radius = r;
    }

    protected override void Clear ()
    {
      Console.WriteLine ("Очищаем {0} радиусом {1} в точку {2}, {3}", NameShape, _radius, X, Y);
    }

    protected override void Draw ()
    {
      Console.WriteLine("Рисуем {0} радиусом {1} в точку {2}, {3}", NameShape, _radius, X, Y);
    }

    public void ChangeRadius (int radius)
    {
      if (_radius == radius) return;
      if (radius < 0)
        throw new DrawFieldException (this);
      
      Clear ();
      _radius = radius;
      Draw ();
    }
  }


//  class Line : Shape
//  {
//    private int _x1, x2;

//  }

  // Main program class --------------------------------------------------------------------------------------------------------
  class Program
  {
    static void Main(string[] args)
    {
      try
      {
        //point --------
        var point = new Point (3, 2);
        point.MoveTo (7, 8);

        //circle -------
        var circle = new Circe (2, 5, 10);
        circle.NameInstance = "Кружочек";
        circle.MoveTo (20, 10);
        circle.ChangeRadius (20);
      }
      catch (DrawFieldException)
      {
        Console.WriteLine($"Программа отработала с исключением {typeof (DrawFieldException).Name}"); 
      }
      Console.ReadKey ();
    }
  }
}
