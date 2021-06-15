using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	private static GameManager instance;
	public static GameManager Instance
	{
		get
		{
			if (instance == null)
			{
				instance = new GameManager();
			}

			return instance;
		}
	}
	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else if (instance != this)
		{
			Destroy(gameObject);
		}

		DontDestroyOnLoad(gameObject);
	}

	[SerializeField] private float slowMotionTimeScale;
	[SerializeField] private GameObject levelWonUI;


	private int levelIndex = 0;

	private void Start()
	{
		levelWonUI.SetActive(false);
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.R))
		{
			ReloadLevel();
		}

		if (Input.GetMouseButtonDown(1))
		{
			Time.timeScale = slowMotionTimeScale;
		}

		if (Input.GetMouseButtonUp(1))
		{
			Time.timeScale = 1f;
		}
	}

	public static void ReloadLevel()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void LevelWon()
	{
		levelWonUI.SetActive(true);
	}

	public void LoadNextLevel()
	{
		levelIndex++;
		SceneManager.LoadSceneAsync(levelIndex);
	}
}
