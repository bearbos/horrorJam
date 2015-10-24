using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {

	int attackComboLength;
	bool inAttackAnimation, facingRight;
	public GameObject attackColliderPrefab;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (!facingRight)
			this.GetComponent<Animator>().transform.localScale = new Vector3 (-1.0f, 1.0f, 1.0f);
		else
			this.GetComponent<Animator>().transform.localScale = new Vector3 (1.0f, 1.0f, 1.0f);
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

		if (testInputX < 0.0f)
			facingRight = false;
		else if (testInputX > 0.0f)
			facingRight = true;

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
			{
				this.GetComponent<Animator> ().SetTrigger ("ComboPunchOne");
				CreateAttackCollider(GetComponent<playerStats>().baseDamage);
			}
			else if (attackComboLength == 1)
			{
				this.GetComponent<Animator>().SetTrigger("ComboPunchTwo");
				CreateAttackCollider(GetComponent<playerStats>().baseDamage);
			}
			else if (attackComboLength == 2)
			{
				this.GetComponent<Animator>().SetTrigger("ComboPunchThree");
				CreateAttackCollider(GetComponent<playerStats>().baseDamage);
			}
		} else {
			if (attackComboLength == 0)
			{
				this.GetComponent<Animator>().SetTrigger("ComboKickOne");
				CreateAttackCollider(GetComponent<playerStats>().baseDamage);
			}
			else if (attackComboLength == 1)
			{
				this.GetComponent<Animator>().SetTrigger("ComboKickTwo");
				CreateAttackCollider(GetComponent<playerStats>().baseDamage * 1.5f);
			}
		}

		++attackComboLength;
		inAttackAnimation = true;
	}

	/// <summary>
	/// Animations the end and ends combo tracker.
	/// </summary>
	public void AnimationEnd()
	{
		inAttackAnimation = false;
		attackComboLength = 0;
	}

	/// <summary>
	/// Creates the attack collider.
	/// </summary>
	void CreateAttackCollider(float damage)
	{
		attackColliderPrefab.GetComponent<attackCollider> ().dmg = GetComponent<playerStats> ().baseDamage;
		attackColliderPrefab.GetComponent<attackCollider> ().moveDirection = facingRight;
		Instantiate (attackColliderPrefab, this.transform.position, Quaternion.identity);
	}
}
