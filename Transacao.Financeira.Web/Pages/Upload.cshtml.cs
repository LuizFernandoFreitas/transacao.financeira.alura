using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Transacao.Financeira.Web.Model;
using Transacao.Financeira.Web.Services;
using Transacao.Financeira.Web.Services.Request;
using Transacao.Financeira.Web.Services.Response;

namespace Transacao.Financeira.Web.Pages
{
    public class UploadModel : PageModel
    {
        private readonly IMapper _mapper;
        private readonly ITransacaoFinanceiraService _transacaoFinanceiraService;

        public UploadModel(
            ITransacaoFinanceiraService transacaoFinanceiraService,
            IMapper mapper)
        {
            _transacaoFinanceiraService = transacaoFinanceiraService;
            _mapper = mapper;
        }

        [BindProperty]
        public IFormFile UploadFile { get; set; }

        [BindProperty]
        public string MensagemRetorno { get; set; }

        [BindProperty]
        public IEnumerable<DatasTransacaoDto> ListaTransacoes { get; set; }

        public async Task OnGetAsync()
        {
            ListaTransacoes = await _transacaoFinanceiraService.ListaTransacoes();
        }

        public async Task OnPostAsync()
        {
            TransacaoFinanceiraResponse resultResponse = new();

            if (UploadFile is null)
            {
                resultResponse.Reasons = new List<Reason>
                {
                    new Reason { Message = "Arquivo vazio, favor escolher um arquivo no padrão .CSV" }
                };
            }
            else
            {
                var transacaoRequest = new TransacaoFinanceiraRequest
                {
                    TransacoesFinanceiras = LerTransacoesFinanceirasDoArquivoCsv()
                };

                resultResponse = await EnviarTransacoesFinanceiras(transacaoRequest);
            }

            MensagemRetorno = ValidarMensagemRetorno(resultResponse);

            ListaTransacoes = await _transacaoFinanceiraService.ListaTransacoes();
        }

        private async Task<TransacaoFinanceiraResponse> EnviarTransacoesFinanceiras(TransacaoFinanceiraRequest request) =>
            await _transacaoFinanceiraService.EnviarTransacoesFinanceiras(request);

        private IEnumerable<TransacaoFinanceira> LerTransacoesFinanceirasDoArquivoCsv()
        {
            var listaTransacoes = new List<TransacaoFinanceira>();

            var stream = UploadFile.OpenReadStream();

            var sr = new StreamReader(stream);

            while (sr.EndOfStream is false)
            {
                var transacaoDto = new TransacaoDto(sr.ReadLine());

                var transacao = _mapper.Map<TransacaoFinanceira>(transacaoDto);

                listaTransacoes.Add(transacao);
            }

            return listaTransacoes;
        }

        private static string ValidarMensagemRetorno(TransacaoFinanceiraResponse resultResponse)
        {
            if (resultResponse.IsSuccess)
            {
                return $@"<div class='alert alert-success alert-dismissable' 
                               id='alert'><button type='button' class='btn-close' 
                               onclick='$(this).parent().hide();'></button>Transações gravadas com sucesso </a>.</div>";
            }

            var mensagemErro = resultResponse.Reasons.FirstOrDefault().Message;

            return $@"<div class='alert alert-danger alert-dismissable' 
                          id='alert'><button type='button' class='btn-close' 
                          onclick='$(this).parent().hide();'></button>{mensagemErro} </a>.</div>";
        }
    }
}
