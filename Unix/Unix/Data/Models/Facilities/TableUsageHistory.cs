namespace Unix.Data.Models.Facilities
{
    public class TableUsageHistory
    {
        public long Id { get; set; }
        public int TableId { get; set; }
        public long UserId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public TableEntity? Table { get; set; }

    }
}
