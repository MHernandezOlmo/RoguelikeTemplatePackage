namespace Skills.Ports
{
    public interface ISkillStaticData
    {
        string Forename { get; }
        int Id { get; }
        string ImageKey { get; }
        public ISkillEffectData EffectData { get; }
        
    }
}