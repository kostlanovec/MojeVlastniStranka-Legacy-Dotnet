namespace MojeVlastniStranka.DataAccess.Entities
{
	internal class UserSubscriptionNewsLetter: IEntities
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
		public string email
		{
			get;
			set;
		}

		/// <summary>
		/// Vrací nebo nastavuje has uživatelovi.
		/// </summary>
		public string Hastag
		{
			get;
			set;
		}

        public static UserSubscriptionNewsLetter Create(Guid id, string email, string hastag)
        {
            var userSubscriptionNewsLetter = new UserSubscriptionNewsLetter()
            {
                Id = id,
                email = email,
                Hastag = hastag
            };

            return userSubscriptionNewsLetter;
        }
    }
}
