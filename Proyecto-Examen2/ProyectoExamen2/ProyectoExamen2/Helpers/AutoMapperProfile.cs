using AutoMapper;
using ProyectoExamen2.Database.Entities;
using ProyectoExamen2.Dtos.Amortizations;
using ProyectoExamen2.Dtos.Clients;
using ProyectoExamen2.Dtos.Loans;

namespace ProyectoExamen2.Helpers
{
    public class AutoMapperProfile : Profile
    {
        //Anadir mappeos
        public AutoMapperProfile() 
        {
            MapsForClients();

            MapsForLoans();

            MapsForAmortizations();
        }

        private void MapsForClients()
        {
            CreateMap<ClientEntity, ClientDto>();
            CreateMap<ClientCreateDto, ClientEntity>();
        }

        private void MapsForLoans()
        {
            CreateMap<LoanEntity, LoanDto>();
            CreateMap<LoanCreateDto,LoanEntity>();
        }

        private void MapsForAmortizations()
        {
            CreateMap<AmortizationEntity, AmortizationDto>();
            CreateMap<AmortizationCreateDto, AmortizationEntity>();
        }
    }
}
