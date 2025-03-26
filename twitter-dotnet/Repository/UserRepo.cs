using System.Data;
using AutoMapper;
using Dapper;
using DotnetAPI.Data;
using DotnetAPI.Dtos;
using DotnetAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotnetAPI.Repository
{
    public class UserRepo
    {
        private readonly DataContextDapper _dapper;
        public UserRepo(IConfiguration config)
        {
            _dapper = new DataContextDapper(config);
        }
        public IEnumerable<User> GetUsers(int userId, bool isActive)
        {
            string sql = @"EXEC TutorialAppSchema.spUsers_Get";
            string stringParameters = "";
            DynamicParameters sqlParameters = new DynamicParameters();
            
            if (userId != 0)
            {
                stringParameters += ", @UserId=@UserIdParameter";
                sqlParameters.Add("@UserIdParameter", userId, DbType.Int32 );
            } 
            if (isActive)
            {
                stringParameters += ", @Active=@ActiveParameter";
                sqlParameters.Add("@ActiveParameter", isActive, DbType.Boolean );
            }

            if (stringParameters.Length > 0)
            {
                sql += stringParameters.Substring(1);//, parameters.Length);
            }

            IEnumerable<User> users = _dapper.LoadDataWithParameters<User>(sql, sqlParameters);
            return users;
        }
        public bool UpsertUser(User user)
        {
            string sql = @"EXEC TutorialAppSchema.spUser_Upsert
                @FirstName = @FirstNameParameter, 
                @LastName = @LastNameParameter, 
                @Email = @EmailParameter, 
                @Gender = @GenderParameter, 
                @Active = @ActiveParameter, 
                @JobTitle = @JobTitleParameter, 
                @Department = @DepartmentParameter,
                @Salary = @SalaryParameter, 
                @UserId = @UserIdParameter";

            DynamicParameters sqlParameters = new DynamicParameters();

            sqlParameters.Add("@FirstNameParameter", user.FirstName, DbType.String);
            sqlParameters.Add("@LastNameParameter", user.LastName, DbType.String);
            sqlParameters.Add("@EmailParameter", user.Email, DbType.String);
            sqlParameters.Add("@GenderParameter", user.Gender, DbType.String);
            sqlParameters.Add("@ActiveParameter", user.Active, DbType.Boolean);
            sqlParameters.Add("@JobTitleParameter", user.JobTitle, DbType.String);
            sqlParameters.Add("@DepartmentParameter", user.Department, DbType.String);
            sqlParameters.Add("@SalaryParameter", user.Salary, DbType.Decimal);
            sqlParameters.Add("@UserIdParameter", user.UserId, DbType.Int32);

            return _dapper.ExecuteSqlWithParameters(sql, sqlParameters);
        }
    }
}