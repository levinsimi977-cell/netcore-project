namespace MusicSimi.Models
{
    public class StudentPostModel
    {
        public int id { get; set; }       // ה-ID של המורה (למשל 8)
        public int userId { get; set; }   // ה-ID של המשתמש (למשל 22)

        public string name { get; set; }
        public string password { get; set; }


        public int age { get; set; }

        public string phone { get; set; }

        public string email { get; set; }

    }
}
