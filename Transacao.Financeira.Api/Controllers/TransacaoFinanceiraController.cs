using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Transacao.Financeira.Api.Business;
using Transacao.Financeira.Api.Entidades.Request;
using Transacao.Financeira.Api.Models;

namespace Transacao.Financeira.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransacaoFinanceiraController : ControllerBase
    {
        private readonly ITransacaoFinanceiraBusiness _transacaoFinanceiraBusiness;
        private readonly IMapper _mapper;

        public TransacaoFinanceiraController(
            ITransacaoFinanceiraBusiness transacaoFinanceiraBusiness, 
            IMapper mapper)
        {
            _transacaoFinanceiraBusiness = transacaoFinanceiraBusiness;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TransacaoFinanceiraRequest request)
        {
            var transacaoDto = _mapper.Map<TransacaoFinanceiraDto>(request);

            var resultado = await _transacaoFinanceiraBusiness.ProcessarTransacoes(transacaoDto);

            if (resultado.IsFailed) return BadRequest(resultado);

            return Ok(resultado);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var listaTransacoes = await _transacaoFinanceiraBusiness.ListaTransacoes();

            return Ok(listaTransacoes);
        }
    }
}