using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour {


	[SerializeField]
	private float speed;
	bool started;
	Rigidbody rb;
	bool gameOver;




	void Awake(){
		rb = GetComponent<Rigidbody> (); 

	
	}

	// Use this for initialization
	void Start () {

		started = false;
		gameOver = false;

		//	rb.velocity = new Vector3 (speed, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {

		if (!started) {
			if (Input.GetMouseButtonDown (0)) {
				rb.velocity = new Vector3 (speed, 0, 0);
				started = true;
			}
		}

		Debug.DrawRay (transform.position,Vector3.down,Color.red);

		if (!Physics.Raycast (transform.position, Vector3.down, 1f)) {
			gameOver = true;
			rb.velocity = new Vector3(0 , -20 , 0);
		}
		if (Input.GetMouseButtonDown (0) && !gameOver) {
			SwitchDirection();
		}
	}


	void SwitchDirection(){
		if (rb.velocity.z > 0) {
			rb.velocity = new Vector3 (speed, 0, 0);
		} else if (rb.velocity.x > 0) {
			rb.velocity = new Vector3 (0, 0 , speed);
		}
	}

}
