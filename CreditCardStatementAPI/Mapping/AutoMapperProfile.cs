using AutoMapper;
using CreditCardStatementAPI.DTO;
using CreditCardStatementAPI.Model;

namespace CreditCardStatementAPI.Mapping
{
    public class AutoMapperProfile :Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Statement,StatementDto>().ReverseMap();
            CreateMap<Transaction,TransactionDto>().ReverseMap();   
            CreateMap<CreateStatementDTO,Statement>().ReverseMap();
            CreateMap<CreateTransactionDTO,Transaction>().ReverseMap();  
        }


    }
}
