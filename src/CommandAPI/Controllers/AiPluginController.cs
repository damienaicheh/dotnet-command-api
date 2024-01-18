using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.Extensions.Configuration;
using CommandAPI.Models;
using System.Text.Json;
using AutoMapper;
using CommandAPI.Dtos;
using System.IO;

namespace CommandAPI.Controllers
{
    [ApiController]
    [Route(".well-known")]
    public class AiPluginController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public AiPluginController(IConfiguration configuration, IMapper mapper)
        {
            _configuration = configuration;
            _mapper = mapper;
        }

        // GET api/commands
        [HttpGet]
        [Route("ai-plugin.json")]
        public ActionResult<string> GetAiPluginDefinition()
        {
            // get the current domain of the ASP NET Core .NET 8
            var currentDomain = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";

            var aiPluginSettings = _configuration.GetSection("AiPlugin").Get<AiPlugin>();

            // serialize app settings to json using System.Text.Json
            var json = JsonSerializer.Serialize(aiPluginSettings);

            // replace {url} with the current domain
            json = json.Replace("{url}", currentDomain, StringComparison.OrdinalIgnoreCase);

            var aiPlugin = JsonSerializer.Deserialize<AiPlugin>(json);

            var aiPluginDto = _mapper.Map<AiPluginDto>(aiPlugin);

            return Ok(aiPluginDto);
        }

        [HttpGet]
        [Route("icon")]
        public ActionResult<string> GetAiPluginIcon()
        {
            if (!System.IO.File.Exists("./Icons/logo.png"))
            {
                return NotFound();
            }

            var imageFileStream = System.IO.File.OpenRead("./Icons/logo.png");
            return File(imageFileStream, "image/png");
        }
    }
}