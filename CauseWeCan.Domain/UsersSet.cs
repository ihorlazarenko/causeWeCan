#region copyright
// CauseWeCan.Domain - UsersSet.cs
// Copyright (c) 2022 All Rights Reserved
// Ihor Lazarenko, Indy developer
#endregion

using System.Linq.Expressions;

namespace CauseWeCan.Domain;

public abstract class UsersSet
{
    protected abstract Task<User?> GetTelegramUser(int telegramUserId);

    protected abstract Task AddUser(User user);

    public async Task<User> GetOrAddTelegramUser(int telegramUserId, string fullName)
    {
        var user = await GetTelegramUser(telegramUserId);
        if (user == null)
        {
            user = new User
            {
                FullName = fullName,
                TelegramId = telegramUserId
            };
            await AddUser(user);
        }
        return user;
    }

    protected abstract Task<IList<User>> GetUsers(Expression<Func<User,bool>> predicate);

    public async Task<IList<User>> GetNotActiveUsers(TimeSpan timeNotActive)
    {
        var lastActiveTime = DateTime.UtcNow.Subtract(timeNotActive);
        return await GetUsers(u=>u.LastActivity<lastActiveTime);
    }
}