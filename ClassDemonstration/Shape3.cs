using static System.Console;

namespace Shape3
{

  class Shape
  {
    public virtual string GetShapeName() => "This's a Shape";
  }

  class Point : Shape
  {
    public override string GetShapeName() => "This's a Point";
  }

  class Circle : Point
  {
    public override string GetShapeName() => "This's a Circlie";
  }

  static class ConsoleShape
  {
    static public void WriteResult()
    {
      WriteLine("\n\rShape3 ----------------------------------------------------------");

      var shapes = new Shape[5];
      shapes[0] = new Shape();
      shapes[1] = new Point();
      shapes[2] = new Point();
      shapes[3] = new Shape();
      shapes[4] = new Circle();

      for (var i=0; i < shapes.Length; i++)
        WriteLine($"{shapes [i].GetShapeName () }");
    }
  }



}