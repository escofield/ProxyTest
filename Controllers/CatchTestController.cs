using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
using RequestIntercessor.Models;
using Microsoft.Extensions.Primitives;
using System.Text;

namespace RequestIntercessor.Controllers
{
    public class CatchTestController : Controller
    {
        private readonly IConfiguration _configuration;
        private string ForwardUrl => _configuration.GetValue<string>("Settings:ForwardUrl");
        public CatchTestController(IConfiguration configuraiton){
            _configuration = configuraiton;
        }

        public IActionResult Catch()
        {
            var viewModel = new MirrorView();
            viewModel.Headers = Request.Headers;
            // using (var sr = new StreamReader(Request.Body))
            // {
            //     viewModel.Body = sr.ReadToEnd();
            // }

            viewModel.Url = $"{Request.Scheme}://{Request.Host}{Request.Path}{Request.QueryString}";
            if(Request.HasFormContentType)
            {
                if(Request.Form.Keys.Count > 0)
                {
                    foreach(var k in Request.Form.Keys)
                    {
                        viewModel.Form.Add(k,Request.Form[k]);
                    }
                }
            }
            return View(viewModel);
        }
    }
}
