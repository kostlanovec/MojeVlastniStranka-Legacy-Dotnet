using MojeVlastniStranka.ApplicationCore.Interfaces;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Configuration;

namespace MojeVlastniStranka.ApplicationCore.Services
{
	public class RecaptchaService : IRecaptchaService
	{
		private readonly HttpClient httpClient;
		private readonly IConfiguration configuration;

		public RecaptchaService(HttpClient httpClient, IConfiguration configuration)
		{
			this.httpClient = httpClient;
			this.configuration = configuration;
		}

		public async Task<bool> VerifyAsync(string token)
		{
			if (string.IsNullOrWhiteSpace(token))
			{
				return false;
			}

			var verifyUrl = configuration["GoogleRecaptcha:VefiyAPIAddress"] ?? "https://www.google.com/recaptcha/api/siteverify";
			var secretKey = configuration["GoogleRecaptcha:Secretkey"];

			if (string.IsNullOrEmpty(secretKey) || secretKey == "YOUR-GOOGLE-SECRETKEY-HERE")
			{
				// In development or when not configured, bypass validation to avoid blocking form submissions
				return true;
			}

			try
			{
				var parameters = new Dictionary<string, string>
				{
					{ "secret", secretKey },
					{ "response", token }
				};

				var content = new FormUrlEncodedContent(parameters);
				var response = await httpClient.PostAsync(verifyUrl, content);

				if (!response.IsSuccessStatusCode)
				{
					return false;
				}

				var jsonString = await response.Content.ReadAsStringAsync();
				var result = JsonSerializer.Deserialize<RecaptchaResponse>(jsonString);

				if (result == null || !result.Success)
				{
					return false;
				}

				// Verify score threshold for reCAPTCHA v3
				var thresholdStr = configuration["RecaptchaThreshold"] ?? "0.5";
				thresholdStr = thresholdStr.Replace(',', '.'); // Handle comma decimal separators
				if (double.TryParse(thresholdStr, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out double threshold))
				{
					return result.Score >= threshold;
				}

				return result.Score >= 0.5;
			}
			catch
			{
				return false;
			}
		}

		private class RecaptchaResponse
		{
			[JsonPropertyName("success")]
			public bool Success { get; set; }

			[JsonPropertyName("score")]
			public double Score { get; set; }

			[JsonPropertyName("action")]
			public string Action { get; set; }

			[JsonPropertyName("challenge_ts")]
			public string ChallengeTs { get; set; }

			[JsonPropertyName("hostname")]
			public string Hostname { get; set; }

			[JsonPropertyName("error-codes")]
			public List<string> ErrorCodes { get; set; }
		}
	}
}
