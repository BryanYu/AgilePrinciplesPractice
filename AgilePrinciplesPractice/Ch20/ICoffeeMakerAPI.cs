namespace AgilePrinciplesPractice.Ch20
{
    public interface ICoffeeMakerAPI
    {
        WarmerPlateStatus GetWarmerPlateStatus();

        BoilerStatus GetBoilerStatus();

        BrewButtonStatus GetBrewButtonStatus();

        void SetBoilerState(BoilerState s);

        void SetWarmerState(WarmerState s);

        void SetIndicatorState(IndicatorState s);

        void SetReliefValveState(ReliefValveState s);
    }
}