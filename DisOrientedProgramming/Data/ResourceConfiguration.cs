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
                    ResourceName = "National Suicide Prevention Lifeline",
                    ResourceType = "Mental Wellness",
                    Address = new Uri("https://www.psychologytoday.com/us"),
                    Description = "24/7, free and confidential support for people in distress, prevention and crisis resources." +
                    " This website can help you find a therapist or support group."
                },
                new ResourceLink
                {
                    ResourceLinkId = Guid.NewGuid(),
                    ResourceName = "Psychology Today",
                    ResourceType = "Mental Wellness",
                    Address = new Uri("https://www.psychologytoday.com/us"),
                    Description = "Free resource to help you connect with mental health professionals in your area." +
                    " You can filter by insurance accepted, gender, types of therapy and more."

                },
                new ResourceLink
                {
                    ResourceLinkId = Guid.NewGuid(),
                    ResourceName = "WhiteBird Clinic",
                    ResourceType = "Physical Wellness",
                    Address = new Uri("https://whitebirdclinic.org/"),
                    Description = "White Bird is a collective environment organized to enable people to gain control of their social, emotional, " +
                    "and physical well-being through direct service, education, and community."

                },
                new ResourceLink
                {
                    ResourceLinkId = Guid.NewGuid(),
                    ResourceName = "LCC Dental Clinic",
                    ResourceType = "Physical Wellness",
                    Address = new Uri("https://www.lanecc.edu/dentalclinic"),
                    Description = "Provide the public with patient-centered, comprehensive, preventive and therapeutic dental care, while at the same time providing practical," +
                    " educational experiences for dental hygiene and dental assisting students. Now accepting OHP"
                },
                new ResourceLink
                {
                    ResourceLinkId = Guid.NewGuid(),
                    ResourceName = "Sign up for OHP",
                    ResourceType = "Physical Wellness",
                    Address = new Uri("https://one.oregon.gov/"),
                    Description = "This website will set up with an account to help gain coverage under Oregon Health Plan and even sign up for food, cash, or childcare benefits."
                },
                new ResourceLink
                {
                    ResourceLinkId = Guid.NewGuid(),
                    ResourceName = "Hourglass - Columbia Care",
                    ResourceType = "Mental Wellness",
                    Address = new Uri("http://www.columbiacare.org/hourglass-community-crisis-center.html"),
                    Description = "Provides a comprehensive approach to helping people suffering from mental illness. They look at the person first then how their circumstances affect them." +
                    " They can help you find treatment, housing and other forms of support."

                }

            );
    ;

           ;
        }
    }
}
