#region copyright
// CauseWeCan.Domain - Notification.cs
// Copyright (c) 2022 All Rights Reserved
// Ihor Lazarenko, Indy developer
#endregion

namespace CauseWeCan.Domain;

public class Notification
{
    public User User { get; set; }
    public string Text { get; set; }
    public DateTime EventDate { get; set; }

}