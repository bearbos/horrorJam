using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {

	int attackComboLength;
	float comboInputTimer;
	bool inAttackAnimation, facingRight, objectInHand;
	public GameObject attackColliderPrefab;
	GameObject usableObject;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (!facingRight)
			this.GetComponent<Animator>().transform.localScale = new Vector3 (-1.0f, 1.0f, 1.0f);
		else
			this.GetComponent<Animator>().transform.localScale = new Vector3 (1.0f, 1.0f, 1.0f);

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
			facingRight = false;
			GetComponentInChildren<Transform> ().localScale = new Vector3 (-1.0f, 1.0f, 1.0f);
		} 
		else if (testInputX > 0.0f) {
			facingRight = true;
			GetComponentInChildren<Transform>().localScale = new Vector3 (-1.0f, 1.0f, 1.0f);
		}

		if (inAttackAnimation && facingRight)
			this.GetComponent<Rigidbody2D> ().velocity = new Vector2 (1.0f, 0.0f);
		else if (inAttackAnimation && !facingRight)
			this.GetComponent<Rigidbody2D> ().velocity = new Vector2 (-1.0f, 0.0f);
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
		if (aT && !objectInHand) {
			if (attackComboLength == 0)
			{
				this.GetComponent<Animator> ().SetTrigger ("ComboPunchOne");
				CreateAttackCollider(GetComponent<playerStats>().baseDamage, facingRight);
			}
			else if (attackComboLength == 1)
			{
				this.GetComponent<Animator>().SetTrigger("ComboPunchTwo");
				CreateAttackCollider(GetComponent<playerStats>().baseDamage, facingRight);
			}
			else if (attackComboLength == 2)
			{
				this.GetComponent<Animator>().SetTrigger("ComboPunchThree");
				CreateAttackCollider(GetComponent<playerStats>().baseDamage, facingRight);
			}
		} else if (!aT && !objectInHand) {
			if (attackComboLength == 0)
			{
				this.GetComponent<Animator>().SetTrigger("ComboKickOne");
				CreateAttackCollider(GetComponent<playerStats>().baseDamage, facingRight);
			}
			else if (attackComboLength == 1)
			{
				this.GetComponent<Animator>().SetTrigger("ComboKickTwo");
				CreateAttackCollider(GetComponent<playerStats>().baseDamage * 1.5f, facingRight);
			}
			else if (attackComboLength == 2)
			{
				this.GetComponent<Animator>().SetTrigger("ComboKickThree");
				CreateAttackCollider(GetComponent<playerStats>().baseDamage, facingRight);
				CreateAttackCollider(GetComponent<playerStats>().baseDamage, !facingRight);
			}
		}

		if (aT && objectInHand) {
			if (attackComboLength == 0)
			{
				this.GetComponent<Animator>().SetTrigger ("SwordWeaponOne");
				CreateAttackCollider(GetComponent<playerStats>().baseDamage, facingRight);
			}
			else if (attackComboLength >= 1)
			{
				this.GetComponent<Animator>().SetTrigger("SwordWeaponTwo");
				CreateAttackCollider(GetComponent<playerStats>().baseDamage, facingRight);
			}
		}

		comboInputTimer = 0.7f;
		++attackComboLength;
		inAttackAnimation = true;
	}

	/// <summary>
	/// Animations the end and ends combo tracker.
	/// </summary>
	public void AnimationEnd()
	{
		inAttackAnimation = false;
	}

	/// <summary>
	/// Creates the attack collider.
	/// </summary>
	void CreateAttackCollider(float damage, bool direction)
	{
		attackColliderPrefab.GetComponent<attackCollider> ().dmg = GetComponent<playerStats> ().baseDamage;
		attackColliderPrefab.GetComponent<attackCollider> ().moveDirection = direction;
		Instantiate (attackColliderPrefab, this.transform.position, Quaternion.identity);
	}

	/// <summary>
	/// Pickups the item.
	/// </summary>
	void PickupItem()
	{

	}

	/// <summary>
	/// Drops the item.
	/// </summary>
	void DropItem()
	{

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
		if (coll.CompareTag ("Pickup") && usableObject == coll.gameObject) {
			usableObject = null;
		}
	}
}
