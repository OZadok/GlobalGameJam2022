using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("References")] 
    [SerializeField] private Poster posterPrefab;
    
    [Header("Parameters")]
    public LayerMask blockViewMask;
    public List<Postable> Postables { get; set; }

    public UnityAction<Poster> OnPosterPost;

    private void Awake()
    {
        Instance = this;
        Postables = new List<Postable>();
    }

    public void RegisterPostable(Postable postable)
    {
        Postables.Add(postable);
    }

    public Poster GetPosterOfType(FamilyType type)
    {
        var poster = Instantiate(posterPrefab);
        return poster;
    }
}
