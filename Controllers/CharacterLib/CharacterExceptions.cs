using System;
using System.Collections.Generic;
using System.Text;

public class PlayerDoesNotHaveTalent : Exception
{
    public PlayerDoesNotHaveTalent()
    {
    }

    public PlayerDoesNotHaveTalent(string message)
        : base(message)
    {
    }
}
