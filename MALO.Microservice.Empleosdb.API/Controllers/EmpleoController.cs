
namespace MALO.Microservice.Empleosdb.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpleoController : ApiController
    {
        /// <param name="appController"></param>
        public EmpleoController(IApiController appController) : base(appController)
        {

        }

        ///
        ///------- CONSULTAS EMPLEOS
        ///
        [HttpGet("GetEmpleos")]
        public async ValueTask<IActionResult> GetEmpleos()
        {
            return Ok(await _appController.EmpleoPresenter.GetEmpleos());
        }

        [HttpPost("GetEmpleoById")]
        public async ValueTask<IActionResult> GetEmpleoId([FromBody] EmpleoRequestDto request)
        {
            return Ok(await _appController.EmpleoPresenter.GetEmpleoId(request));
        }

        [HttpPost("PostEmpleo")]
        public async ValueTask<IActionResult> PostEmpleo([FromBody] EmpleoPostDto request)
        {
            return Ok(await _appController.EmpleoPresenter.PostEmpleo(request));
        }

        [HttpPost("UpdateEmpleoById")]
        public async ValueTask<IActionResult> UpdateEmpleoId([FromBody] EmpleoUpdateDto request)
        {
            return Ok(await _appController.EmpleoPresenter.UpdateEmpleoId(request));
        }

        [HttpPost("DeleteEmpleoById")]
        public async ValueTask<IActionResult> DeleteEmpleoId([FromBody] EmpleoRequestDto request)
        {
            return Ok(await _appController.EmpleoPresenter.DeleteEmpleoId(request));
        }
    }
}
