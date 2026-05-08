namespace Domain.Excecoes
{
    public abstract class ExcecaoBase : Exception
    {
        public string Code { get; }
        public abstract string Title { get; }

        public ExcecaoBase(string code, string message) : base(message)
        {
            Code = code;
        }

        public ExcecaoBase(string code, string message, Exception innerException)
            : base(message, innerException)
        {
            Code = code;
        }
    }
}


