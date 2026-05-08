namespace Domain.Excecoes
{
    public class ExcecaoDominio : ExcecaoBase
    {
        public override string Title => "Regra de negócio violada";

        public ExcecaoDominio(string code, string message) : base(code, message)
        {
        }
    }
}

