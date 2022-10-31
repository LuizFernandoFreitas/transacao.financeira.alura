namespace Transacao.Financeira.Api.Models
{
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

        public DateTime DataTransacaoDate => 
            string.IsNullOrWhiteSpace(DataHoraTransacao) ? DateTime.MinValue : Convert.ToDateTime(DataHoraTransacao);

        public string DataTransacaoString => DataTransacaoDate.ToString("yyyy-MM-dd");
    }
}