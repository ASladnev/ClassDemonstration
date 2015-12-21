using System;
using static Console;

namespace Shape2   
{
  class Shape
  {

    public Shape()
    {

    }

    protected virtual string NameShape() => "Shape";

    public string GetNameShape() => NameShape();
  }

  class Point : Shape
  {
    protected override string NameShape() => "Point";
  }


  static class ConsoleShape
  {
    static public void WriteResult()
    {
      WriteLine ("\n\rShape2");
      WriteLine((new Shape ()).GetNameShape());
    }
  }

}