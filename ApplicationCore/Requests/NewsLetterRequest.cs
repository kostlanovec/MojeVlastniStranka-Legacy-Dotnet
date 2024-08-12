namespace MojeVlastniStranka.ApplicationCore.Requests
{
	public class NewsLetterRequest
	{
		/// <summary>
		/// Vrací nebo nastavuje subject emailů.
		/// </summary>
		public string Subject
		{
			get;
			set;
		}

		/// <summary>
		/// Vrací nebo nastavuje html
		/// </summary>
		/// todo přijít na nějaký vhodný validační html tag.
		public string Body
		{
			get;
			set;
		}
	}
}
