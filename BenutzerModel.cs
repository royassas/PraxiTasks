namespace PraxiTasks
{
    public class BenutzerModel
    {
        public int Id { get; set; }
        public string Abb { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Jobdescription { get; set; }
        public int IsAdmin { get; set; }
        public string Fullname
        {
            get
            {
                return $"{Firstname} {Lastname}";
            }
        }

    }
}
