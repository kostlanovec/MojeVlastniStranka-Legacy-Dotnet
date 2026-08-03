using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MojeVlastniStranka.DataAccess.Entities
{
    public class GameIdea : IEntities
    {
        protected GameIdea() { }

        [Key]
        public Guid Id { get; set; }

        [Required]
        public string TitleCs { get; set; }

        [Required]
        public string TitleEn { get; set; }

        [Required]
        public string DescriptionCs { get; set; }

        [Required]
        public string DescriptionEn { get; set; }

        public string? ImageUrl { get; set; }

        public DateTime DateAdded { get; set; }

        public static GameIdea Create(string titleCs, string titleEn, string descriptionCs, string descriptionEn, string? imageUrl)
        {
            return new GameIdea
            {
                Id = Guid.NewGuid(),
                TitleCs = titleCs,
                TitleEn = titleEn,
                DescriptionCs = descriptionCs,
                DescriptionEn = descriptionEn,
                ImageUrl = imageUrl,
                DateAdded = DateTime.UtcNow
            };
        }
    }
}
