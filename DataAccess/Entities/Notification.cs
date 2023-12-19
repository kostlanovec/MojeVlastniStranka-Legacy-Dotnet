using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace MojeVlastniStranka.DataAccess.Entities
{
	public class Notification
	{
		protected Notification () { }

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
		///  Vytváří instanci <see cref="NewsLetter"/> Vhodný pro uložení do databáze.
		/// </summary>
#if DEBUG
		public static Notification Create(int? id, DateTime timePublish, string shortMessage)
		{
			var notification = new Notification()
			{
				Id = id,
				TimePublish = timePublish,
				ShortMessage = shortMessage
			};

			return notification;
		}

#else
		public static Notification Create(DateTime timePublish, string shortMessage)
		{
			var notification = new Notification()
			{
				TimePublish = timePublish,
				ShortMessage = shortMessage
			};

			return notification;
		}
#endif
	}
}
