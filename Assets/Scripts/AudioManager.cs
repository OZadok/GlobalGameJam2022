using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioEvent swap;
    [SerializeField] private AudioEvent post;
    
    void Start()
    {
        GameManager.Instance.OnPlayerSwap += OnPlayerSwap;
        GameManager.Instance.OnPosterPost += OnPosterPost;
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
