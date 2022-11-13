namespace OnDoc.Entities
{
    public class MRI
    {
        public string Code { get; set; }
        public string DocEntry { get; set; }
        public string Name { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly Time { get; set; }
        public char Status { get; set; }
        public string Cognates { get; set; }
        public Double ServiceCost { get; set; }
        public int Duration { get; set; }
        public string Patient { get; set; }
        public int MODIF { get; set; }
        public string Resp { get; set; }
    }
}
