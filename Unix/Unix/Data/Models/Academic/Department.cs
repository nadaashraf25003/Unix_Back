using static System.Collections.Specialized.BitVector32;

namespace Unix.Data.Models.Academic
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Code { get; set; } = null!;

        public ICollection<Section> Sections { get; set; } = new List<Section>();
    }

}
