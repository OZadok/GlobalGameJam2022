using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioEvent swap;
    [SerializeField] private AudioEvent post;
    [SerializeField] private AudioEvent giveMoney;
    [SerializeField] private AudioEvent takeMoney;
    
    void Start()
    {
        GameManager.Instance.OnPlayerSwap += OnPlayerSwap;
        GameManager.Instance.OnPosterPost += OnPosterPost;
        GameManager.Instance.OnGiveMoney += OnGiveMoney;
        GameManager.Instance.OnTakeAwayMoney += OnTakeAwayMoney;
    }

    private void OnTakeAwayMoney()
    {
        takeMoney.PlatUISound();
    }

    private void OnGiveMoney()
    {
        giveMoney.PlatUISound();
    }

    private void OnPosterPost(Poster arg0)
    {
        post.PlatUISound();
    }

    private void OnPlayerSwap()
    {
        swap.PlatUISound();
    }
}
