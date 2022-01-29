using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskScript : MonoBehaviour
{
    private PlayerScript player;
    public FamilyType family;
    Renderer renderer; 
    void Start()
    {
    }

    private void Awake()
    {
        player = GameManager.Instance.player;
        if (player != null)
        {
            player.RegisterMask(this);
        }
        renderer = GetComponent<Renderer>();
    }

    public void SetMask(bool state) {
        this.renderer.enabled = state;
    }


}
