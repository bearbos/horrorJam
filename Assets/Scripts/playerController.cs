using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class playerController : MonoBehaviour {

	int attackComboLength, maxCombo;
	float comboInputTimer;
	public bool inAttackAnimation, facingRight;
	bool objectInHand;
	public GameObject attackColliderPrefab;
	GameObject usableObject, objectBeingUsed;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (!facingRight) {
			this.GetComponent<Animator> ().transform.localScale = new Vector3 (-1.0f, 1.0f, 1.0f);
			this.GetComponent<BoxCollider2D> ().transform.localScale = new Vector3 (- Mathf.Abs (GetComponent<BoxCollider2D> ().transform.localScale.x),
			                                                                       GetComponent<BoxCollider2D> ().transform.localScale.y,
			                                                                       GetComponent<BoxCollider2D> ().transform.localScale.z);
		} else {
			this.GetComponent<Animator> ().transform.localScale = new Vector3 (1.0f, 1.0f, 1.0f);
			this.GetComponent<BoxCollider2D> ().transform.localScale = new Vector3 (Mathf.Abs (GetComponent<BoxCollider2D> ().transform.localScale.x),
			                                                                        GetComponent<BoxCollider2D> ().transform.localScale.y,
			                                                                        GetComponent<BoxCollider2D> ().transform.localScale.z);
		}

		if (attackComboLength > 0) {
			if (comboInputTimer > 0.0f)
				comboInputTimer -= Time.deltaTime;
			else
				attackComboLength = 0;
		}

		transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y);
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

		if (testInputX < 0.0f) {
			comboInputTimer = 0.6f;
			facingRight = false;
			GetComponentInChildren<Transform> ().localScale = new Vector3 (-1.0f, 1.0f, 1.0f);
		} 
		else if (testInputX > 0.0f) {
			comboInputTimer = 0.6f;
			facingRight = true;
			GetComponentInChildren<Transform>().localScale = new Vector3 (-1.0f, 1.0f, 1.0f);
		}

		if ((testInputX > .1f && testInputX < .4f) || (testInputX < -.1f && testInputX > -.4f)) {
			this.GetComponent<Animator> ().SetBool ("Walking", true);
			this.GetComponent<Animator> ().SetBool ("Running", false);
			this.GetComponent<Animator> ().SetBool ("StandingStill", false);
		} else if ((testInputX > .4f && testInputX < 1.1f) || (testInputX < -.4f && testInputX > -1.1f)) {
			this.GetComponent<Animator> ().SetBool ("Running", true);
			this.GetComponent<Animator> ().SetBool ("Walking", false);
			this.GetComponent<Animator> ().SetBool ("StandingStill", false);
		} else {
			this.GetComponent<Animator> ().SetBool ("StandingStill", true);
			this.GetComponent<Animator> ().SetBool ("Running", false);
			this.GetComponent<Animator> ().SetBool ("Walking", false);
		}

		if (inAttackAnimation && facingRight)
			this.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0.5f, 0.0f);
		else if (inAttackAnimation && !facingRight)
			this.GetComponent<Rigidbody2D> ().velocity = new Vector2 (-0.5f, 0.0f);
		else
			this.GetComponent<Rigidbody2D> ().velocity = new Vector2 (5.0f * testInputX, 4.0f * testInputY);

		///////////////////////////// Attacking /////////////////////////////
		/// 
		if (Input.GetButtonDown ("X"))
			ComboManager(true);
		   
		if (Input.GetButtonDown ("Y"))
			ComboManager(false);


		///////////////////////////// Mask Switching ////////////////////////////
		/// 
		if (Input.GetButtonDown ("Left Bumper"))
			GetComponentInChildren<maskController>().ChangeMask(false);

		if (Input.GetButtonDown ("Right Bumper"))
			GetComponentInChildren<maskController>().ChangeMask(true);

		///////////////////////////// Interaction and Menus /////////////////////////////////
		/// 
		if (Input.GetButtonDown ("A") && usableObject != null) {
			objectInHand = true;
			PickupItem();
		}

		if (Input.GetButtonDown ("B") && objectInHand == true) {
			objectInHand = false;
			DropItem();
		}

	}


	/// <summary>
	/// Combos will be stored, played, and executed by this function.
	/// </summary>
	/// <param name="aT">If set to <c>true</c> the attack type is a punch, else it is a kick.</param>
	void ComboManager(bool aT)
	{
        bool validInput = false;

		if (GetComponent<playerStats> ().superSaiyan)
			maxCombo = 5;
		else
			maxCombo = 3;

		
		if (attackComboLength < maxCombo) {
			if (aT 
				&& (!objectInHand || objectBeingUsed.GetComponent<weapon> ().weaponType == weaponType.FIST)) {
				switch (attackComboLength) {
				case 0:
					{
						GetComponent<Animator>().SetTrigger("ComboPunchOne");
                        validInput = true;
						break;
					}
				case 1:
					{
						GetComponent<Animator>().SetTrigger("ComboPunchTwo");
                        validInput = true;
						break;
					}
				case 2:
					{
					GetComponent<Animator>().SetTrigger("ComboPunchThree");
                    validInput = true;
						break;
					}
				case 3:
					{
					GetComponent<Animator>().SetTrigger("ComboPunchFour");
                    validInput = true;
						break;
					}
				case 4:
					{
					GetComponent<Animator>().SetTrigger("ComboPunchFive");
                    validInput = true;
						break;
					}
				default:
					break;
				}
			} 
			else if (!aT && (!objectInHand || usableObject.GetComponent<weapon> ().weaponType == weaponType.FIST)) {
				switch (attackComboLength) {
				case 0:
				{
					GetComponent<Animator>().SetTrigger("ComboKickOne");
                    validInput = true;
					break;
				}
				case 1:
				{
					GetComponent<Animator>().SetTrigger("ComboKickTwo");
                    validInput = true;
					break;
				}
				case 2:
				{
					GetComponent<Animator>().SetTrigger("ComboKickThree");
                    validInput = true;
					break;
				}
				case 3:
				{
					GetComponent<Animator>().SetTrigger("ComboKickFour");
                    validInput = true;
					break;
				}
				case 4:
				{
					GetComponent<Animator>().SetTrigger("ComboKickFive");
                    validInput = true;
					break;
				}
				default:
				{
					break;
				}
				}
			}
		}

		if (aT && (objectInHand && objectBeingUsed.GetComponent<weapon>().weaponType == weaponType.SWORD)) {
			if (attackComboLength == 0)
			{
			this.GetComponent<Animator>().SetTrigger ("SwordWeaponOne");
				//CreateAttackCollider(GetComponent<playerStats>().TotalDamageDealt(), facingRight);
			}
			else if (attackComboLength >= 1)
			{
				this.GetComponent<Animator>().SetTrigger("SwordWeaponTwo");
				//CreateAttackCollider(GetComponent<playerStats>().TotalDamageDealt(), facingRight);
			}
		}

        if (validInput)
        {
            ++attackComboLength;
            comboInputTimer = 0.5f;
        }
	}

	public void AnimationStart()
	{
		inAttackAnimation = true;
	}

	/// <summary>
	/// Animations the end and ends combo tracker.
	/// </summary>
	public void AnimationEnd()
	{
		inAttackAnimation = false;

		if (attackComboLength > maxCombo)
			comboInputTimer = 0.2f;
	}

	/// <summary>
	/// Creates the attack collider.
	/// </summary>
	public void CreateAttackCollider(float numshots)
	{
		attackColliderPrefab.GetComponent<attackCollider> ().dmg = GetComponent<playerStats> ().TotalDamageDealt();
		if (GetComponent<Rigidbody2D> ().transform.localScale.x < 0)
			attackColliderPrefab.GetComponent<attackCollider> ().moveDirection = false;
		else if (GetComponent<Rigidbody2D>().transform.localScale.x > 0)
			attackColliderPrefab.GetComponent<attackCollider> ().moveDirection = true;
		Instantiate (attackColliderPrefab, this.transform.position, Quaternion.identity);

		if (numshots != 0) {
			attackColliderPrefab.GetComponent<attackCollider> ().dmg = GetComponent<playerStats> ().TotalDamageDealt();
			if (GetComponent<Rigidbody2D> ().transform.localScale.x < 0)
				attackColliderPrefab.GetComponent<attackCollider> ().moveDirection = true;
			else if (GetComponent<Rigidbody2D>().transform.localScale.x > 0)
				attackColliderPrefab.GetComponent<attackCollider> ().moveDirection = false;
			Instantiate (attackColliderPrefab, this.transform.position, Quaternion.identity);
		}
	}

	/// <summary>
	/// Pickups the item.
	/// </summary>
	void PickupItem()
	{
		if (usableObject != null && objectBeingUsed == null)
			objectBeingUsed = usableObject;

		objectBeingUsed.SendMessage ("PlayerUsed");
	}

	/// <summary>
	/// Drops the item.
	/// </summary>
	void DropItem()
	{
		if (objectBeingUsed != null)
			objectBeingUsed.SendMessage ("PlayerDropped");

		objectBeingUsed = null;
		objectInHand = false;
	}

	/// <summary>
	/// Raises the trigger enter2 d event.
	/// </summary>
	/// <param name="coll">Coll.</param>
	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.CompareTag ("Pickup")) {
			usableObject = coll.gameObject;
		}
	}

	/// <summary>
	/// Raises the trigger exit2 d event.
	/// </summary>
	/// <param name="coll">Coll.</param>
	void OnTriggerExit2D(Collider2D coll)
	{
		if (coll.CompareTag ("Pickup") && usableObject == coll.gameObject && usableObject.GetComponent<weapon>().anchor != null) {
			usableObject = null;
		}
	}
}
