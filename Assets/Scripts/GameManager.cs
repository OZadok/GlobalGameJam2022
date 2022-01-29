using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("References")] 
    [SerializeField] private Poster posterPrefab;
    [SerializeField] private Poster posterTypeLucasPrefab;
    [SerializeField] private Poster posterTypeMarcoPrefab;

    public SalaryTimer SalaryTimer;
    
    [Header("Parameters")]
    public LayerMask blockViewMask;
    public List<Postable> Postables { get; set; }
    
    public Dictionary<FamilyType, FamilyBoss> FamilyBossDictionary;

    public PlayerScript player; 

    public UnityAction<Poster> OnPosterPost;
    public UnityAction OnEndOfPeriod;
    public UnityAction<float> OnTotalMoneyChanged;
    public UnityAction<float> OnDebtChanged;

    public UnityAction OnPlayerSwap;
    public UnityAction OnTakeAwayMoney;
    public UnityAction OnGiveMoney;

    private void Awake()
    {
        Instance = this;
        Postables = new List<Postable>();

        FamilyBossDictionary = new Dictionary<FamilyType, FamilyBoss>
        {
            { FamilyType.Lucas, new FamilyBoss() },
            { FamilyType.Marco, new FamilyBoss() }
        };

        if (SalaryTimer == null)
        {
            SalaryTimer = GetComponent<SalaryTimer>();
        }

        if (player == null) {
            player = FindObjectOfType<PlayerScript>();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
    }

    public void RegisterPostable(Postable postable)
    {
        Postables.Add(postable);
    }

    public Poster GetPosterOfType(FamilyType type)
    {
        return type switch
        {
            FamilyType.Lucas => Instantiate(posterTypeLucasPrefab),
            FamilyType.Marco => Instantiate(posterTypeMarcoPrefab),
            _ => Instantiate(posterPrefab)
        };
    }
}
