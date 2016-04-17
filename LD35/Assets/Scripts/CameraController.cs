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
		transform.position = Vector3.Lerp(transform.position, player.transform.position + initialOffset, speed * Time.deltaTime);
	}
}
