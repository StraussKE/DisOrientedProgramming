using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


using DisOrientedProgramming.Models;

namespace DisOrientedProgramming.Data
{
    public class ResourceConfiguration : IEntityTypeConfiguration<ResourceLink>
    {
        public void Configure(EntityTypeBuilder<ResourceLink> builder)
        {
            builder.ToTable("ResourceLinks");
            builder.HasData
            (
                new ResourceLink
                {
                    ResourceLinkId = Guid.NewGuid(),
                    ResourceName = "Google",
                    ResourceType = "test",
                    Address = new Uri("www.google.com"),
                    Description = "Search engine!!!!"
                },
                new ResourceLink
                {
                    ResourceLinkId = Guid.NewGuid(),
                    ResourceName = "Lane Main",
                    ResourceType = "test",
                    Address = new Uri("www.lanecc.edu"),
                    Description = "LCC home page"
                }
            );
        }
    }
}
