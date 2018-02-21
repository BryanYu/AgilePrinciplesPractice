using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgilePrinciplesPractice.Ch29
{
    public interface ShapeFactory
    {
        Shape MakeCircle();

        Shape MakeSquare();
    }

    public interface Shape
    {
    }

    public class ShapeFactoryImplementation : ShapeFactory
    {
        public Shape MakeCircle()
        {
            return new Circle();
        }

        public Shape MakeSquare()
        {
            return new Square();
        }
    }

    public class Square : Shape
    {
    }

    public class Circle : Shape
    {
    }
}