using Transacao.Financeira.Web.Model;

namespace Transacao.Financeira.Web.Services.Response
{
    public class ListaTransacoesResponse
    {
        public IEnumerable<DatasTransacaoDto> ListaTransacoes { get; set; }
    }
}
