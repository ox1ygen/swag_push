using SwagPushTest.Models;
using System;
using System.Collections.Specialized;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;

namespace SwagPushTest.Controllers
{
    public class HomeController : ApiController
    {
        // POST api/<controller>
        public async Task<IHttpActionResult> Post([FromBody]POInformation data)
        {
            if (data == null) return BadRequest("The data is null");
            try
            {
                using (WebClient client = new WebClient())
                {
                    await client.UploadValuesTaskAsync(new Uri("https://api.pushover.net/1/messages.json"), new NameValueCollection {
                                                                                                    { "token", data.App_token },
                                                                                                    { "user", data.User },
                                                                                                    { "message", data.Message }
                });
                }
            }
            catch { return BadRequest("Something went wrong"); }
            return Ok("The notification has been sent");
        }
    }
}