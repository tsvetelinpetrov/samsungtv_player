using asp_web.Models;
using Newtonsoft.Json;

namespace asp_web.Services
{
    public static class MoviesDAO
    {
        static List<MovieModel> items = new List<MovieModel>();
        private static string MOVIES_FILE_PATH = AppDomain.CurrentDomain.BaseDirectory + "movies.json";

        static MoviesDAO()
        {
            loadJson();
        }

        public static void loadJson()
        {
            if(!File.Exists(MOVIES_FILE_PATH))
            {
                saveJson();
            }

            using (StreamReader r = new StreamReader(MOVIES_FILE_PATH))
            {
                string json = r.ReadToEnd();
                items = JsonConvert.DeserializeObject<List<MovieModel>>(json);
            }
        }

        public static void saveJson()
        {
            using (StreamWriter file = File.CreateText(MOVIES_FILE_PATH))
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
