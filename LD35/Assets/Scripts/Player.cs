using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

	public float acceleration;

	public float maxSpeed;

	public float Speed { get; private set; }

	void Start ()
	{
	
	}
	
	void Update ()
	{

		Speed += acceleration * Time.deltaTime;
		Speed = Mathf.Min(Speed, maxSpeed);

		//transform.position += Vector3.right * Speed * Time.deltaTime;
		transform.position = Vector3.Lerp(transform.position, transform.position + Vector3.right, Speed * Time.deltaTime);

		if(Input.GetKeyDown(KeyCode.Space))
		{
			Debug.Log("SPACE");
		}
	}
}
