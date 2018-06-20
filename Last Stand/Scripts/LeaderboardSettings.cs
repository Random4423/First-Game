using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LeaderboardSettings : MonoBehaviour 
{

	// Variables
	const string privateCode = "nEqw9BhJ4UCl-3fxvebfLQkxg40IxfC0yCYwaaRu5-ow";
	const string publicCode = "5ad80755d6024519e0d10009";
	const string webURL = "http://dreamlo.com/lb/";

	public HighScore[] highscoresList;

	DisplayScores highscoresDisplay;

	void Awake()
	{
		highscoresDisplay = GetComponent<DisplayScores> ();
	}


	// Use This to Loop Animation
	void ZombieAnim ()
	{
		
	}


	public void DownloadScores()
	{
		StartCoroutine ("DownloadHighScores");
	}

	IEnumerator DownloadHighScores()
	{
		WWW www = new WWW (webURL + publicCode + "/pipe/");
		yield return www;



		if(string.IsNullOrEmpty(www.error))
		{
			FormatHighScores (www.text);
			highscoresDisplay.OnHighscoresDownloaded (highscoresList);
		}else{
			
			print("Error Downloading: " + www.error);
		}
	}

	void FormatHighScores(string textStream)
	{
		string[] entries = textStream.Split (new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);

		highscoresList = new HighScore[entries.Length];

		for (int i = 0; i < entries.Length; i++) 
		{
			string[] entryInfo = entries[i].Split(new char[] {'|'});
			string username = entryInfo [0];
			int score = int.Parse(entryInfo [1]);
			highscoresList [i] = new HighScore (username, score);
			print (highscoresList [i].username + ": " + highscoresList [i].score);
		}
	}




	public void MainMenuGo()
	{
		SceneManager.LoadScene (0);
	}
}

public struct HighScore
{
	public string username;
	public int score;

	public HighScore(string _username, int _score)
	{
		username = _username;
		score = _score;
	}
}