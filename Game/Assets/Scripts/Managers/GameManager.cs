using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private bool state = false;

    public bool State { get { return state; } }

    public void Execute()
    {
        state = true;
    }

    public void Finish()
    {
        state = false;
    }
}
