using Dapper;
using Microsoft.Data.Sqlite;
using Transacao.Financeira.Api.Models;
using static Dapper.SqlMapper;

namespace Transacao.Financeira.Api.Repositorio
{
    public class TransacaoFinanceiraRepository : ITransacaoFinanceiraRepository
    {
        private static readonly string StringConnection = @"DataSource=C:\Laboratorio\database\TransacaoFinanceira\transacaofinanceira.db";

        public async Task<int> Incluir(IEnumerable<TransacaoFinanceira> transacoesFinanceiras)
        {
            using var connection = new SqliteConnection(StringConnection);

            var linhasAfetadas = 0;

            foreach (var transacao in transacoesFinanceiras)
            {
                linhasAfetadas += await connection.ExecuteAsync(
                    ConstantesSql.INCLUIR_TRANSACAO_FNANCEIRA(transacao));
            }

            return Convert.ToInt32(linhasAfetadas);
        }

        public async Task<bool> ExisteLancamentoDataTransacao(string dataTransacao)
        {
            using var connection = new SqliteConnection(StringConnection);

            var quantidadeItens = await connection.ExecuteScalarAsync<int?>(ConstantesSql.EXISTE_DATA_TRANSACAO(dataTransacao));

            return quantidadeItens.HasValue && quantidadeItens > 0;
        }

        public async Task<ListaTransacaoResponse> ListaTransacoes()
        {
            ListaTransacaoResponse retornoListaTransacoes = new ();

            using var connection = new SqliteConnection(StringConnection);

            retornoListaTransacoes.ListaTransacoes = await connection.QueryAsync<DatasTransacao>(ConstantesSql.LISTA_TRANSACOES);

            return retornoListaTransacoes;
        }
    }
}