using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace DotNet.Infrastructure.Persistence
{
    public static class MultipleResultSets
    {
        public static MultipleResultSetWrapper MultipleResults(this DbContext db, string sqlQuery)
        {
            return new MultipleResultSetWrapper(db, sqlQuery);
        }

        public class MultipleResultSetWrapper(DbContext db, string sqlQuery)
        {
            private readonly DbContext _db = db;
            private readonly string _sqlQuery = sqlQuery;
            public List<Func<IObjectContextAdapter, DbDataReader, IEnumerable>> _resultSets = [];

            public MultipleResultSetWrapper With<TResult>()
            {
                _resultSets.Add((adapter, reader) => adapter
                    .ObjectContext
                    .Translate<TResult>(reader)
                    .ToList());

                return this;
            }

            public List<IEnumerable> Execute()
            {
                var results = new List<IEnumerable>();

                using var connection = _db.Database.GetDbConnection();
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = _sqlQuery;

                using (var reader = command.ExecuteReader())
                {
                    var adapter = (IObjectContextAdapter)_db;
                    foreach (var resultSet in _resultSets)
                    {
                        results.Add(resultSet(adapter, reader));
                        reader.NextResult();
                    }
                }
                return results;
            }
        }
    }
}
