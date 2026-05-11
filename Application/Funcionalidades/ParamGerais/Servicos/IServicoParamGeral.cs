using Application.Funcionalidades.ParamGerais.Dtos;
using Domain.Entidades;

namespace Application.Funcionalidades.ParamGerais.Servicos
{
    public interface IServicoParamGeral
    {
        Task<ParamGeral> Listar();
        Task Atualizar(AtualizarParamGeralRequisicao dto);
    }
}


