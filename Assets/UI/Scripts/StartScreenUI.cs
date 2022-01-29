using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreenUI : MonoBehaviour
{
    [SerializeField] private GameObject startScreen;

    void Start()
    {
        startScreen.SetActive(true);
    }
    public void OnStartClicked()
    {
        startScreen.SetActive(false);
        GameManager.Instance.OnStartGame?.Invoke();
    }
}
