using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreClass
{
    public int value { get; private set; } = 0;

    public ScoreClass()
    {
        value = 0;
    }

    public void Add(int amount = 1)
    {
        this.value += amount;
    }

    public void Reset()
    {
        this.value = 0;
    }
}
