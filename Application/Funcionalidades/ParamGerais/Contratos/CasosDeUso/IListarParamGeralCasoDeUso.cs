using Application.Funcionalidades.ParamGerais.Visoes;

namespace Application.Funcionalidades.ParamGerais.Contratos.CasosDeUso
{
    public interface IListarParamGeralCasoDeUso
    {
        Task<ParamGeralView> ExecutarAsync();
    }
}
