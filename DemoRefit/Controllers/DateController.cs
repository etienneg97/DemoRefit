using Microsoft.AspNetCore.Mvc;

namespace DemoRefit.Controllers
{
    [Route("api/[controller]")]
    public class DateController : ControllerBase
    {
        // GET: api/date
        [HttpGet]
        public ActionResult<DateTime> GetServeurDateTime()
        {
            return Ok(DateTime.Now);
        }
    }
}
