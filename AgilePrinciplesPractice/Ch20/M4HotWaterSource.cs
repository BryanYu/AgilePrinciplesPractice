namespace AgilePrinciplesPractice.Ch20
{
    public class M4HotWaterSource : HotWaterSource, IPollable
    {
        private ICoffeeMakerAPI api;

        public M4HotWaterSource(ICoffeeMakerAPI api)
        {
            this.api = api;
        }

        public override bool IsReady()
        {
            BoilerStatus status = CoffeeMaker.api.GetBoilerStatus();
            return status == BoilerStatus.NOT_EMPTY;
        }

        public override void StartBrewing()
        {
            api.SetReliefValveState(ReliefValveState.CLOSED);
            api.SetBoilerState(BoilerState.ON);
        }

        public override void Pause()
        {
            api.SetBoilerState(BoilerState.OFF);
            api.SetReliefValveState(ReliefValveState.OPEN);
        }

        public override void Resume()
        {
            api.SetBoilerState(BoilerState.ON);
            api.SetReliefValveState(ReliefValveState.CLOSED);
        }

        public void Poll()
        {
            BoilerStatus boilerStatus = api.GetBoilerStatus();
            if (isBrewing)
            {
                if (boilerStatus == BoilerStatus.EMPTY)
                {
                    api.SetBoilerState(BoilerState.OFF);
                    api.SetReliefValveState(ReliefValveState.CLOSED);
                    DeclareDone();
                }
            }
        }
    }
}