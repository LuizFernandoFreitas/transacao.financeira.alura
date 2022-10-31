namespace Transacao.Financeira.Api.Models
{
    public class ListaTransacaoResponse
    {
        public IEnumerable<DatasTransacao> ListaTransacoes { get; set; }
    }

    public class DatasTransacao
    {
        public string Data_Hora_Transacao { get; set; }

        public string Data_Hora_Importacao { get; set; }
    }
}