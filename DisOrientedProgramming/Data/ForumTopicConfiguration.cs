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
    public class ForumTopicConfiguration : IEntityTypeConfiguration<ForumTopic>
    {
        public void Configure(EntityTypeBuilder<ForumTopic> builder)
        {
            builder.ToTable("ForumTopics");
            builder.HasData
            (
                new ForumTopic
                {
                    ForumTopicId = Guid.NewGuid(),
                    Name = "Rules",
                    Desc = "The rules for the forum",
                    OrderNumber = 1
                },
                new ForumTopic
                {
                    ForumTopicId = Guid.NewGuid(),
                    Name = "Introductions",
                    Desc = "Introduce yourself!",
                    OrderNumber = 2
                },
                new ForumTopic
                {
                    ForumTopicId = Guid.NewGuid(),
                    Name = "social",
                    Desc = "Come Hangout with People!",
                    OrderNumber = 3
                },
                new ForumTopic
                {
                    ForumTopicId = Guid.NewGuid(),
                    Name = "Fitness",
                    Desc = "Talk about all things fitness!",
                    OrderNumber = 5
                },
                new ForumTopic
                {
                    ForumTopicId = Guid.NewGuid(),
                    Name = "Getting a Good Night’s Sleep",
                    Desc = "Zzzzzzzz's",
                    OrderNumber = 6
                },
                new ForumTopic
                {
                    ForumTopicId = Guid.NewGuid(),
                    Name = "Meditation",
                    Desc = "Talk about clearing your mind and getting into a better headspace",
                    OrderNumber = 4
                },
                new ForumTopic
                {
                    ForumTopicId = Guid.NewGuid(),
                    Name = "Off-topic",
                    Desc = "Unreatled conversations",
                    OrderNumber = 7
                }

            );
        }
    }
}
