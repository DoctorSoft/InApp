using System;
using System.Collections.Generic;
using Constants;
using DataBase.Contexts;
using DataBase.Models;

namespace DataBase.DefaultData
{
    public static class DefaultFunctionalityFiller
    {
        public static void FillDefaultFunctionlity(DataBaseContext context)
        {
            context.Functionalities.RemoveRange(context.Functionalities);
            var lastApplied = DateTime.Now - TimeSpan.FromDays(30);
            var functionalities = new List<FunctionalityDbModel>
            {
                new FunctionalityDbModel
                {
                    LastApplied = lastApplied,
                    FunctionalityName = FunctionalityName.FollowUsers.ToString("G"),
                    FunctionalityNumber = FunctionalityName.FollowUsers,
                    Token = null,
                    ApplyInterval = TimeSpan.FromSeconds(30),
                    ExpectingTime = TimeSpan.FromMinutes(5),
                },
                new FunctionalityDbModel
                {
                    LastApplied = lastApplied,
                    FunctionalityName = FunctionalityName.ClearOldMedia.ToString("G"),
                    FunctionalityNumber = FunctionalityName.ClearOldMedia,
                    Token = null,
                    ApplyInterval = TimeSpan.FromSeconds(30),
                    ExpectingTime = TimeSpan.FromMinutes(5)
                },
                new FunctionalityDbModel
                {
                    LastApplied = lastApplied,
                    FunctionalityName = FunctionalityName.LikeMedias.ToString("G"),
                    FunctionalityNumber = FunctionalityName.LikeMedias,
                    Token = null,
                    ApplyInterval = TimeSpan.FromSeconds(30),
                    ExpectingTime = TimeSpan.FromMinutes(5)
                },
                new FunctionalityDbModel
                {
                    LastApplied = lastApplied,
                    FunctionalityName = FunctionalityName.SaveMediaByHashTag.ToString("G"),
                    FunctionalityNumber = FunctionalityName.SaveMediaByHashTag,
                    Token = null,
                    ApplyInterval = TimeSpan.FromMinutes(30),
                    ExpectingTime = TimeSpan.FromMinutes(10)
                },
                new FunctionalityDbModel
                {
                    LastApplied = lastApplied,
                    FunctionalityName = FunctionalityName.SaveMediaByHomePage.ToString("G"),
                    FunctionalityNumber = FunctionalityName.SaveMediaByHomePage,
                    Token = null,
                    ApplyInterval = TimeSpan.FromMinutes(30),
                    ExpectingTime = TimeSpan.FromMinutes(10)
                },
                new FunctionalityDbModel
                {
                    LastApplied = lastApplied,
                    FunctionalityName = FunctionalityName.SearchNewUsers.ToString("G"),
                    FunctionalityNumber = FunctionalityName.SearchNewUsers,
                    Token = null,
                    ApplyInterval = TimeSpan.FromHours(12),
                    ExpectingTime = TimeSpan.FromMinutes(10)
                },
                new FunctionalityDbModel
                {
                    LastApplied = lastApplied,
                    FunctionalityName = FunctionalityName.SearchUselessUsers.ToString("G"),
                    FunctionalityNumber = FunctionalityName.SearchUselessUsers,
                    Token = null,
                    ApplyInterval = TimeSpan.FromHours(12),
                    ExpectingTime = TimeSpan.FromHours(2)
                },
                new FunctionalityDbModel
                {
                    LastApplied = lastApplied,
                    FunctionalityName = FunctionalityName.UnfollowUsers.ToString("G"),
                    FunctionalityNumber = FunctionalityName.UnfollowUsers,
                    Token = null,
                    ApplyInterval = TimeSpan.FromSeconds(30),
                    ExpectingTime = TimeSpan.FromMinutes(5)
                },
                new FunctionalityDbModel
                {
                    LastApplied = lastApplied,
                    FunctionalityName = FunctionalityName.AddComments.ToString("G"),
                    FunctionalityNumber = FunctionalityName.AddComments,
                    Token = null,
                    ApplyInterval = TimeSpan.FromHours(1),
                    ExpectingTime = TimeSpan.FromMinutes(10)
                },
                new FunctionalityDbModel
                {
                    LastApplied = lastApplied,
                    FunctionalityName = FunctionalityName.AddActivityHistoryMark.ToString("G"),
                    FunctionalityNumber = FunctionalityName.AddActivityHistoryMark,
                    Token = null,
                    ApplyInterval = TimeSpan.FromHours(3),
                    ExpectingTime = TimeSpan.FromHours(1)
                }
            };
            context.Functionalities.AddRange(functionalities);
        }
    }
}
