using System;
using System.Net;
using System.Threading.Tasks;
using JssBlazor.Client;
using JssBlazor.RenderingHost.Models;
using JssBlazor.RenderingHost.Services;
using Microsoft.AspNetCore.Mvc;

namespace JssBlazor.RenderingHost.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RenderingHostController : Controller
    {
        private readonly ILayoutServiceResultProvider _layoutServiceResultProvider;
        private readonly IPreRenderer _preRenderer;

        public RenderingHostController(
            ILayoutServiceResultProvider layoutServiceResultProvider,
            IPreRenderer preRenderer)
        {
            _layoutServiceResultProvider = layoutServiceResultProvider ?? throw new ArgumentNullException(nameof(layoutServiceResultProvider));
            _preRenderer = preRenderer ?? throw new ArgumentNullException(nameof(preRenderer));
        }

        [HttpPost]
        public async Task<RenderResult> Post([FromBody]RenderRequest renderRequest)
        {
            _layoutServiceResultProvider.Result = renderRequest.FunctionArgs.LayoutServiceResult;
            var appHtml = await _preRenderer.RenderAppAsync<App>("app", ControllerContext, ViewData, TempData);
            var resultModel = new RenderResult
            {
                Html = appHtml,
                Status = (int)HttpStatusCode.OK
            };
            return resultModel;
        }
    }
}
