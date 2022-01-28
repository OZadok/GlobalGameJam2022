using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    public List<Postable> Postables { get; set; }

    private void Awake()
    {
        Instance = this;
    }

    public void RegisterPostable(Postable postable)
    {
        Postables.Add(postable);
    }
}
