using Application.Funcionalidades.ParamGerais.Dtos;
using Application.Funcionalidades.ParamGerais.Servicos;
using Application.Funcionalidades.ParamGerais.Visoes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ParamGeralController : ControllerBase
    {
        private readonly IServicoParamGeral _aplic;

        public ParamGeralController(IServicoParamGeral aplic)
        {
            _aplic = aplic;
        }

        [HttpGet]
        [Route("listar")]
        public async Task<ActionResult<ParamGeralView>> Listar()
        {
            var result = await _aplic.Listar();
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult> Atualizar([FromBody] AtualizarParamGeralRequisicao dto)
        {
            await _aplic.Atualizar(dto);
            return NoContent();
        }
    }
}
