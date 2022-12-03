using AdPlayTest_Pias.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text;
using System.Text.Json;

namespace AdPlayTest_Pias.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JsonPostErrorHandeler : ControllerBase
    {
        [HttpPost]
        [Route("PostJson")]
        public IActionResult PostJson(string uri, template postParameters)
        {
            try
            {
                string postData = JsonSerializer.Serialize(postParameters);
                if (postData != null)
                {
                    byte[] bytes = Encoding.UTF8.GetBytes(postData);
                    var httpWebRequest = (HttpWebRequest)WebRequest.Create(uri);
                    httpWebRequest.Method = "POST";
                    httpWebRequest.ContentLength = bytes.Length;
                    httpWebRequest.ContentType = "text/xml";
                    using (Stream requestStream = httpWebRequest.GetRequestStream())
                    {
                        requestStream.Write(bytes, 0, bytes.Count());
                    }
                    var httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    if (httpWebResponse.StatusCode != HttpStatusCode.OK)
                    {
                        string message = String.Format("POST failed. Received HTTP {0}",
                        httpWebResponse.StatusCode);
                        //throw new ApplicationException(message);
                        return StatusCode(StatusCodes.Status500InternalServerError, message);
                    }
                }
            }
            catch (Exception ex) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong. Try again.");
            }
            return BadRequest();
        }

    }
}
