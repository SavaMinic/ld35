﻿using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

	public Player player;

	private Vector3 initialOffset;

	public float speed;

	void Start ()
	{
		initialOffset = transform.position - player.transform.position;
	}
	
	void Update ()
	{
		var target = new Vector3(player.transform.position.x + initialOffset.x, transform.position.y, transform.position.z);
		transform.position = Vector3.Lerp(transform.position, target, speed * Time.deltaTime);
	}
}
