using UnityEngine;
using System.Collections;

public class attackCollider : MonoBehaviour {

	public float dmg, attackRange;
	public bool moveDirection;
	Vector3 startPosition;

	// Use this for initialization
	void Start () {
		startPosition = this.transform.position;
		attackRange = 2.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (Mathf.Abs (transform.position.x - startPosition.x) >= attackRange)
			Destroy (this.gameObject);
	}

	void FixedUpdate() {
		if (moveDirection)
			this.GetComponent<Rigidbody2D> ().velocity = new Vector2 (2.0f, 0.0f);
		else
			this.GetComponent<Rigidbody2D> ().velocity = new Vector2 (-2.0f, 0.0f);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag ("Enemy") || other.CompareTag ("Decoration"))
			other.gameObject.SendMessage ("TakeDamage", 20.0f);
	}
}
