using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

	public enum GameState
	{
		Start,
		Playing,
		Death,
	}

	public Text score;
	public Image[] lives;

	public RectTransform startPane;
	public RectTransform normalPane;
	public RectTransform deathPane;

	public GameState State = GameState.Start;
	public bool IsPlaying { get { return State == GameState.Playing; } }

	protected void Update()
	{
		if (State == GameState.Start || State == GameState.Death)
		{
			if (Input.GetKeyUp(KeyCode.Space))
			{
				FindObjectOfType<Player>().NewGame();
				FindObjectOfType<ObstacleManager>().NewGame();

				State = GameState.Playing;
				startPane.gameObject.SetActive(false);
				deathPane.gameObject.SetActive(false);
			}
		}
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Application.Quit();
        }
	}

	public void ResetLifes()
	{
		for (int i = 0; i < lives.Length; ++i) lives[i].CrossFadeAlpha(1f, 0f, false);
	}

	public void DecreaseLife(int i)
	{
		if (i < 0) return;
		lives[i].CrossFadeAlpha(0f, 1f, false);
		if (i == 0)
		{
			State = GameState.Death;
			deathPane.gameObject.SetActive(true);
		}
	}

	public void SetScore(int i)
	{
		score.text = i.ToString();
	}
	
}
