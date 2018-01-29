using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgilePrinciplesPractice.Ch22.Strategy
{
    public class FtoCStrategy : Application
    {
        private TextReader input;
        private TextWriter output;
        private bool isDone = false;

        public static void Main(string[] args)
        {
            (new ApplicationRunner(new FtoCStrategy())).Run();
        }

        public void Init()
        {
            input = Console.In;
            output = Console.Out;
        }

        public void Idle()
        {
            string fahrString = Console.In.ReadLine();
            if (fahrString == null || fahrString.Length == 0)
            {
                isDone = true;
            }
            else
            {
                double fahr = Double.Parse(fahrString);
                double celcius = 5.0 / 9.0 * (fahr - 32);
                Console.Out.WriteLine("F={0},C={1}", fahr, celcius);
            }
        }

        public void CleanUp()
        {
            output.WriteLine("ftoc exit");
        }

        public bool Done()
        {
            return isDone;
        }
    }
}