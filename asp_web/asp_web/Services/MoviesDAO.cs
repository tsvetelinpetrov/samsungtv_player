using asp_web.Models;
using Newtonsoft.Json;

namespace asp_web.Services
{
    public static class MoviesDAO
    {
        static List<MovieModel> items = new List<MovieModel>();

        static MoviesDAO()
        {
            loadJson();
        }

        public static void loadJson()
        {
            using (StreamReader r = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "movies.json"))
            {
                string json = r.ReadToEnd();
                items = JsonConvert.DeserializeObject<List<MovieModel>>(json);
            }
        }

        public static void saveJson()
        {
            using (StreamWriter file = File.CreateText(AppDomain.CurrentDomain.BaseDirectory + "movies.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, items);
            }
        }

        public static List<MovieModel> getList()
        {
            return items;
        }

        public static void addMovie(MovieModel movie)
        {
            items.Add(movie);
        }
    }
}
