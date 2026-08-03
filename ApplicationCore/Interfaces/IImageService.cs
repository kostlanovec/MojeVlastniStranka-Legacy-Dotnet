using MojeVlastniStranka.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting; // IWebHostEnvironment
using Microsoft.EntityFrameworkCore;
using MojeVlastniStranka.ApplicationCore.Dto;
using MojeVlastniStranka.DataAccess;

namespace MojeVlastniStranka.ApplicationCore.Interfaces
{
    public interface IImageService
    {
		Task<string> UploadImageAsync(IFormFile file, string subfolder);
		Task DeleteFileAsync(string? relativeUrl);
		Task UploadGalleryImageAsync(MojeVlastniStranka.ApplicationCore.Requests.AddImageRequest request);
		Task<List<ImageDto>> GetImagesAsync();
		Task UpdateImageDescriptionAsync(int imageId, string newDescription);
		Task DeleteImageAsync(int imageId);
    }
}
