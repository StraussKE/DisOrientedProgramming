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
                    Desc = "The rules for the forum"
                },
                new ForumTopic
                {
                    ForumTopicId = Guid.NewGuid(),
                    Name = "Introductions",
                    Desc = "Introduce yourself!"
                },
                new ForumTopic
                {
                    ForumTopicId = Guid.NewGuid(),
                    Name = "social",
                    Desc = "Come Hangout with People!"
                },
                new ForumTopic
                {
                    ForumTopicId = Guid.NewGuid(),
                    Name = "Fitness",
                    Desc = "Talk about all things fitness!"
                },
                new ForumTopic
                {
                    ForumTopicId = Guid.NewGuid(),
                    Name = "Getting a Good Night’s Sleep",
                    Desc = "Zzzzzzzz's"
                },
                new ForumTopic
                {
                    ForumTopicId = Guid.NewGuid(),
                    Name = "Meditation",
                    Desc = "Talk about clearing your mind and getting into a better headspace"
                },
                new ForumTopic
                {
                    ForumTopicId = Guid.NewGuid(),
                    Name = "Off-topic",
                    Desc = "Unreatled conversations"
                }

            );
        }
    }
}
