namespace AgilePrinciplesPractice.Ch35.Decorator
{
    public class HayesModem : Modem
    {
        private string phoneNumber;

        private int speakerVolume;

        public int SpeakerVolume
        {
            get
            {
                return this.speakerVolume;
            }
            set
            {
                this.speakerVolume = value;
            }
        }

        public string PhoneNumber
        {
            get
            {
                return this.phoneNumber;
            }
        }

        public void Dial(string pno)
        {
            this.phoneNumber = pno;
        }
    }
}