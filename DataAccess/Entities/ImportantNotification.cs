using System.ComponentModel.DataAnnotations.Schema;

namespace MojeVlastniStranka.DataAccess.Entities
{
	public class ImportantNotification: IEntities
	{
		protected ImportantNotification() { }

		/// <summary>
		/// Vrací nebo nastavuje id.
		/// </summary>
		public Guid Id
		{
			get;
			set;
		}

		/// <summary>
		/// Vrací nebo nastavuje, kdy byla notifikace odeslaná.
		/// </summary>
		[Column(TypeName = "timestamp")]
		public DateTime TimePublish
		{
			get;
			set;
		}

        /// <summary>
        /// Vrací nebo nastavuje krátkou zprávu.
        /// </summary>
        [Column(TypeName = "text")]
        public string ShortMessage
		{
			get;
			set;
		}

		/// <summary>
		///  Vytváří instanci <see cref="NewsLetter"/> Vhodný pro uložení do databáze.
		/// </summary>
		public static ImportantNotification Create(DateTime timePublish, string shortMessage)
		{
			var notification = new ImportantNotification()
			{
                Id = Guid.NewGuid(),
                TimePublish = timePublish,
				ShortMessage = shortMessage
			};

			return notification;
		}
    }
}