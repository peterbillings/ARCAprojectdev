
namespace CharacterManagementApi.CharacterManagementDBModel
{
    public partial class CharacterStatus
    {
        public string CharacterName { get; set; }
        public int CurrentHp { get; set; }
        public int TempHp { get; set; }
        public int Gold { get; set; }
        public int ExhaustionLevel { get; set; }
        public string Buff { get; set; }
        public string Debuff { get; set; }

        public virtual CharacterDetails CharacterNameNavigation { get; set; }
    }
}
