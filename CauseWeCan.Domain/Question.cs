#region copyright
// CauseWeCan.Domain - Question.cs
// Copyright (c) 2022 All Rights Reserved
// Ihor Lazarenko, Indy developer
#endregion

namespace CauseWeCan.Domain;

public class Question
{
    public string Text { get; set; }
    public IList<Answer> Answers{ get; set; }

}