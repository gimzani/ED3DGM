
namespace EDGM.Entities
{
    public class JournalStarSystem
    {
        public int JournalId { get; set; }
        public Journal Journal { get; set; }

        public int StarSystemId { get; set; }
        public StarSystem StarSystem { get; set; }
    }
}
