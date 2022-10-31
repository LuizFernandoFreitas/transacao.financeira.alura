namespace Transacao.Financeira.Web.Services.Response
{
    public class TransacaoFinanceiraResponse
    {
        public bool IsFailed { get; set; }
        public bool IsSuccess { get; set; }
        public List<Reason> Reasons { get; set; }
        public List<Error> Errors { get; set; }
        public List<object> Successes { get; set; }
    }

    public class Error
    {
        public List<object> Reasons { get; set; }
    }

    public class Reason
    {
        public string Message { get; set; }
    }
}