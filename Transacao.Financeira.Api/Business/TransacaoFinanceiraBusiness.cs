using FluentResults;
using Transacao.Financeira.Api.Models;
using Transacao.Financeira.Api.Repositorio;

namespace Transacao.Financeira.Api.Business
{
    public class TransacaoFinanceiraBusiness : ITransacaoFinanceiraBusiness
    {
        private readonly ITransacaoFinanceiraRepository _transacaoFinanceiraRepository;

        public TransacaoFinanceiraBusiness(ITransacaoFinanceiraRepository transacaoFinanceiraRepository) =>
            _transacaoFinanceiraRepository = transacaoFinanceiraRepository;

        public async Task<Result> ProcessarTransacoes(TransacaoFinanceiraDto transacaoDto)
        {
            var resultValid = transacaoDto.Validate();

            if (resultValid.IsFailed) return resultValid;

            var transacoesValidas = transacaoDto.ListaTransacoesValidas();

            if (transacoesValidas != null &&
                transacoesValidas.Any())
            {
                var existeDataTransacaoFinanceira =
                    await _transacaoFinanceiraRepository.ExisteLancamentoDataTransacao(transacaoDto.DataTransacao);

                if (existeDataTransacaoFinanceira)
                {
                    return Result.Fail("As transações enviadas já foram inseridas na base anteriormente");
                }

                var quantidadeLinhasAfetadas = await _transacaoFinanceiraRepository.Incluir(transacoesValidas);

                return Result.Ok();
            }
            else
            {
                return Result.Fail("Não foram encontradas transações validas");
            }
        }

        public async Task<ListaTransacaoResponse> ListaTransacoes() =>
            await _transacaoFinanceiraRepository.ListaTransacoes();
    }
}