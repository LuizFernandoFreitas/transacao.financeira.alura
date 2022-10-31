using FluentResults;
using Transacao.Financeira.Api.Models;

namespace Transacao.Financeira.Api.Business
{
    public interface ITransacaoFinanceiraBusiness
    {
        Task<Result> ProcessarTransacoes(TransacaoFinanceiraDto request);

        Task<ListaTransacaoResponse> ListaTransacoes();
    }
}
