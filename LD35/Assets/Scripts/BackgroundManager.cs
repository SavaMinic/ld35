using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BackgroundManager : MonoBehaviour
{
	public Transform mainCamera;

	public Vector3 distanceVector;
	public Vector3 moveVector;

	private List<GameObject> backSprites;
	
	void Start ()
	{
		backSprites = new List<GameObject>();
		for(int i = 0; i < transform.childCount; i++)
		{
			backSprites.Add(transform.GetChild(i).gameObject);
		}
	}
	
	
	void Update ()
	{
		var first = backSprites[0];
		var distance = mainCamera.position - first.transform.position;
		if (distance.x >= distanceVector.x)
		{
			backSprites.RemoveAt(0);
			backSprites.Add(first);
			first.transform.position += moveVector;
		}
	}
}
