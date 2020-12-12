using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DisOrientedProgramming.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DisOrientedProgramming.Data
{
    public class ForumPostConfiguration : IEntityTypeConfiguration<ForumPost>
    {
        public void Configure(EntityTypeBuilder<ForumPost> builder)
        {
            //TODO -- need to come back and set up the AppUser and Forum Topic 
            builder.ToTable("ForumPost");
            builder.HasData
            (
                new ForumPost
                {
                    ForumPostId = Guid.NewGuid(),
                    PostTitle = "Test post #1",
                    PostText = "This is the best form post!"
                }
            );
        }
    }
}
