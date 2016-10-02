﻿using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using DataBase.Contexts;
using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Queries.Functionality
{
    public class GetFunctionalityToRunQueryHandler : IQueryHandler<GetFunctionalityToRunQuery, FunctionalityWithTokenModel>
    {
        private readonly DataBaseContext context;

        public GetFunctionalityToRunQueryHandler(DataBaseContext context)
        {
            this.context = context;
        }

        public FunctionalityWithTokenModel Handle(GetFunctionalityToRunQuery query)
        {
            var token = Guid.NewGuid();
            var now = DateTime.Now;

            var functionalities = context.Functionalities.ToList()
                .Where(model => model.Token == null || model.LastApplied + model.ExpectingTime < now)
                .OrderBy(model => model.LastApplied + model.ApplyInterval)
                .ToList();

            var functionality = functionalities.FirstOrDefault();

            functionality.LastApplied = now;
            functionality.Token = token;

            context.Functionalities.AddOrUpdate(functionality);
            context.SaveChanges();

            return new FunctionalityWithTokenModel
            {
                FunctionalityName = functionality.FunctionalityNumber,
                Token = token
            };
        }
    }
}
