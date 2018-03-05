using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgilePrinciplesPractice.Ch35.Decorator
{
    public interface Modem
    {
        int SpeakerVolume { get; set; }

        string PhoneNumber { get; }

        void Dial(string pno);
    }
}