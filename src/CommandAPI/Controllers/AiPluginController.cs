using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;
using System;
using Microsoft.Extensions.Configuration;
using CommandAPI.Models;
using System.Text.Json;

namespace CommandAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AiPluginController : ControllerBase
    {

        private readonly IConfiguration _configuration;

        public AiPluginController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // GET api/commands
        [HttpGet]
        [Route(".well-known/ai-plugin.json")]
        public ActionResult<string> Get()
        {
            // get the current domain of the ASP NET Core .NET 8
            var currentDomain = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";

            var aiPluginSettings = _configuration.GetSection("AiPlugin").Get<AiPlugin>();
    
            // serialize app settings to json using System.Text.Json
            var json = JsonSerializer.Serialize(aiPluginSettings);

            // replace {url} with the current domain
            json = json.Replace("{url}", currentDomain, StringComparison.OrdinalIgnoreCase);

            return Ok(JsonSerializer.Deserialize<AiPlugin>(json));
        }
    }
}