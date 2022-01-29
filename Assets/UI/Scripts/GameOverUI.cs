using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen;
    // Start is called before the first frame update
    void Start()
    {
        gameOverScreen.SetActive(false);
        GameManager.Instance.OnGameOver += OnGameOver;
    }

    private void OnGameOver()
    {
        gameOverScreen.SetActive(true);
    }
}
