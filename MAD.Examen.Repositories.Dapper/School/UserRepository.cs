﻿using Dapper;
using MAD.Examen.Models;
using MAD.Examen.Repositories.School;
using System.Data.SqlClient;

namespace MAD.Examen.Repositories.Dapper.School
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(string connectionString) : base(connectionString)
        {
        }

        public User ValidaterUser(string email, string password)
        {

            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@email", email);
                parameters.Add("@password", password);

                return connection.QueryFirstOrDefault<User>("dbo.ValidateUser",
                parameters,
                commandType: System.Data.CommandType.StoredProcedure);

            }

        }
    }
}
