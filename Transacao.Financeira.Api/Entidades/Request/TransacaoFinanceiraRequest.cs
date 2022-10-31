using Transacao.Financeira.Api.Models;

namespace Transacao.Financeira.Api.Entidades.Request
{
    public class TransacaoFinanceiraRequest
    {
        public IEnumerable<TransacaoFinanceira>? TransacoesFinanceiras { get; set; }
    }
}