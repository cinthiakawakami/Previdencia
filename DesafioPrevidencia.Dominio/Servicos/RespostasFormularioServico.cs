using DesafioPrevidencia.Dominio.Entidades;
using DesafioPrevidencia.Dominio.Interfaces.Repositorios;
using DesafioPrevidencia.Dominio.Interfaces.Servicos;
using System;

namespace DesafioPrevidencia.Dominio.Servicos
{
    public class RespostasFormularioServico : ServicoBase<RespostasFormulario>, IRespostasFormularioServico
    {
        private readonly IRespostasFormularioRepositorio _respostasFormularioRepositorio;
        private readonly IPerfilInvestidorRepositorio _perfilInvestidorRepositorio;

        public RespostasFormularioServico(IRespostasFormularioRepositorio respostasFormularioRepositorio, IPerfilInvestidorRepositorio perfilInvestidorRepositorio)
            : base(respostasFormularioRepositorio)
        {
            _respostasFormularioRepositorio = respostasFormularioRepositorio;
            _perfilInvestidorRepositorio = perfilInvestidorRepositorio;
        }

        public RespostasFormulario BuscarPoIdUsuario(int idUsuario)
        {
            return _respostasFormularioRepositorio.BuscarPoIdUsuario(idUsuario);
        }

        public RespostasFormulario MontarPerfilRespostasFormulario(RespostasFormulario respostasFormulario)
        {
            int valorTotal = respostasFormulario.RespostaObjetivos + respostasFormulario.RespostaPossibilidadePerda + respostasFormulario.RespostaPrazoAplicacao + respostasFormulario.RespostaRenda + respostasFormulario.RespostaResgate;
            if (valorTotal < 20)
            {
                respostasFormulario.PerfilInvestidorId = _perfilInvestidorRepositorio.GetById(1).PerfilInvestidorId;
            }
            else if (valorTotal >= 20 && valorTotal <= 40)
            {
                respostasFormulario.PerfilInvestidorId = _perfilInvestidorRepositorio.GetById(2).PerfilInvestidorId;
            }
            else
                respostasFormulario.PerfilInvestidorId = _perfilInvestidorRepositorio.GetById(3).PerfilInvestidorId;

            respostasFormulario.DataResposta = DateTime.Now;
            return respostasFormulario;
        }


    }
}
