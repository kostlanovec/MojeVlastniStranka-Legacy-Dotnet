using System.ComponentModel.DataAnnotations.Schema;

namespace MojeVlastniStranka.DataAccess.Entities
{
	public class Message: IEntities
	{
		protected Message () { }

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
        /// Vrací nebo nastavuje dlouhou zprávu.
        /// </summary>
        [Column(TypeName = "text")]
        public string LongMessage
		{
			get;
			set;
		}

		/// <summary>
		///  Vytváří instanci <see cref="NewsLetter"/> Vhodný pro uložení do databáze.
		/// </summary>
		public static Message Create(DateTime timePublish, string shortMessage, string longMessage)
		{
			var message = new Message()
			{
                Id = Guid.NewGuid(),
				TimePublish = timePublish,
				ShortMessage = shortMessage,
				LongMessage = longMessage
			};

			return message;
		}
	}
}
