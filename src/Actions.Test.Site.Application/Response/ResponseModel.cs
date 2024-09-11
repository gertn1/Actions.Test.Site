//namespace Actions.Test.Site.Application.Response
//{
//    public class ResponseModel<T>
//    {
//        public T? Dados { get; set; }
//        public string Mensagem { get; set; } = string.Empty;
//        public bool Status { get; set; } = true;

//    }
//}


namespace Actions.Test.Site.Application.Response
{
    public class ResponseModel<T>
    {
        public bool Status { get; set; }
        public int StatusCode { get; set; }
        public string Mensagem { get; set; }
        public T Dados { get; set; }
        public List<string>? Erros { get; set; }

        public ResponseModel()
        {
            Erros = new List<string>();
        }

        // Método auxiliar para criar uma resposta de sucesso
        public static ResponseModel<T> Success(T data, string mensagem = "Request successful", int statusCode = 200)
        {
            return new ResponseModel<T>
            {
                Status = true,
                StatusCode = statusCode,
                Mensagem = mensagem,
                Dados = data
            };
        }

        // Método auxiliar para criar uma resposta de erro
        public static ResponseModel<T> Error(string mensagem, int statusCode = 500, List<string>? erros = null)
        {
            return new ResponseModel<T>
            {
                Status = false,
                StatusCode = statusCode,
                Mensagem = mensagem,
                Erros = erros ?? new List<string>()
            };
        }
    }
}
