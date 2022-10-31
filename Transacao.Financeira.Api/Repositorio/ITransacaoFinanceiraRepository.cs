using Transacao.Financeira.Api.Models;

namespace Transacao.Financeira.Api.Repositorio
{
    public interface ITransacaoFinanceiraRepository
    {
        Task<int> Incluir(IEnumerable<TransacaoFinanceira> transacoesFinanceiras);

        Task<bool> ExisteLancamentoDataTransacao(string dataTransacao);

        Task<ListaTransacaoResponse> ListaTransacoes();
    }
}
