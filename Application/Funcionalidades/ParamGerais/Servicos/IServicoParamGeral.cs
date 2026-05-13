using Application.Funcionalidades.ParamGerais.Dtos;
using Application.Funcionalidades.ParamGerais.Visoes;

namespace Application.Funcionalidades.ParamGerais.Servicos
{
    public interface IServicoParamGeral
    {
        Task<ParamGeralView> Listar();
        Task Atualizar(AtualizarParamGeralRequisicao dto);
    }
}
