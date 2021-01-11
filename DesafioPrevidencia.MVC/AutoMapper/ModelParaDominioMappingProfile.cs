using AutoMapper;
using DesafioPrevidencia.Dominio.Entidades;
using DesafioPrevidencia.MVC.Models;

namespace DesafioPrevidencia.MVC.AutoMapper
{
    public class ModelParaDominioMappingProfile : Profile
    {
        public ModelParaDominioMappingProfile()
        {
            CreateMap<CarteiraModel, Carteira>();
            CreateMap<UsuarioModel, Usuario>();
            CreateMap<PerfilInvestidorModel, PerfilInvestidor>();
            CreateMap<SolicitacaoModel, Solicitacao>();
            CreateMap<RespostasFormularioModel, RespostasFormulario>();
        }
    }
}