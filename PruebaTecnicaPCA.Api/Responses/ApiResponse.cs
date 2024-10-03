using PruebaTecnicaPCA.Core.CustomEntities;

namespace PruebaTecnicaPCA.Api.Responses
{
    public class ApiResponse<T>
    {
        public Metadata Meta { get; set; }

        public T Data { get; set; }

        public ApiResponse(T data)
        {
            Data = data;   
        }
    }
}
