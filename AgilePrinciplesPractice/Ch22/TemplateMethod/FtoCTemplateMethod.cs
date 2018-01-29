using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AgilePrinciplesPractice.Ch22.TemplateMethod
{
    public class FtoCTemplateMethod : Application
    {
        private TextReader input;

        private TextWriter output;

        public static void Main(string[] args)
        {
            new FtoCTemplateMethod().Run();
        }

        protected override void Init()
        {
            input = Console.In;
            output = Console.Out;
        }

        protected override void Idle()
        {
            string fahrString = Console.In.ReadLine();
            if (fahrString == null || fahrString.Length == 0)
            {
                SetDone();
            }
            else
            {
                double fahr = Double.Parse(fahrString);
                double celcius = 5.0 / 9.0 * (fahr - 32);
                Console.Out.WriteLine("F={0},C={1}", fahr, celcius);
            }
        }

        protected override void CleanUp()
        {
            Console.Out.WriteLine("ftoc exit");
        }
    }
}