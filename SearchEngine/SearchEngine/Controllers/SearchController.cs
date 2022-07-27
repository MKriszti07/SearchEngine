using Microsoft.AspNetCore.Mvc;
using SearchEngine.Core.Application.Models;

namespace SearchEngine.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SearchController : ControllerBase
    {
        private readonly ILogger<SearchController> _logger;

        public SearchController(ILogger<SearchController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get(SearchRequestModel model)
        {
            object result = null;

            try
            {
                if (model == null)
                {
                    return BadRequest("");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("");
                }
            }
            catch (Exception)
            {

                throw;
            }

            return Ok();
        }
    }
}
