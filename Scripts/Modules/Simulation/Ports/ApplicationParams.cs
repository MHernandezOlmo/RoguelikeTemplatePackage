namespace Simulation.Ports
{
    public static class ApplicationParams
    {
        public struct HealthVariationParams
        {
            public int UnitTargetId;
            public int UnitSourceId;
            public float HealthVariation;  //Expected negative value as damage and positive as heal
            public string EffectType;
        }
    }
}