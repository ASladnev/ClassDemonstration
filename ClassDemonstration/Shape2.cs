using static System.Console;

namespace Shape2   
{
  class Shape
  {
    protected virtual string NameShape() => "This is a Shape";

    public string GetNameShape() => NameShape();
  }

  class  Point : Shape
  {
    protected override string NameShape() => "This is a Point";
  }


  class Line : Shape
  {
    public Line (Point p1, Point p2)
    {

    }

    protected override string NameShape() => "This is a Line";

  }

  static class ConsoleShape
  {
    static public void WriteResult()
    {
      WriteLine ("\n\rShape2 ----------------------------------------------------------");
      WriteLine((new Shape ()).GetNameShape());
      WriteLine((new Point()).GetNameShape());
      WriteLine((new Line(new Point(), new Point()).GetNameShape ()));
    }
  }

}