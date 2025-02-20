using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Select : MonoBehaviour
{
    Text text;

    private void Awake()
    {
        text = GetComponentInChildren<Text>();
    }
    public void OnEnter()
    {
        text.fontSize = 80;
    }
    public void OnLeave()
    {
        text.fontSize = 70; 
    }
    public void OnSelect()
    {
        text.fontSize = 50;    
    }
}
