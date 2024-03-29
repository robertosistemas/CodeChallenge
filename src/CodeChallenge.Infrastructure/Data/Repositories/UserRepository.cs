﻿using CodeChallenge.Domain.Abstractions;
using CodeChallenge.Domain.Abstractions.Repositories;
using CodeChallenge.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeChallenge.Infrastructure.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        protected readonly IDatabaseContext DatabaseContext;

        public UserRepository(IDatabaseContext databaseContext) => DatabaseContext = databaseContext;

        public async Task<Guid> AddAsync(UserModel user)
        {
            var users = await DatabaseContext.GetDataAsync();
            user.Id = Guid.NewGuid();
            users.Add(user);
            await DatabaseContext.UpdateDataAsync(users);
            return user.Id;
        }

        public async Task UpdateAsync(Guid id, UserModel user)
        {
            var users = await DatabaseContext.GetDataAsync();
            var userMached = users.FirstOrDefault(f => f.Id.Equals(id));
            if (userMached != null)
            {
                users[users.IndexOf(userMached)] = user;
                await DatabaseContext.UpdateDataAsync(users);
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            var users = await DatabaseContext.GetDataAsync();
            users.RemoveAll(f => f.Id.Equals(id));
            await DatabaseContext.UpdateDataAsync(users);
        }

        public async Task<UserModel?> GetAsync(Guid id)
        {
            var users = await DatabaseContext.GetDataAsync();
            return users.FirstOrDefault(f => f.Id.Equals(id));
        }

        public async Task<(List<UserModel> Itens, int TotalCount)> GetAllAsync(UserPagedModel userPaged)
        {
            var users = await DatabaseContext.GetDataAsync();

            if (!string.IsNullOrWhiteSpace(userPaged.Region))
                users = users.Where(f => f.Location.Region == userPaged.Region).ToList();

            if (!string.IsNullOrWhiteSpace(userPaged.Type))
                users = users.Where(f => string.Compare(f.Type, userPaged.Type, true) == 0).ToList();

            var skip = (userPaged.PageNumber - 1) * userPaged.PageSize;
            var itensPaged = users.Skip(skip).Take(userPaged.PageSize).ToList();
            return (itensPaged, users.Count);
        }
    }
}