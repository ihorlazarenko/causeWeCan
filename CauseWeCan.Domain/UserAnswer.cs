#region copyright
// CauseWeCan.Domain - UserAnswer.cs
// Copyright (c) 2022 All Rights Reserved
// Ihor Lazarenko, Indy developer
#endregion

namespace CauseWeCan.Domain;

public class UserAnswer
{
    public Question Question { get; set; }
    public User User { get; set; }
    public string? Text { get; set; }
    public Answer? AnswerVariant { get; set; }

}