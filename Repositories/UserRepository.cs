﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using XAML_LoginForm.Models;

namespace XAML_LoginForm.Repositories
{
    public class UserRepository : RepositoryBase, IUserRepository
    {
        public void Add(UserModel userModel)
        {
            throw new NotImplementedException();
        }

        public bool AuthenicateUser(NetworkCredential credential)
        {
            bool validate;
            using SqlConnection connection = GetConnection();
            using (SqlCommand command = new SqlCommand()) 
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM [Users] WHERE Username = @Username AND Password = @Password";
                command.Parameters.Add("@Username", SqlDbType.NVarChar).Value = credential.UserName;
                command.Parameters.Add("@Password", SqlDbType.NVarChar).Value = credential.Password;
                validate = command.ExecuteScalar() == null ? false : true;
            }
            return validate;
        }

        public void Edit(UserModel userModel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserModel> GetByAll()
        {
            throw new NotImplementedException();
        }

        public UserModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public UserModel GetByUsername(string username)
        {
            UserModel? userModel = null;
            using SqlConnection connection = GetConnection();
            using (SqlCommand command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM [Users] WHERE Username = @Username";
                command.Parameters.Add("@Username", SqlDbType.NVarChar).Value = username;
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read()) 
                    {
                        userModel = new UserModel()
                        {
                            ID = reader["ID"]?.ToString() ?? "",
                            Username = reader["Username"]?.ToString() ?? "",
                            Password = string.Empty,
                            Name = reader["Name"]?.ToString() ?? "",
                            LastName = reader["LastName"]?.ToString() ?? "",
                            Email = reader["Email"]?.ToString() ?? "",
                            PhoneNumber = reader["PhoneNumber"]?.ToString() ?? ""
                        };
                    }
                }
            }
            return userModel;
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
