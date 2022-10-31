using Transacao.Financeira.Web.Model;
using Transacao.Financeira.Web.Services.Request;
using Transacao.Financeira.Web.Services.Response;

namespace Transacao.Financeira.Web.Services
{
    public interface ITransacaoFinanceiraService
    {
        Task<TransacaoFinanceiraResponse> EnviarTransacoesFinanceiras(TransacaoFinanceiraRequest transacao);

        Task<IEnumerable<DatasTransacaoDto>> ListaTransacoes();
    }
}