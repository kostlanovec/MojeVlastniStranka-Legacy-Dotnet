using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MojeVlastniStranka.DataAccess.Entities
{
    public class Image: IEntities
    {
        protected Image(){}

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
        [Column(TypeName = "text")]
        public string FileName
        {
	        get;
	        set;
        }

		/// <summary>
		/// Nastavení alt atributu pro obrázek.
		/// </summary>
		[Column(TypeName = "text")]
		public string Description
        {
            get;
            set;
        }

        public static Image Create(string fileName, string description)
        {
            var image = new Image()
            {
                Id = Guid.NewGuid(),
                FileName = fileName,
                Description = description
            };

            return image;
        }
    }
}
