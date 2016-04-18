using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour
{
	public float deathDistance;

	public GameObject onHitParticlePrefab;

	private Transform cameraPosition;

	protected void Start()
	{
		++ObstacleManager.NumberOfObstacles;

		cameraPosition = FindObjectOfType<Camera>().transform.parent;
	}

	protected void OnDestroy()
	{
		--ObstacleManager.NumberOfObstacles;
	}

	protected void Update()
	{
		float diff = cameraPosition.position.x - transform.position.x;
		if (diff > deathDistance)
		{
			Destroy(gameObject);
		}
	}

	public void OnHit()
	{
		if (onHitParticlePrefab != null)
		{
			var particle = (Instantiate(onHitParticlePrefab, transform.position, Quaternion.identity) as GameObject).GetComponent<ParticleSystem>();
			if (particle != null)
			{
				particle.Play();
			}
		}
		Destroy(gameObject);
	}

}
