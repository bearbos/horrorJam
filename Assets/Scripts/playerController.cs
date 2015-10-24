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

		///////////////////////////// Movement /////////////////////////////
		/// 
		float testInputX, testInputY;
		testInputX = testInputY = 0.0f;


		if (Input.GetAxis ("Horizontal") != 0.0f)
			testInputX = Input.GetAxis ("Horizontal");

		if (Input.GetAxis ("Vertical") != 0.0f)
			testInputY = Input.GetAxis ("Vertical");


		this.GetComponent<Rigidbody2D> ().velocity = new Vector2 (3.0f * testInputX, 2.0f * testInputY);

		///////////////////////////// Attacking /////////////////////////////
		/// 
		if (Input.GetButtonDown ("X"))
			;
		   
		if (Input.GetButtonDown ("Y"))
			;


		///////////////////////////// Mask Switching ////////////////////////////
		/// 
		if (Input.GetButtonDown ("Left Bumper"))
			;

		if (Input.GetButtonDown ("Right Bumper"))
			;

		///////////////////////////// Interaction and Menus /////////////////////////////////
		/// 
		if (Input.GetButtonDown ("A"))
			;

		if (Input.GetButtonDown ("B"))
			;

	}
}
