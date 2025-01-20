namespace Game.Simulation.Params
{
    public static class SimulationApplicatorParams
    {
        public struct DirectHealthModification
        {
            public int UnitTargetId;
            public int UnitSourceId;
            public float BaseSkillHealthVariation;
            public string SkillEffectType;
        }
    }
}