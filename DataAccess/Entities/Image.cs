using System.ComponentModel.DataAnnotations;

namespace MojeVlastniStranka.DataAccess.Entities
{
    public class Image
    {
        protected Image()
        {
        }

        /// <summary>
        /// Nastavení id obrázku.
        /// </summary>
        [Key]
        public int Id
        {
	        get;
	        set;
        }

        /// <summary>
        /// Jméno souboru.
        /// </summary>
        public string FileName
        {
	        get;
	        set;
        }

        /// <summary>
        /// Nastavení alt atributu pro obrázek.
        /// </summary>
        public string Description { get; set; }

        public static Image Create(int id, string fileName, string description)
        {
            var image = new Image()
            {
                Id = id,
                FileName = fileName,
                Description = description
            };

            return image;
        }

        public static Image Create(string fileName, string description)
        {
            var image = new Image()
            {
                FileName = fileName,
                Description = description
            };

            return image;
        }
    }
}
