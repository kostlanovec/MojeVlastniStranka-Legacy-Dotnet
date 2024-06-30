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
		public DateTime TimePublish
		{
			get;
			set;
		}

        /// <summary>
        /// Vrací nebo nastavuje krátkou zprávu.
        /// </summary>
        [Column(TypeName = "nvarchar(100)")]
        public string ShortMessage
		{
			get;
			set;
		}

        /// <summary>
        /// Vrací nebo nastavuje dlouhou zprávu.
        /// </summary>
        [Column(TypeName = "nvarchar(1000)")]
        public string LongMessage
		{
			get;
			set;
		}

		/// <summary>
		///  Vytváří instanci <see cref="NewsLetter"/> Vhodný pro uložení do databáze.
		/// </summary>
		public static Message Create(Guid id, DateTime timePublish, string shortMessage, string longMessage)
		{
			var message = new Message()
			{
				Id = id,
				TimePublish = timePublish,
				ShortMessage = shortMessage,
				LongMessage = longMessage
			};

			return message;
		}
	}
}
