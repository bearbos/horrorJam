using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate() {
		float testInputX, testInputY;
		testInputX = testInputY = 0.0f;


		if (Input.GetAxis ("Horizontal") != 0.0f)
			testInputX = Input.GetAxis ("Horizontal");

		if (Input.GetAxis ("Vertical") != 0.0f)
			testInputY = Input.GetAxis ("Vertical");


		this.GetComponent<Rigidbody2D> ().velocity = new Vector2 (3.0f * testInputX, 2.0f * testInputY);

		//if (testInputX > 0.0f)
		//	this.GetComponent<Rigidbody2D> ().AddForce(new Vector2 (100.0f, 0.0f));
		//else if (testInputX < 0.0f)
		//	this.GetComponent<Rigidbody2D> ().AddForce(new Vector2 (-100.0f, 0.0f));
		//
		//if (testInputY > 0.0f)
		//	this.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0.0f, 1.0f);
		//else if (testInputY < 0.0f)
		//	this.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0.0f, -1.0f);
	}
}
