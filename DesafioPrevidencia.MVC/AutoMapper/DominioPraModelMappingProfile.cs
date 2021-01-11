using AutoMapper;
using DesafioPrevidencia.Dominio.Entidades;
using DesafioPrevidencia.MVC.Models;

namespace DesafioPrevidencia.MVC.AutoMapper
{
    public class DominioPraModelMappingProfile : Profile
    {
        public DominioPraModelMappingProfile()
        {
            CreateMap<Carteira, CarteiraModel>();
            CreateMap<Usuario, UsuarioModel>();
            CreateMap<PerfilInvestidor, PerfilInvestidorModel>();
            CreateMap<Solicitacao, SolicitacaoModel>();
            CreateMap<RespostasFormulario, RespostasFormularioModel>();
        }
    }
}