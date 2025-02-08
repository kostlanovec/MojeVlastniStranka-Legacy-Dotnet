namespace MojeVlastniStranka.Common.Models
{
	/// <summary>
	/// Response view model ze service vrsty.
	/// </summary>
	public class ResponseViewModel
	{
		public bool IsSuccess
		{
			get;
			set;
		} = true;

		public string? SuccessMessage
		{
			get;
			set;
		}

		public List<string> Errors
		{
			get;
			set;
		} = new List<string>();
	}
}
