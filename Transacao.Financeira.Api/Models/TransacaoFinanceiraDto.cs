using FluentResults;

namespace Transacao.Financeira.Api.Models
{
    public class TransacaoFinanceiraDto
    {
        public IEnumerable<TransacaoFinanceira>? TransacoesFinanceiras { get; set; }

        public string DataTransacao { get; private set; }

        public Result Validate()
        {
            if (TransacoesFinanceiras is null ||
                TransacoesFinanceiras?.Count() == 0)
            {
                return Result.Fail("Não foram enviadas transações, o arquivo esta vazio.");
            }

            DefinirDataTransacao();

            return Result.Ok();
        }

        private void DefinirDataTransacao() =>
            DataTransacao = TransacoesFinanceiras?.FirstOrDefault()?.DataTransacaoString;

        private IEnumerable<TransacaoFinanceira> ListarDatasPelaDataTransacao() =>
            TransacoesFinanceiras?.Where(t => t.DataTransacaoString == DataTransacao);

        /// <summary>
        /// Retorna somente itens com valor e com a data de transação da primeira linha
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TransacaoFinanceira> ListaTransacoesValidas()
        {
            var listaComDatasValidas = ListarDatasPelaDataTransacao();

            return from transacao in listaComDatasValidas
                   where
                       string.IsNullOrWhiteSpace(transacao.BancoOrigem) is false &&
                       string.IsNullOrWhiteSpace(transacao.AgenciaOrigem) is false &&
                       string.IsNullOrWhiteSpace(transacao.ContaOrigem) is false &&
                       string.IsNullOrWhiteSpace(transacao.BancoDestino) is false &&
                       string.IsNullOrWhiteSpace(transacao.AgenciaDestino) is false &&
                       string.IsNullOrWhiteSpace(transacao.ContaDestino) is false &&
                       transacao.ValorTransacao > 0 &&
                       transacao.DataTransacaoDate != DateTime.MinValue
                   select transacao;
        }
    }
}