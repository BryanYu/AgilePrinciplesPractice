using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgilePrinciplesPractice.Ch7
{
    public interface Reader
    {
        int Read();
    }

    public class KeyboardReader : Reader
    {
        public int Read()
        {
            return Keyboard.Read();
        }
    }

    public class Keyboard
    {
        public static int Read()
        {
            throw new NotImplementedException();
        }
    }

    public class Copier
    {
        public static Reader reader = new KeyboardReader();

        public static void Copy()
        {
            int c;
            while ((c = (reader.Read())) != -1)
            {
                Printer.Write(c);
            }
        }
    }

    public class Printer
    {
        public static void Write(int i)
        {
            throw new NotImplementedException();
        }
    }
}