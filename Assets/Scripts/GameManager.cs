using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static GameManager instance;
    public bool isGameOver;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Use this for initialization
    void Start () {
        isGameOver = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void StartGame() {
        UiManager.instance.GameStart();
        ScoreManager.instance.StartScore();
        GameObject.Find("PlatformSpawner").GetComponent<PlatformSpawner>().StartSpawningPlatforms(); 

    }

    public void GameOver() {
        UiManager.instance.GameOver();
        ScoreManager.instance.StopScore();
        isGameOver = true;
    }

}
