using System.ComponentModel.DataAnnotations;

namespace MojeVlastniStranka.DataAccess.Entities
{
    public class Image: IEntities
    {
        protected Image()
        {
        }

        /// <summary>
        /// Nastavení id obrázku.
        /// </summary>
        [Key]
        public Guid Id
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

        public static Image Create(Guid id, string fileName, string description)
        {
            var image = new Image()
            {
                Id = id,
                FileName = fileName,
                Description = description
            };

            return image;
        }
    }
}
