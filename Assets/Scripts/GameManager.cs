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
    [SerializeField] private Poster posterTypeAPrefab;
    [SerializeField] private Poster posterTypeBPrefab;
    
    [Header("Parameters")]
    public LayerMask blockViewMask;
    public List<Postable> Postables { get; set; }
    
    public Dictionary<FamilyType, FamilyBoss> FamilyBossDictionary;

    public UnityAction<Poster> OnPosterPost;

    private void Awake()
    {
        Instance = this;
        Postables = new List<Postable>();
    }

    private void Start()
    {
        FamilyBossDictionary = new Dictionary<FamilyType, FamilyBoss>();
        FamilyBossDictionary.Add(FamilyType.A, new FamilyBoss());
        FamilyBossDictionary.Add(FamilyType.B, new FamilyBoss());
    }

    public void RegisterPostable(Postable postable)
    {
        Postables.Add(postable);
    }

    public Poster GetPosterOfType(FamilyType type)
    {
        return type switch
        {
            FamilyType.A => Instantiate(posterTypeAPrefab),
            FamilyType.B => Instantiate(posterTypeBPrefab),
            _ => Instantiate(posterPrefab)
        };
    }
}
