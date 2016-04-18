using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

	#region Editor

	public float speed;
	public float changeSpeed;

	public SpriteRenderer playerSprite;
	public Sprite rabbitSprite;
	public Sprite turtleSprite;

	public ParticleSystem changeParticles;

	public float[] laneYPosition;

	#endregion

	#region Properties/fields

	private bool isRabbit;

	private int currentLane;
	private float targetY;

	private int lives = 3;
	private int score = 0;

	private UIManager ui;

	#endregion

	#region Methods

	void Start ()
	{
		SetLane(1);
		ui = FindObjectOfType<UIManager>();
	}

	
	void Update ()
	{
		if (!ui.IsPlaying) return;

		if (Input.GetKeyDown(KeyCode.Space))
		{
			SwitchChar();
		}
		if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
		{
			GoUp();
		}
		if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
		{
			GoDown();
		}

		Vector3 target = transform.position;

		target = Vector3.Lerp(target, target + Vector3.right, speed * Time.deltaTime);
		target.y = Mathf.Lerp(target.y, targetY, changeSpeed * Time.deltaTime);

		transform.position = target;
	}

	#endregion

	#region Colliders

	void OnTriggerEnter2D(Collider2D other)
	{
		var obstacle = other.gameObject.GetComponent<Obstacle>();
		if (obstacle != null)
		{
			if (obstacle.tag == "Rock")
			{
				ui.DecreaseLife(--lives);
			}
			else if ((isRabbit && obstacle.tag == "Carrot") || (!isRabbit && obstacle.tag == "Clover"))
			{
				ui.SetScore(++score);
			}
			else
			{
				ui.DecreaseLife(--lives);
			}
			obstacle.OnHit();
		}
	}

	#endregion

	#region Movement

	private void GoUp()
	{
		if (currentLane == 0) return;
		SetLane(currentLane - 1);
	}

	private void GoDown()
	{
		if (currentLane == 2) return;
		SetLane(currentLane + 1);
	}

	private void SetLane(int lane)
	{
		currentLane = lane;
		targetY = laneYPosition[currentLane];
	}

	private void SwitchChar()
	{
		isRabbit = !isRabbit;
		playerSprite.sprite = isRabbit ? rabbitSprite : turtleSprite;
		changeParticles.Play(true);
	}

	#endregion
}
