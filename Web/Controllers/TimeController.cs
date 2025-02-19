using System;
using System.Collections.Generic;
using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using TimeZoneConverter;

namespace MojeVlastniStranka.Web.Controllers
{
	public class TimeController : Controller
	{
		[Route("convert-timestamps")]
		[HttpPost]
		public IActionResult ConvertTimestamps([FromBody] string timestampsString)
		{
			if (string.IsNullOrEmpty(timestampsString))
			{
				return BadRequest("No timestamps provided.");
			}

			try
			{
				// Rozdělte řetězec do seznamu timestampů
				string[] timestampStrings = timestampsString.Split(',');
				List<long> timestamps = new List<long>();

				foreach (var timestampStr in timestampStrings)
				{
					if (long.TryParse(timestampStr.Trim(), out long timestamp))
					{
						timestamps.Add(timestamp);
					}
					else
					{
						return BadRequest("Invalid timestamp format.");
					}
				}

				// Konvertujte každý timestamp do DateTime
				List<string> convertedTimes = new List<string>();
				TimeZoneInfo pragueTimeZone = TZConvert.GetTimeZoneInfo("Europe/Prague");

				foreach (var timestamp in timestamps)
				{
					// Předpokládejme, že timestamp je v sekundách od Unix epoch (UTC)
					DateTime utcDateTime = DateTimeOffset.FromUnixTimeSeconds(timestamp).UtcDateTime;

					// Převést na Pražský čas
					DateTime pragueDateTime = TimeZoneInfo.ConvertTimeFromUtc(utcDateTime, pragueTimeZone);
					convertedTimes.Add(pragueDateTime.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture));
				}

				return Ok(convertedTimes);
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}
	}
}