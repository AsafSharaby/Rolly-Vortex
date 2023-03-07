using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
	public static GameHandler instance;

	[SerializeField] private GameObject gameOverPanel;
	[SerializeField] private GameObject mainGamePanel;
	[SerializeField] private GameObject gamePanel;

	[SerializeField] private Text scoreText;
	[SerializeField] private Text gemText;
	[SerializeField] private Text GOscoreText;

	private float score = 0;

	[HideInInspector] public bool gameStarted = false;
	[HideInInspector] public int gemCounter = 0;

	private void Awake()
	{
		if (instance == null)
			instance = this;
	}
	private void Update()
	{
		if(gameStarted)
			score += 1 * Time.deltaTime;

		scoreText.text = (int)score + "";
		gemText.text = (int)gemCounter + "";
	}

	public void GameOverPanel()
	{
		gameOverPanel.SetActive(true);
		gameStarted = false;
		GOscoreText.text = "SCORE:" +(int)score;
	}

	public void StartButton()
	{
		gameStarted = true;
		mainGamePanel.SetActive(false);
		gamePanel.SetActive(true);
		FindObjectOfType<PlayerController>().enabled = true;

	}

	public void ReturnHomeButton()
	{
		SceneManager.LoadScene(0);
	}

	public void RestartButton()
	{
		FindObjectOfType<PlayerController>().transform.position = new Vector3(0, 0, -21);
		FindObjectOfType<PlayerController>().speed = 15;
		FindObjectOfType<CameraFollow>().transform.position = new Vector3(0, 0, -30);
		score = 0;

		gameOverPanel.SetActive(false);
		gamePanel.SetActive(true);
		gameStarted = true;
	}
}

