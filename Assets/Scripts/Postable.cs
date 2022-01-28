using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Postable : MonoBehaviour
{
    [SerializeField] private Transform postPositionPoint;

    private void Awake()
    {
        if (postPositionPoint == null)
        {
            postPositionPoint = transform;
        }
    }

    private void Start()
    {
        GameManager.Instance.RegisterPostable(this);
    }

    public void Post(Poster poster)
    {
        poster.transform.position = GetPostPosition();
        GameManager.Instance.OnPosterPost?.Invoke(poster);
    }

    public Vector3 GetPostPosition()
    {
        return postPositionPoint.transform.position;
    }
    
    
}
