namespace AgilePrinciplesPractice.Ch20
{
    public class M4HotWaterSource : HotWaterSource
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

        public override void Start()
        {
            api.SetReliefValveState(ReliefValveState.CLOSED);
            api.SetBoilerState(BoilerState.ON);
        }
    }
}