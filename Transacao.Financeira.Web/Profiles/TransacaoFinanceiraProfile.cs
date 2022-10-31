using AutoMapper;
using Transacao.Financeira.Web.Model;
using Transacao.Financeira.Web.Services.Request;

namespace Transacao.Financeira.Web.Profiles
{
    public class TransacaoFinanceiraProfile : Profile
    {
        public TransacaoFinanceiraProfile()
        {
            CreateMap<TransacaoDto, TransacaoFinanceira>();
        }
    }
}
