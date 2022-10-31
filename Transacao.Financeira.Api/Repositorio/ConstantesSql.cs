using Transacao.Financeira.Api.Models;

namespace Transacao.Financeira.Api.Repositorio
{
    public static class ConstantesSql
    {
        public static string INCLUIR_TRANSACAO_FNANCEIRA(TransacaoFinanceira request) =>
           @$"INSERT INTO TRANSACAO_FINANCEIRA 
                (banco_origem, 
                 agencia_origem, 
                 conta_origem, 
                 banco_destino, 
                 agencia_destino, 
                 conta_destino, 
                 valor_transacao, 
                 data_hora_transacao,
                 data_hora_importacao)
              VALUES (
                 '{request.BancoOrigem}', 
                 '{request.AgenciaOrigem}',
                 '{request.ContaOrigem}', 
                 '{request.BancoDestino}', 
                 '{request.AgenciaDestino}', 
                 '{request.ContaDestino}', 
                 {request.ValorTransacao}, 
                 '{request.DataHoraTransacao}',
                 '{DateTime.Now}')";

        public static string EXISTE_DATA_TRANSACAO(string dataTransacao) =>
           @$"SELECT COUNT(data_hora_transacao)
              FROM TRANSACAO_FINANCEIRA
              WHERE DATE(data_hora_transacao) = '{dataTransacao}'";

        public static string LISTA_TRANSACOES =>
           @$"SELECT DISTINCT DATE(data_hora_transacao) as data_hora_transacao, data_hora_importacao
              FROM TRANSACAO_FINANCEIRA";
    }
}