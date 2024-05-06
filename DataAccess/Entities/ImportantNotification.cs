using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

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
		public static ImportantNotification Create(Guid id, DateTime timePublish, string shortMessage)
		{
			var notification = new ImportantNotification()
			{
				Id = id,
				TimePublish = timePublish,
				ShortMessage = shortMessage
			};

			return notification;
		}
    }
}