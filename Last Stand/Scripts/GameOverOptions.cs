using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverOptions : MonoBehaviour 
{
	// variables
	public int FinalScore;							// Player Final Score
	public GameObject ScoreDisplay;					// Display for Final Score
	public AudioSource BGSound;						// Background Sound
	public GameObject HelperText;					// Any Key Label
	public GameObject LBoardPanel;					// Form Box
	public string PlayerName;						// Holds Player Name
	[SerializeField] public InputField NameInput;	// Gets Player Name
	public GameObject EnterButton;					// Enter Button
	public GameObject MainMenuButton;				// Main Menu Button
	public GameObject Status;						// Status Confirmation

    public Texture2D cursTexture;
    public CursorMode cursMode = CursorMode.Auto;
    public Vector2 Spot = Vector2.zero;
	// Leaderboard Stuff
	const string privateCode = "nEqw9BhJ4UCl-3fxvebfLQkxg40IxfC0yCYwaaRu5-ow";
	const string publicCode = "5ad80755d6024519e0d10009";
	const string webURL = "http://dreamlo.com/lb/";

	// [AWAKE]
	void Awake()
	{
		// Display Final Score
		FinalScore = GlobalScore.CurrentScore;
		ScoreDisplay.GetComponent<Text> ().text = "Score: " + FinalScore;
		//HelperText.GetComponent<Animation> ().Play ();


	}

	// [UPDATE]
	void Update()
	{
		if (Input.anyKey) 
		{
            
			//Cursor.visible = true;
            Cursor.SetCursor(cursTexture,Spot,cursMode);
			LBLoad ();
		}
	}

	// [LBLOAD]
	void LBLoad()
	{
		// Show Cursor

		Cursor.visible = true;

		// Stop Music
		BGSound.Stop();

		// Stop Helper Animation
		HelperText.GetComponent<Animator>().enabled = false;

		// Show Window
		LBoardPanel.SetActive(true);
	}

	// [GETPLAYERNAME]
	public void GetPlayerName()
	{

		// Get Player Info
		PlayerName = NameInput.text;

		// Debug Get Name
		//Debug.Log ("You Entered: " + PlayerName);

		// Change Button to Go to Main Menu
		EnterButton.SetActive(false);
		MainMenuButton.SetActive (true);
	}

	// [SENDSCORE]
	public void SendScore()
	{
		AddNewScore (PlayerName, FinalScore);
	}

	// [ADDNEWSCORE]
	public void AddNewScore(string username, int score)
	{
		StartCoroutine (UploadNewScore(username,score));
	}



	// [UPLOADNEWSCORE]
	IEnumerator UploadNewScore(string username, int score)
	{
		WWW www = new WWW (webURL + privateCode + "/add/" + WWW.EscapeURL (username) + "/" + score);
		yield return www;

		Status.SetActive(true);

		if(string.IsNullOrEmpty(www.error))
		{
			Status.GetComponent<Text> ().text = "Uploaded Successfully";
			print ("Upload Successful");
		}else{
			Status.GetComponent<Text> ().text = "Upload Failed";
			print("Error Uploading: " + www.error);
		}
	}



	// [SETTONORMAL] - Set Things Back to Normal Before Leaving Scene
	public void SetToNormal()
	{
		BGSound.Play ();
		HelperText.GetComponent<Animator>().enabled = true;
		LBoardPanel.SetActive (false);
		EnterButton.SetActive (true);
		MainMenuButton.SetActive (false);
		Status.SetActive (false);
		FinalScore = 0;
	}

	// [MAINMENUEXIT] - Go to Main Menu
	public void MainMenuExit () 
	{
		// Set Things Back To Normal
		SetToNormal();

		SceneManager.LoadScene (0);
	}
}
