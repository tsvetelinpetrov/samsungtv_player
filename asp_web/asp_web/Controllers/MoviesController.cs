using asp_web.Models;
using asp_web.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace asp_web.Controllers
{
    public class MoviesController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
        public JsonResult JsonList()
        {

            MoviesDAO.loadJson();

            JsonSerializerOptions options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };

            return Json(MoviesDAO.getList(), options); 
        }
    }
}
