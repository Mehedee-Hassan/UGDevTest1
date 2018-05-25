using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UiManager : MonoBehaviour {



	public static UiManager instance;
	public GameObject zigzagPanel;
	public GameObject gameOverPanel;
	public Text score;
	public Text highscore1;
	public Text highscore2;
	public GameObject tapText;
    public GameObject realTimeScorePanel;
    public Text rScore;


	void Awake(){
		if (instance == null) {
			instance = this;
		}
	}


	// Use this for initialization
	void Start () {
        highscore1.text = "HighScore " + PlayerPrefs.GetInt("HIGH_SCORE").ToString();
    }

	public void GameStart(){
        
        tapText.SetActive (false);
        realTimeScorePanel.SetActive(true);

        zigzagPanel.GetComponent<Animator> ().Play ("panelup");

        
    }
	public void GameOver(){
	
		gameOverPanel.SetActive (true);
        realTimeScorePanel.SetActive(false);
        score.text = PlayerPrefs.GetInt("SCORE").ToString();
        highscore2.text = PlayerPrefs.GetInt("HIGH_SCORE").ToString();
    }
	
	// Update is called once per frame

	void Update () {
        string tempScore = ScoreManager.realTimeScore > 9 ? ScoreManager.realTimeScore.ToString() : "0" + ScoreManager.realTimeScore.ToString();

        rScore.text = tempScore;
    }


	public void Reset(){
		SceneManager.LoadScene(0);
	}

}
