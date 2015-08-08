using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpcTriangle
{
    /// <summary>
    /// Базовый класс, содержащий методы для создания, определения и вычисления площади треугольника.
    /// Для подсчёта площади необходимо вызвать функцию CountSpace с нужными сторонами в качестве аргументов.
    /// </summary>
    public class Triangle
    {
        protected float Side1;
        protected float Side2;
        protected float Side3;

        public Triangle(float Side1, float Side2, float Side3)
        {
            this.Side1 = Side1;
            this.Side2 = Side2;
            this.Side3 = Side3;
        }

        /// <summary>
        /// Метод, проверяющий треугольник на существование (каждая сторона должна быть меньше суммы двух других сторон).
        /// </summary>
        /// <param name="Side1">Одна из сторон треугольника</param>
        /// <param name="Side2">Другая сторона треугольника</param>
        /// <param name="Side3">Оставшаяся сторона треугольника</param>
        /// <returns></returns>
        public static bool IfTriangle(double Side1, double Side2, double Side3)
        {
            if (Side1 > 0 & Side2 > 0 & Side3 > 0)
            {
                if ((Side1 + Side2 > Side3) & (Side1 + Side3 > Side2) & (Side2 + Side3 > Side1))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Метод, вычисляющий периметр треугольника.
        /// </summary>
        public double SemiPerimeter
        {
            get
            {
                return (this.Side1 + this.Side2 + this.Side3) / 2;
            }
        }
        /// <summary>
        /// Метод, вычисляющий площадь любого треугольника с целочисленными сторонами.
        /// </summary>
        /// <returns></returns>
        public virtual double CountSpace()
        {
            return Math.Sqrt(this.SemiPerimeter *
                        (this.SemiPerimeter - this.Side1) *
                        (this.SemiPerimeter - this.Side2) *
                        (this.SemiPerimeter - this.Side3));
        }
    }
    /// <summary>
    /// Класс, содержащий методы для создания, определения и вычисления площади прямоугольного треугольника.
    /// Для подсчёта площади необходимо вызвать функцию CountSpace с нужными сторонами в качестве аргументов.
    /// </summary>
    public class RightTriangle : Triangle
    {
        public RightTriangle(float Сathetus1, float Сathetus2, float Hypotenuze) : base(Сathetus1, Сathetus2, Hypotenuze)
        {
        }

        /// <summary>
        /// Метод, вычисляющий площадь прямоугольного треугольника, основываясь на его нецелочисленных катетах.
        /// </summary>
        /// <returns>Space</returns>
        public override double CountSpace()
        {
            return (1.0 / 2.0) * this.Side1 * this.Side2;
        }
    }
    /// <summary>
    /// Фабрика для создания экземпляров треугольника.
    /// </summary>
    public class TriangleFactory
    {
        public static Triangle CreateTriangle(float Side1, float Side2, float Side3)
        {
            if (Triangle.IfTriangle(Side1, Side2, Side3) == true)
            {
                float Hypotenuze = Math.Max(Math.Max(Side1, Side2), Side3);
                float Cathetus1 = Math.Min(Math.Min(Side1, Side2), Side3);
                float Cathetus2 = (Side1 + Side2 + Side3 - Hypotenuze - Cathetus1);

                if (Math.Pow(Cathetus1, 2) + Math.Pow(Cathetus2, 2) == Math.Pow(Hypotenuze, 2))
                {
                    return new RightTriangle(Cathetus1, Cathetus2, Hypotenuze);
                }
                else
                {
                    return new Triangle(Cathetus1, Cathetus2, Hypotenuze);
                }
            }
            else
            {
                throw new System.ArgumentException("Not a triangle!");
            }
        }
    }
}
