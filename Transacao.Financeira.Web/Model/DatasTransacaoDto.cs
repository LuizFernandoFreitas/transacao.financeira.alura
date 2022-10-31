namespace Transacao.Financeira.Web.Model
{
    public class DatasTransacaoDto
    {
        public string Data_Hora_Transacao { get; set; }

        public string Data_Hora_Importacao { get; set; }

        public DateTime Data_Hora_TransacaoDate =>
             Convert.ToDateTime(Data_Hora_Transacao);
    }
}
