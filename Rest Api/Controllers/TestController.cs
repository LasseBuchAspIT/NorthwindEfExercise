using Microsoft.AspNetCore.Mvc;

namespace Rest_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : Controller
    {

        [HttpGet]
        [Route("test1")]
        public ActionResult<string> GetTime()
        {
            Thread.Sleep(5000);
            return Ok($"{DateTime.Now.ToString("yyyy.MM.dd HH:mm.ss")}");
        }

        [HttpGet]
        [Route("test2")]
        public async Task<ActionResult<string>> GetTimeAsync()
        {
            string time = "";

            await Task.Run(async () =>
            {
                await Task.Delay(5000).ConfigureAwait(continueOnCapturedContext: false);
                time = $"{DateTime.Now.ToString("yyyy.MM.dd HH:mm.ss")}";
            });
            return Ok(time);
        }
    }
}
