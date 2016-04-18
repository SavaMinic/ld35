using UnityEngine;
using System.Collections;

public class ObstacleManager : MonoBehaviour
{

	public static int NumberOfObstacles = 0;

	#region Editor

	public float spawnTime;
	public float distanceFromPlayer;
	public Player playerPosition;
	public float yOffset;

	public GameObject rockPrefab;

	#endregion

	#region Fields

	#endregion

	protected void Start()
	{
		StartCoroutine(DoSomething());
	}

	IEnumerator DoSomething()
	{
		while (true)
		{
			yield return new WaitForSeconds(spawnTime);
			var position = new Vector3(playerPosition.transform.position.x + distanceFromPlayer, playerPosition.laneYPosition[Random.Range(0, 3)] + yOffset, 0f);
			var rock = Instantiate(rockPrefab, position, Quaternion.identity) as Obstacle;
			if (rock != null)
			{
				rock.transform.SetParent(transform);
			}
		}
	}

}
