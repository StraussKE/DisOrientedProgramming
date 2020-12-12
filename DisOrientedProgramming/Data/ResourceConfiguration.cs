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
                //new ResourceLink
                //{
                //    ResourceLinkId = Guid.NewGuid(),
                //    ResourceName = "Google",
                //    ResourceType = "test",
                //    Address = new Uri("www.google.com"),
                //    Description = "Search engine!!!!"
                //},
                //new ResourceLink
                //{
                //    ResourceLinkId = Guid.NewGuid(),
                //    ResourceName = "Lane Main",
                //    ResourceType = "test",
                //    Address = new Uri("www.lanecc.edu"),
                //    Description = "LCC home page"
                //},
                new ResourceLink
                {
                    ResourceLinkId = Guid.NewGuid(),
                    ResourceName = "Psychology Today",
                    ResourceType = "Mental Wellness",
                    Address = new Uri("https://www.psychologytoday.com/us")
                },
                new ResourceLink
                {
                    ResourceLinkId = Guid.NewGuid(),
                    ResourceName = "WhiteBird Clinic",
                    ResourceType = "Physical Wellness",
                    Address = new Uri("https://whitebirdclinic.org/")

                },
                new ResourceLink
                {
                    ResourceLinkId = Guid.NewGuid(),
                    ResourceName = "LCC Dental Clinic",
                    ResourceType = "Physical Wellness",
                    Address = new Uri("https://www.lanecc.edu/dentalclinic")
                },
                new ResourceLink
                {
                    ResourceLinkId = Guid.NewGuid(),
                    ResourceName = "Sign up for OHP",
                    ResourceType = "Physical Wellness",
                    Address = new Uri("https://one.oregon.gov/")
                },
                new ResourceLink
                {
                    ResourceLinkId = Guid.NewGuid(),
                    ResourceName = "Hourglass - Columbia Care",
                    ResourceType = "Mental Wellness",
                    Address = new Uri("http://www.columbiacare.org/hourglass-community-crisis-center.html")
                    
                }

            );
    ;

           ;
        }
    }
}
