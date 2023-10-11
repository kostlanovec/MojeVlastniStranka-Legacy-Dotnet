using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using MojeVlastniStranka.ApplicationCore.Dto;
using MojeVlastniStranka.ApplicationCore.Requests;
using MojeVlastniStranka.DataAccess;
using MojeVlastniStranka.DataAccess.Entities;

namespace MojeVlastniStranka.ApplicationCore.Services
{
    public class ImageService
    {
        private readonly DataManagementService dataManagementService;
        private readonly IHostEnvironment environment;
        private readonly DataContext context;

        public ImageService(DataContext context, IHostEnvironment environment)
        {
            this.dataManagementService = new DataManagementService(context);
            this.environment = environment;
            this.context = context;
        }

        public async Task UploadImageAsync(AddImageRequest addImageRequest)
        {
            // to-do čtení z konfigurace, hard programming
	        var uploadsDirectory = "C:\\app\\MojeVlastniStrankaFinanali\\Web\\wwwroot\\images\\galeriefotky";
			var filePath = Path.Combine(uploadsDirectory, addImageRequest.File.FileName);

            if (!Directory.Exists(uploadsDirectory))
            {
                Directory.CreateDirectory(uploadsDirectory);
            }

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await addImageRequest.File.CopyToAsync(fileStream);
            }

            var image = Image.Create(Path.Combine( addImageRequest.File.FileName), addImageRequest.Description);
            this.context.Images.Add(image);
            await this.context.SaveChangesAsync();
        }

		public async Task<List<ImageDto>> GetImagesAsync()
		{
			return await this.context.Images
				.Select(image => new ImageDto
				{
					Id = image.Id,
					FileName = image.FileName,
					Description = image.Description
				})
				.ToListAsync();
		}

		public async Task UpdateImageDescriptionAsync(int imageId, string newDescription)
        {
	        var image = await this.context.Images.FindAsync(imageId);
	        if (image != null)
	        {
		        image.Description = newDescription;
		        await this.context.SaveChangesAsync();
	        }
        }

        public async Task DeleteImageAsync(int imageId)
        {
	        var image = await this.context.Images.FindAsync(imageId);
	        if (image != null)
	        {
		        this.context.Images.Remove(image);
		        await this.context.SaveChangesAsync();
	        }
        }
	}
}
