using System.Net;

namespace BaseApi.Domain.Entities.Base
{
    public class ResponseData
    {
        public virtual bool Success { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public DateTime Timestamp { get; set; }
        public string Message { get; set; }
        public string TypeMessage { get; set; }
        public object Response { get; set; }

        /// <summary>
        /// Resposta de sucesso.
        /// </summary>
        /// <param name="response"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public ResponseData ResponseSuccess(
            object response,
            string message
        )
        {
            return new ResponseData
            {
                Success = true,
                StatusCode = HttpStatusCode.OK,
                Timestamp = DateTime.Now,
                Message = message,
                TypeMessage = "success",
                Response = response
            };
        }

        /// <summary>
        /// Resposta de erro.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="statusCode"></param>
        /// <returns></returns>
        public ResponseData ResponseError(
            string message,
            HttpStatusCode statusCode
        )
        {
            return new ResponseData
            {
                Success = false,
                StatusCode = statusCode,
                Timestamp = DateTime.Now,
                Message = message,
                TypeMessage = "error"
            };
        }
    }
}