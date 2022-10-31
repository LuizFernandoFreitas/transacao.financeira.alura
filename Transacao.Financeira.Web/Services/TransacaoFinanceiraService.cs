using System.Text.Json;
using Transacao.Financeira.Web.Model;
using Transacao.Financeira.Web.Services.Request;
using Transacao.Financeira.Web.Services.Response;

namespace Transacao.Financeira.Web.Services
{
    public class TransacaoFinanceiraService : ITransacaoFinanceiraService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly JsonSerializerOptions _options;

        public TransacaoFinanceiraService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;

            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task<TransacaoFinanceiraResponse> EnviarTransacoesFinanceiras(TransacaoFinanceiraRequest request)
        {
            var httpClient = _httpClientFactory.CreateClient("TransacaoFinanceiraClient");

            using var response = await httpClient.PostAsJsonAsync(
                "TransacaoFinanceira",
                request);

            var stream = await response.Content.ReadAsStreamAsync();

            var retorno = await JsonSerializer.DeserializeAsync<TransacaoFinanceiraResponse>(
                stream,
                _options);

            return retorno;
        }

        public async Task<IEnumerable<DatasTransacaoDto>> ListaTransacoes()
        {
            var httpClient = _httpClientFactory.CreateClient("TransacaoFinanceiraClient");

            using var response = await httpClient.GetAsync("TransacaoFinanceira");

            var stream = await response.Content.ReadAsStreamAsync();

            var retorno = await JsonSerializer.DeserializeAsync<ListaTransacoesResponse>(
                stream,
                _options);

            return retorno?.ListaTransacoes;
        }
    }
}