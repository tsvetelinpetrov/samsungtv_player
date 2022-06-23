namespace asp_web.Models
{
    public class MovieModel
    {
        public int id { get; set; }

        public string title { get; set; }

        public string url { get; set; }

        public List<SubtitleModel> subtitles { get; set; }
    }
}
