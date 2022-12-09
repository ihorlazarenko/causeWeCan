#region copyright
// CauseWeCan.Domain - User.cs
// Copyright (c) 2022 All Rights Reserved
// Ihor Lazarenko, Indy developer
#endregion

namespace CauseWeCan.Domain;

public class User
{
    public int UserId { get; set; }
    public string FullName { get; set; } = default!;
    public int TelegramId { get; set; }
    public DateTime? LastActivity { get; set; }
    public bool IsRemoved { get; set; }
    public void MadeSomeAction()
    {
        LastActivity = DateTime.UtcNow;
    }
    public void AddNotification(string text, DateTime eventDate)
    {

    }

}