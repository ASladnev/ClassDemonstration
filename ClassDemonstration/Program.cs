using System;

namespace ClassDemonstration
{

  class DrawFieldException : Exception
  {
    public DrawFieldException (Shape shape)
    {
      Console.WriteLine ("Фигура {0} {1} превысила размеры области вывода", shape.GetNameShape (), shape.GetNameInstance ());
    }
  }

  static class DrawField
  {
    public static int X { get; } = 1000;
    public static int Y { get; } = 500;
  }

  abstract class Shape
  {
    protected int X;
    protected int Y;
    private readonly string _nameShape;
    private string _nameInstance;

    protected Shape (int x, int y, string nameShape)
    {
      CheckToDrawField (x, y);
      X = x;
      Y = y;
      _nameShape = nameShape;
    }

    public int GetX ()
    {
      return X;
    }

    public int GetY ()
    {
      return Y;
    }

    public string GetNameShape ()
    {
      return _nameShape;
    }

    private void CheckToDrawField (int x, int y)
    {
      if (DrawField.X < x || DrawField.Y < y || x < 0 || y < 0)
        throw new DrawFieldException(this);
    }

    public void MoveTo (int x, int y)
    {
      CheckToDrawField (x, y);
      Clear ();
      X = x;
      Y = y;
      Draw ();
    }

    protected abstract void Clear ();

    protected virtual void Draw ()
    {
      Console.WriteLine ("Подготовка к рисованию...");
    }


    public void SetNameInstance (string nameInstance)
    {
      _nameInstance = nameInstance;
    }

    public string GetNameInstance ()
    {
      return _nameInstance;
    }

  }

 
  class Point : Shape
  {
    public Point (int x, int y) : base (x, y, "ТОЧКА")
    {
      
    }

    protected Point (int x, int y, string nameShape) : base (x, y, nameShape)
    {
      
    }

    protected override void Clear ()
    {
      Console.WriteLine ("Очищаем {0} в {1}, {2}", GetNameShape(), X, Y);
    }

    protected override void Draw ()
    {
      base.Draw ();
      Console.WriteLine ("Рисуем {0} в {1}, {2}", GetNameShape(), X, Y);
    }
  
  }


  class Circe : Point
  {
    private int _radius;

    public Circe (int x, int y, int r) : base (x, y, "Окружность")
    {
      _radius = r;
    }

    protected override void Clear ()
    {
      Console.WriteLine ("Очищаем {0} радиусом {1} в точку {2}, {3}", GetNameShape (), _radius, X, Y);
    }

    protected override void Draw ()
    {
      Console.WriteLine("Рисуем {0} радиусом {1} в точку {2}, {3}", GetNameShape(), _radius, X, Y);
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
        circle.SetNameInstance ("Кружочек");
        circle.MoveTo (20, 10);
        circle.ChangeRadius (-20);
      }
      catch (DrawFieldException)
      {
        
      }
      Console.ReadKey ();
    }
  }
}
