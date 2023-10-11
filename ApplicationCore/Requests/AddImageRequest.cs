using Microsoft.AspNetCore.Http;

namespace MojeVlastniStranka.ApplicationCore.Requests
{
    public class AddImageRequest
    {
        public IFormFile FileUpload
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }
    }
}
