using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace PDFCloudCCExample.Controllers
{
  public class About
  {
    [JsonProperty("version")]
    public string Ver = "v1.2.3";
    [JsonProperty("framework")]
    public string Fw = RuntimeInformation.FrameworkDescription;
    [JsonProperty("os")]
    public string Os = RuntimeInformation.OSDescription;
  }

  [Route("[controller]")]
  [ApiController]
  public class AboutController: ControllerBase
  {
    [HttpGet]
    public JsonResult Get()
    {
      JsonSerializerSettings jss = new JsonSerializerSettings { Formatting = Formatting.Indented };
      JsonResult jr = new JsonResult(new About(), jss) { StatusCode = StatusCodes.Status200OK };
      return jr;
    }
  }
}