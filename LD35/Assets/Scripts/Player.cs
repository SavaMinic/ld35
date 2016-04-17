using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

	public float acceleration;

	public float maxSpeed;

	public float Speed { get; private set; }

	public float VerticalSpeed { get; private set; }

	public float jumpPower;

	public float gravity;

	private float initialHeight;

	void Start ()
	{
		initialHeight = transform.position.y;
	}
	
	void Update ()
	{
		

		Vector3 target = transform.position;

		Speed = Mathf.Min(Speed + acceleration * Time.deltaTime, maxSpeed);
		target = Vector3.Lerp(target, target + Vector3.right * Speed, Time.deltaTime);

		transform.position = target;
	}
}
