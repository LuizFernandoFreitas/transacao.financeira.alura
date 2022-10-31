using AutoMapper;
using Transacao.Financeira.Api.Entidades.Request;
using Transacao.Financeira.Api.Models;

namespace Transacao.Financeira.Api.Profiles
{
    public class TransacaoFinanceiraProfile : Profile
    {
        public TransacaoFinanceiraProfile()
        {
            CreateMap<TransacaoFinanceiraRequest, TransacaoFinanceiraDto>();
        }
    }
}