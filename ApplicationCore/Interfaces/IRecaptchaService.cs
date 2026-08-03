using MojeVlastniStranka.ApplicationCore.Interfaces;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Configuration;

namespace MojeVlastniStranka.ApplicationCore.Interfaces
{
    public interface IRecaptchaService
    {
		Task<bool> VerifyAsync(string token);
    }
}
