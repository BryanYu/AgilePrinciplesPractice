using System.Web.ModelBinding;

namespace AgilePrinciplesPractice.Ch35.Decorator
{
    public class LoudDialModem : Modem
    {
        private Modem itsModem;

        public int SpeakerVolume
        {
            get
            {
                return this.itsModem.SpeakerVolume;
            }
            set
            {
                this.itsModem.SpeakerVolume = value;
            }
        }

        public string PhoneNumber
        {
            get
            {
                return this.itsModem.PhoneNumber;
            }
        }

        public LoudDialModem(Modem m)
        {
            this.itsModem = m;
        }

        public void Dial(string pno)
        {
            this.itsModem.SpeakerVolume = 10;
            this.itsModem.Dial(pno);
        }
    }
}