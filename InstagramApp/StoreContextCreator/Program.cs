using Constants;
using DataBase.Contexts;

namespace StoreContextCreator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var store = AccountName.__Store_Travel_Feb_2018;
            var name = "__" + store.ToString("G") + "_User";

            var context = new SportContext(); // Bot

            var command = string.Format(
                    @"USE [systemdo_systemdoc]

                    SET ANSI_NULLS ON

                    SET QUOTED_IDENTIFIER ON

                    CREATE TABLE [dbo].[{0}](
	                    [Id] [bigint] IDENTITY(1,1) NOT NULL,
	                    [Link] [nvarchar](max) NULL,
	                    [ConfirmedByAdmin] [bit] NOT NULL,
	                    [FriendsWereSearched] [bit] NOT NULL,
	                    [UserStatus] [int] NOT NULL,
	                    [RegionId] [bigint] NULL,
	                    [LanguageId] [bigint] NULL,
	                    [IncludingTime] [datetime] NULL,
                     CONSTRAINT [PK_dbo.{0}] PRIMARY KEY CLUSTERED 
                    (
	                    [Id] ASC
                    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
                    ) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]",
                name);

            context.Database.ExecuteSqlCommand(command);

            context.SaveChanges();
        }
    }
}
