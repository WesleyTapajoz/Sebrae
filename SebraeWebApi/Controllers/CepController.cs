using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SebraeWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CepController : ControllerBase
    {
        readonly string remoteUrl = string.Format("http://viacep.com.br/ws/01001000/json/");
        [HttpGet]
        public IActionResult Get()
        {
            var httpRequest = (HttpWebRequest)WebRequest.Create(remoteUrl);
            var response = httpRequest.GetResponse();
            var reader = new StreamReader(response.GetResponseStream());
            string result = reader.ReadToEnd();
            return Ok(result);
        }
    }
}
