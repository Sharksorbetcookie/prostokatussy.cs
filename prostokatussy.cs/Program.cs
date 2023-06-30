using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prostokatussy.cs
{
    internal class Prostokąt
    {
        private double bokA;
        private double bokB;

        public Prostokąt(double bokA, double bokB)
        {
            this.BokA = bokA;
            this.BokB = bokB;
        }

        public double BokA
        {
            get { return bokA; }
            set
            {
                if (double.IsNaN(value) || double.IsInfinity(value) || value <= 0)
                    throw new Exception("Liczba nie jest skończona, nieujemna");
                bokA = value;
            }
        }

        public double BokB
        {
            get { return bokB; }
            set
            {
                if (double.IsNaN(value) || double.IsInfinity(value) || value <= 0)
                    throw new Exception("Liczba nie jest skończona, nieujemna");
                bokB = value;
            }
        }

        public static Dictionary<char, decimal> wysokośćArkusza0 = new Dictionary<char, decimal>()
        {
            ['A'] = 1189,
            ['B'] = 1414,
            ['C'] = 1297
        };

        public static Prostokąt ArkuszPapieru(string format)
        {
            char X = format[0];
            if (!wysokośćArkusza0.ContainsKey(X))
                throw new Exception("Wyjątek");

            byte i;
            if (!byte.TryParse(format.Substring(1), out i))
                throw new Exception("Wyjątek");

            decimal wysokość = wysokośćArkusza0[X];
            double pierwiastekZDwóch = Math.Sqrt(2);
            double bokA = (Convert.ToDouble(wysokość) / Math.Pow(pierwiastekZDwóch, i));
            double bokB = bokA / pierwiastekZDwóch;


            return new Prostokąt(bokA, bokB);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Prostokąt KartkaA4 = Prostokąt.ArkuszPapieru("A4");
            Console.WriteLine($"Wymiary kartki papieru A4:");
            Console.WriteLine($"Bok A: {KartkaA4.BokA} mm");
            Console.WriteLine($"Bok B: {KartkaA4.BokB} mm");
            Console.WriteLine("");
            Prostokąt KartkaB2 = Prostokąt.ArkuszPapieru("B2");
            Console.WriteLine($"Wymiary kartki papieru B2:");
            Console.WriteLine($"Bok A: {KartkaB2.BokA} mm");
            Console.WriteLine($"Bok B: {KartkaB2.BokB} mm");

            Console.ReadLine();
        }
    }
}