using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExtensionsMethods 
{
	public static bool CanSee(this GameObject origin, GameObject target)
	{
		return CanSee(origin.transform, target.transform);
	}
    
	public static bool CanSee(this Transform origin, Transform target)
	{
		var originPosition = origin.position;
		var targetPosition = target.position;
		var diff = -originPosition + targetPosition;
		RaycastHit hit;
		var isHit = Physics.Raycast(originPosition, diff.normalized, out hit, diff.magnitude, GameManager.Instance.blockViewMask);
		return !isHit;
	}
}
