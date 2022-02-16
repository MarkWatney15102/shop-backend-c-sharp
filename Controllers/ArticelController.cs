using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shop_Backend.lib.ValueObjects.JsonBodyObjects;
using Shop_Backend.src.Models.Articel;

namespace Shop_Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArticelController : ControllerBase
    {
        private ArticelModel _model { get; set; }

        public ArticelController(ArticelModel model)
        {
            _model = model;
        }

        [HttpGet]
        [Produces("application/json")]
        public string GetList()
        {
            List<Dictionary<string, string>> data = _model.SelectAll();

            return JsonConvert.SerializeObject(new
            {
                sucess = (data.Count > 0),
                data = (data.Count > 0) ? data : new List<Dictionary<string, string>>()
            });
        }

        [HttpGet("/articel/{articelId}")]
        [Produces("application/json")]
        public string GetOneArticel([FromRoute] int articelId)
        {
            List<Dictionary<string, string>> data = _model.SelectByPrimaryId("" + articelId);

            return JsonConvert.SerializeObject(new
            {
                sucess = (data.Count == 1),
                data = (data.Count == 1) ? data : new List<Dictionary<string, string>>()
            });
        }

        [HttpPost("/articel/create")]
        [Produces("application/json")]
        public string CreateArticel([FromBody] dynamic json)
        {
            CreateArticel artciel = JsonConvert.DeserializeObject<CreateArticel>(json.ToString());


            return artciel.description;
        }
    }
}
