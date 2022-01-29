using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Postable : MonoBehaviour
{
    [SerializeField] private Transform postPositionPoint;
    [SerializeField] private float maxRandomAngle = 10f;
    [SerializeField] private float maxRandomDistance = 0.1f;

    private float addOffset = 0.001f;
    
    public FamilyType FamilyType { get; private set; }

    private int numOfPosters;

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
        FamilyType = FamilyType.None;
    }

    public void Post(Poster poster)
    {
        SetPosterPositionAndRotation(poster);
        FamilyType = poster.Type;
        GameManager.Instance.OnPosterPost?.Invoke(poster);
        numOfPosters++;
    }

    private void SetPosterPositionAndRotation(Poster poster)
    {
        var rotation = postPositionPoint.rotation;
        var positionOffset = rotation * UnityEngine.Random.insideUnitCircle * maxRandomDistance;
        var positionAddOffset = postPositionPoint.forward * (-1f * (numOfPosters + 1) * addOffset);
        Transform posterTransform;
        (posterTransform = poster.transform).position = GetPostPosition() + positionOffset + positionAddOffset;

        posterTransform.rotation = rotation;
        var rotationOffset = UnityEngine.Random.Range(-maxRandomAngle, maxRandomAngle);
        poster.transform.Rotate(Vector3.forward, rotationOffset);
    }

    public Vector3 GetPostPosition()
    {
        return postPositionPoint.transform.position;
    }
    
    
}
