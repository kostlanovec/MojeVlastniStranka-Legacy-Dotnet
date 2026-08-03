using MojeVlastniStranka.ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using MojeVlastniStranka.Common.Models;
using MojeVlastniStranka.ApplicationCore.Dto.Blog;
using MojeVlastniStranka.ApplicationCore.Requests;
using MojeVlastniStranka.DataAccess;
using MojeVlastniStranka.DataAccess.Entities;

namespace MojeVlastniStranka.ApplicationCore.Interfaces
{
    public interface IBlogService
    {
		Task<ResponseViewModel> AddBlogPost(BlogPostRequest blogPostRequest);
		Task<List<BlogCategoryWithPostsDto>> GetAllCategoriesWithPosts();
		Task<List<BlogCategoryWithPostsDto>> GetAllCategoriesPostsWitFourNewerPosts();
		Task<List<BlogPostSummary>> GetFourNewerPosts();
		Task<List<BlogPostSummary>> GetAllBlogPost();
		Task<List<BlogPostSummary>> GetAllProject();
		Task<List<BlogPostSummary>> GetThreePost();
		Task<EditBlogPostDto?> GetBlogPostById(Guid id);
		Task<List<BlogCategoryDto>> GetAllCategoriesTask();
		Task<ResponseViewModel> UpdateBlogPost(EditBlogPostRequest editBlogPostRequest);
		Task<ResponseViewModel> AddBlogCategory(string CategoryNameAdd);
		Task<ResponseViewModel> DeleteBlogCategory(Guid BlogCategoryId);
		Task<ResponseViewModel> DeleteBlogPost(Guid BlogId);
		Task<List<BlogPostSummary>> GetFilteredBlogPosts(string searchString, string author, string keyword, Guid category, DateTime? fromDate, DateTime? toDate);
		Task<List<BlogPostSummary>> SearchBlogPostsAsync(string query);
    }
}
