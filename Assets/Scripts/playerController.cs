﻿using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {

	int attackComboLength;
	bool inAttackAnimation;

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

		if (!inAttackAnimation) {
			if (Input.GetAxis ("Horizontal") != 0.0f)
				testInputX = Input.GetAxis ("Horizontal");

			if (Input.GetAxis ("Vertical") != 0.0f)
				testInputY = Input.GetAxis ("Vertical");
		}

		this.GetComponent<Rigidbody2D> ().velocity = new Vector2 (3.0f * testInputX, 2.0f * testInputY);

		///////////////////////////// Attacking /////////////////////////////
		/// 
		if (Input.GetButtonDown ("X"))
			ComboManager(true);
		   
		if (Input.GetButtonDown ("Y"))
			ComboManager(false);


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


	/// <summary>
	/// Combos will be stored, played, and executed by this function.
	/// </summary>
	/// <param name="aT">If set to <c>true</c> the attack type is a punch, else it is a kick.</param>
	void ComboManager(bool aT)
	{
		if (aT) {
			if (attackComboLength == 0)
				this.GetComponent<Animator> ().SetTrigger ("ComboPunchOne");
			else if (attackComboLength == 1)
				this.GetComponent<Animator>().SetTrigger("ComboPunchTwo");
			else if (attackComboLength == 2)
				this.GetComponent<Animator>().SetTrigger("ComboPunchThree");
		} else {
			if (attackComboLength == 0)
				this.GetComponent<Animator>().SetTrigger("ComboKickOne");
			else if (attackComboLength == 1)
				this.GetComponent<Animator>().SetTrigger("ComboKickTwo");
		}

		++attackComboLength;
		inAttackAnimation = true;
	}

	public void AnimationEnd()
	{
		inAttackAnimation = false;
		attackComboLength = 0;
	}
}
