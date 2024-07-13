using System.ComponentModel.DataAnnotations.Schema;

namespace MojeVlastniStranka.DataAccess.Entities
{
    public class UserSubscriptionNewsLetter : IEntities
    {
        protected UserSubscriptionNewsLetter() { }

        /// <summary>
        /// Vrací nebo nastavuje Id Odběrovatelé.
        /// </summary>
        public Guid Id
        {
            get;
            set;
        }

        /// <summary>
        /// Vrací nebo nastavuje Email odběrovatele.
        /// </summary>
        [Column(TypeName = "nvarchar(1000)")]
        public string email
        {
            get;
            set;
        }

        /// <summary>
        /// Vrací nebo nastavuje has uživatelovi.
        /// </summary>
        [Column(TypeName = "nvarchar(1000)")]
        public string Hastag
		{
			get;
			set;
		}

        public static UserSubscriptionNewsLetter Create(string email, string hastag)
        {
            var userSubscriptionNewsLetter = new UserSubscriptionNewsLetter()
            {
                Id = Guid.NewGuid(),
                email = email,
                Hastag = hastag
            };

            return userSubscriptionNewsLetter;
        }
    }
}
