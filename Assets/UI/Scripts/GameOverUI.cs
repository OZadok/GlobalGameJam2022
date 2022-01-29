using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public void OnPlayAgain()
    {
        SceneManager.LoadScene(0);
    }
}
