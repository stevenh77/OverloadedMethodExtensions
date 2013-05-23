using System;
using System.Collections.Generic;

namespace OverloadedMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            var shapes = new List<Shape> {new Circle(), new Triangle()};

            foreach (var shape in shapes)
            {
                // option 4:  so what about this....? 
                // (shape as dynamic).Execute();            // doesn't work
                ExtensionMethods.Execute(shape as dynamic); // this works!
            }
        }
    }

    class Shape { }

    class Circle : Shape 
    {
        public int Circumference { get { return 10; } }
    }

    class Triangle : Shape
    {
        public int HypotenuseLength { get { return 20; } }
    }

    static class ExtensionMethods
    {
        public static void Execute(this Circle circle)
        {
            Console.WriteLine("Executing with a Circle with circumference {0}!", circle.Circumference);
        }

        public static void Execute(this Triangle triangle)
        {
            Console.WriteLine("Executing with a Triangle hypotenuse length of {0}!", triangle.HypotenuseLength);
        }
    }
}
