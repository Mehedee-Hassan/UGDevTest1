using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

	public static ScoreManager instance;
	public int score;
	public int highScore;
    public static int realTimeScore;

	void Awake(){
	
		if (instance == null) {
			instance = this;
		}
	}


	// Use this for initialization
	void Start () {
		score = 0;
		PlayerPrefs.SetInt ("SCORE",score);
	}
	
	// Update is called once per frame
	void Update () {
        realTimeScore = score;
    }


	void IncrementScore(){
		score += 1;
        realTimeScore = score;
	}

    public void IncrementScoreByTwo()
    {
        score += 2;
        realTimeScore = score;
    }

    public void StartScore(){
		InvokeRepeating ("IncrementScore", 0.1f,0.5f);
	}

    public void StopScore(){
		CancelInvoke ("IncrementScore");
		PlayerPrefs.SetInt ("SCORE",score);

		if (PlayerPrefs.HasKey ("HIGH_SCORE")) {
			if (PlayerPrefs.GetInt ("HIGH_SCORE") < score) {
				PlayerPrefs.SetInt ("HIGH_SCORE", score); 
			} 
			
		}
        else
        {
            PlayerPrefs.SetInt("HIGH_SCORE", score);
        }

    }

}
