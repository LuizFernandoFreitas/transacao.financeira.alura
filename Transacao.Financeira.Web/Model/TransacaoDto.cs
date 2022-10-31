using System.Drawing;

namespace Transacao.Financeira.Web.Model
{
    public class TransacaoDto
    {
        public TransacaoDto(string arquivo)
        {
            var dadosLinha = arquivo.Split(',');

            BancoOrigem = dadosLinha[0];
            AgenciaOrigem = dadosLinha[1];
            ContaOrigem = dadosLinha[2];
            BancoDestino = dadosLinha[3];
            AgenciaDestino = dadosLinha[4];
            ContaDestino = dadosLinha[5];

            _ = decimal.TryParse(dadosLinha[6], out decimal valorTransacao);
            ValorTransacao = valorTransacao;
            
            DataHoraTransacao = dadosLinha[7];
        }

        public string BancoOrigem { get; set; }
        public string AgenciaOrigem { get; set; }
        public string ContaOrigem { get; set; }
        public string BancoDestino{ get; set; }
        public string AgenciaDestino { get; set; }
        public string ContaDestino { get; set; }
        public decimal ValorTransacao { get; set; }
        public string DataHoraTransacao { get; set; }

        public override string ToString() =>
            @$"Banco Origem: {BancoOrigem} - Agencia Origem: {AgenciaOrigem} - Conta Origem: {ContaOrigem} Banco Destino: {BancoDestino} - Agencia Destino: {AgenciaDestino} - Conta Destino: {ContaDestino} - Valor Transacao: {ValorTransacao} - Data Hora Transacao {DataHoraTransacao}";
    }
}