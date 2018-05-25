using UnityEngine;
using System.Collections;

public class PlatformSpawner : MonoBehaviour {


	public GameObject platform;
	public GameObject diamond;

	Vector3 lastPos;
	float size;
	public bool gameOver;
	// Use this for initialization
	void Start () {
		lastPos = platform.transform.position;
		size = platform.transform.localScale.x;


		for (int i =0; i < 20; i++) {
			SpawnPlatforms();
		}

	}


    public void StartSpawningPlatforms() {
        InvokeRepeating("SpawnPlatforms", 2f, 0.2f);
    }


    // Update is called once per frame
    void Update () {
		if (GameManager.instance.isGameOver == true) {
            CancelInvoke("SpawnPlatforms");
		}

	}


	void SpawnPlatforms(){

		if (GameManager.instance.isGameOver == true) {
			return;
		}


		int random = Random.Range (0,6);

		if (random < 3) {
			SpawnX ();
		} else {
			SpawnZ ();
		}
	
	}


	void SpawnX(){
	
		Vector3 pos = lastPos;
		pos.x += size;
		lastPos = pos;

		Instantiate (platform, pos, Quaternion.identity);


		int rand = Random.Range (0, 5);
		if (rand < 1) {
			Vector3 tempPos = new Vector3(pos.x,pos.y+ 1.3f,pos.z);
			Instantiate (diamond,tempPos,diamond.transform.rotation);
		}


	}

	void SpawnZ(){

		
		Vector3 pos = lastPos;
		pos.z += size;
		lastPos = pos;
		
		Instantiate (platform, pos, Quaternion.identity);

		int rand = Random.Range (0, 5);
		if (rand < 1) {
			Vector3 tempPos = new Vector3(pos.x,pos.y + 1.3f,pos.z);

			Instantiate (diamond,tempPos,diamond.transform.rotation);
		}
		

	}



}
