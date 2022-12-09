#region copyright
// CauseWeCan.Domain - Answer.cs
// Copyright (c) 2022 All Rights Reserved
// Ihor Lazarenko, Indy developer
#endregion

namespace CauseWeCan.Domain;

public class Answer
{
    public Question Question { get; set; }
    public string Text { get; set; }
}