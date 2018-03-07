namespace AgilePrinciplesPractice.Ch36
{
    public enum State
    {
        Locked,
        UnLocked
    }

    public enum Event
    {
        COIN,
        PASS
    }

    public class TurnStile
    {
        public State state = State.Locked;

        private TurnSiteController turnSiteController;

        public TurnStile(TurnSiteController action)
        {
            this.turnSiteController = action;
        }

        public void HandleEvent(Event e)
        {
            switch (state)
            {
                case State.Locked:
                    switch (e)
                    {
                        case Event.COIN:
                            this.state = State.UnLocked;
                            this.turnSiteController.UnLock();
                            break;

                        case Event.PASS:
                            this.turnSiteController.Alarm();
                            break;
                    }
                    break;

                case State.UnLocked:
                    switch (e)
                    {
                        case Event.COIN:
                            this.turnSiteController.ThankYou();
                            break;

                        case Event.PASS:
                            this.state = State.Locked;
                            this.turnSiteController.Lock();
                            break;
                            ;
                    }
                    break;
            }
        }
    }
}