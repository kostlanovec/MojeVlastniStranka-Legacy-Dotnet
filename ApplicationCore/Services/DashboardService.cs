using MojeVlastniStranka.ApplicationCore.Dto;
using MojeVlastniStranka.ApplicationCore.Requests;
using MojeVlastniStranka.DataAccess.Entities;
using MojeVlastniStranka.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MojeVlastniStranka.ApplicationCore.Services
{
    public class DashboardService
    {
        private readonly DataContext context;

        public DashboardService(DataContext context)
        {
            this.context = context;
        }

        public async Task<int> NumberOfContactForms()
        {
            return await context.ContactForms.CountAsync();
        }

        public async Task<int> NumberOfBlogPosts()
        {
            return await context.BlogPosts.CountAsync();
        }


    }
}
