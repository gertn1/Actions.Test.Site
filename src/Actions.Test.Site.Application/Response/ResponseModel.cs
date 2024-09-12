
namespace Actions.Test.Site.Application.Response
{
    public class ResponseModel<T>
    {
        public T? Dados { get; set; }
        public string Mensagem { get; set; } = string.Empty;
        public bool Status { get; set; } = true;

        public static ResponseModel<T> Success(T data, string message = "Operation successful")
        {
            return new ResponseModel<T>
            {
                Dados = data,
                Status = true,
                Mensagem = message
            };
        }

       
        public static ResponseModel<T> Error(string message, T data = default)
        {
            return new ResponseModel<T>
            {
                Dados = data,
                Status = false,
                Mensagem = message
            };
        }
    }
}
