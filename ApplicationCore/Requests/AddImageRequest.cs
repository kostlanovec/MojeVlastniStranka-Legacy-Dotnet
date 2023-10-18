using Microsoft.AspNetCore.Http;

namespace MojeVlastniStranka.ApplicationCore.Requests
{
    public class AddImageRequest
    {
        /// <summary>
        /// Vrací nebo nastavuje soubor obrázku.
        /// </summary>
        public IFormFile FileUpload
        {
            get;
            set;
        }

        /// <summary>
        /// Vrací nebo nastavuje popisek obrázku neboli alt element.
        /// </summary>
        public string Description
        {
            get;
            set;
        }
    }
}
