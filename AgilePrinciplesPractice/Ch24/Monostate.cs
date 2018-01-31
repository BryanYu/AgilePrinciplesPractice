namespace AgilePrinciplesPractice.Ch24
{
    public class Monostate
    {
        private static int itsX;

        public int X
        {
            get { return itsX; }
            set { itsX = value; }
        }
    }
}