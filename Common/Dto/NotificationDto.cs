namespace MojeVlastniStranka.Common.Dto
{
	public class NotificationDto
	{
		/// <summary>
		/// Vrací nebo nastavuje Id.
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
		public string ShortMessage
		{
			get;
			set;
		}
	}
}
