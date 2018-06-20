using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayScores : MonoBehaviour 
{
	public Text[] highscoreText;
	LeaderboardSettings highscoreManager;

	void Start () 
	{
		for (int i = 0; i < highscoreText.Length; i++) 
		{
			highscoreText [i].text = i + 1 + ". Fetching...";
		}

		highscoreManager = GetComponent<LeaderboardSettings> ();

		StartCoroutine ("RefreshHighscores");
	}

	public void OnHighscoresDownloaded(HighScore[] highscoreList)
	{
		for (int i = 0; i < highscoreText.Length; i++) 
		{
			highscoreText [i].text = i + 1 + ". ";

			if (highscoreList.Length > i) 
			{
				highscoreText [i].text += highscoreList [i].username + " - " + highscoreList [i].score;
			}
		}
	}

	IEnumerator RefreshHighscores()
	{
		while (true) 
		{
			highscoreManager.DownloadScores ();
			yield return new WaitForSeconds (30);
		}
	}
	

}
