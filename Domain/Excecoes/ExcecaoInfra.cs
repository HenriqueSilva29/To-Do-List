namespace Domain.Excecoes
{
    public class ExcecaoInfra : ExcecaoBase
    {
        public override string Title => "Erro na camada de infra";

        public ExcecaoInfra(string code, string message)
            : base(code, message)
        { }

        public ExcecaoInfra(string code, string message, Exception innerException)
            : base(code, message, innerException)
        { }
    }
}

