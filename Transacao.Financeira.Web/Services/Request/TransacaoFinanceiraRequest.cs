namespace Transacao.Financeira.Web.Services.Request
{
    public class TransacaoFinanceiraRequest
    {
        public IEnumerable<TransacaoFinanceira> TransacoesFinanceiras { get; set; } = new List<TransacaoFinanceira>();
    }

    public class TransacaoFinanceira
    {
        public string BancoOrigem { get; set; }

        public string AgenciaOrigem { get; set; }

        public string ContaOrigem { get; set; }

        public string BancoDestino { get; set; }

        public string AgenciaDestino { get; set; }

        public string ContaDestino { get; set; }

        public decimal ValorTransacao { get; set; }

        public string DataHoraTransacao { get; set; }
    }
}
