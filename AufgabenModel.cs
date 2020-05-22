namespace PraxiTasks
{
    public class AufgabenModel
    {
        public int Id { get; set; }
        public int Categoryid { get; set; }
        public string CategoryString { get; set; }
        public string CategoryColor { get; set; }
        public string CategoryIcon { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Mainuserid { get; set; }
        public string Mainuser { get; set; }
        public int Subuserid { get; set; }
        public string Subuser { get; set; }
        public int Subsubuserid { get; set; }
        public string Subsubuser { get; set; }
        public int Frequency { get; set; }
        public int Startdate { get; set; }
        public int Enddate { get; set; }
        public int Donedate { get; set; }
        public string Donebyuser { get; set; }
    }
}
