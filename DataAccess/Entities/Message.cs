namespace MojeVlastniStranka.DataAccess.Entities
{
	public class Message
	{
		protected Message () { }

		/// <summary>
		/// Vrací nebo nastavuje id.
		/// </summary>
		public int? Id
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
		public string ShortMessage
		{
			get;
			set;
		}

		/// <summary>
		/// Vrací nebo nastavuje dlouhou zprávu.
		/// </summary>
		public string LongMessage
		{
			get;
			set;
		}

		/// <summary>
		///  Vytváří instanci <see cref="NewsLetter"/> Vhodný pro uložení do databáze.
		/// </summary>
#if DEBUG
		public static Message Create(int? id, DateTime timePublish, string shortMessage, string longMessage)
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

#else
		public static Message Create(DateTime timePublish, string shortMessage, string longMessage)
		{
			var message = new Message()
			{
				TimePublish = timePublish,
				ShortMessage = shortMessage,
				LongMessage = longMessage
			};

			return message;
		}
#endif
	}
}
