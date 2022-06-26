using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Web;

//https://localhost:7236/api/sample/playvideo

namespace asp_web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SampleController : Controller
    {

        [HttpGet]
        [Route("PlayVideo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public FileResult PlayVideo()
        {

                string path = Path.Combine(@"D:\test.mkv"); 
                var filestream = System.IO.File.OpenRead(path);
                //return Results.File(filestream, contentType: "video/mp4", fileDownloadName: fileName, enableRangeProcessing: true);
                return PhysicalFile(path, contentType: "application/octet-stream", enableRangeProcessing: true);

        }

        [HttpGet]
        [Route("test")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public Stream test()
        {
            string path = Path.Combine(@"D:\test.mkv");
            var filestream = System.IO.File.OpenRead(path);
            return filestream;
        }

    }
}
