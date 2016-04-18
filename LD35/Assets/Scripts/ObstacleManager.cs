using UnityEngine;
using System.Collections;

public class ObstacleManager : MonoBehaviour
{

	public static int NumberOfObstacles = 0;

	#region Editor

	//public float spawnTime;

	public float distanceFromPlayer;
	public Player playerPosition;
	public float yOffset;

	public GameObject rockPrefab;
	public GameObject carrotsPrefab;
	public GameObject cloversPrefab;

	#endregion

	#region Fields

	private float startTime;
	private UIManager ui;

	#endregion

	protected void Start()
	{
		ui = FindObjectOfType<UIManager>();
		StartCoroutine(DoSomething());
	}

	public void NewGame()
	{
		startTime = Time.time;
		var obstacles = FindObjectsOfType<Obstacle>();
		for(int i = 0; i < obstacles.Length; i++)
		{
			Destroy(obstacles[i].gameObject);
		}
	}

	IEnumerator DoSomething()
	{
		while (true)
		{
			yield return new WaitForSeconds(GetSpawnTime());
			if (ui.IsPlaying)
			{
				var position = new Vector3(playerPosition.transform.position.x + distanceFromPlayer, playerPosition.laneYPosition[Random.Range(0, 3)] + yOffset, 0f);
				GameObject prefab = rockPrefab;
				int chance = Random.Range(0, 4);
				switch (chance)
				{
					case 1: prefab = carrotsPrefab; break;
					case 2: prefab = cloversPrefab; break;
					default: prefab = rockPrefab; break;
				}
				var obstacle = Instantiate(prefab, position, Quaternion.identity) as Obstacle;
				if (obstacle != null)
				{
					obstacle.transform.SetParent(transform);
				}
			}
		}
	}

	private float GetSpawnTime()
	{
		var t = Time.time - startTime;
		if (t < 5) return 1.8f;
		if (t < 15) return 1.2f;
		if (t < 30) return 0.9f;
		if (t < 60) return 0.6f;
		return 0.4f;
	}

}
