namespace TaskInforce.BLL.DTO
{
    public class URLDTO
    {
        public int Id { get; set; }

        public string ShortUrl { get; set; }

        public string OriginalUrl { get; set; }

        public string CreatedByUserName { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
