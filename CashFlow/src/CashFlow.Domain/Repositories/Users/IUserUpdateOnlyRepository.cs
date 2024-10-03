﻿namespace CashFlow.Domain.Repositories.Users
{
    public interface IUserUpdateOnlyRepository
    {
        Task<Entities.User> GetById(long id);
        void Update(Entities.User user);
    }
}
