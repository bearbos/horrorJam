using UnityEngine;
using System.Collections;

public enum weaponType {SWORD, FIST, THROWN};

public class weapon : MonoBehaviour {

    public float damage;
	public int price, durability;
    public string description;
	public weaponType weaponType;
	public GameObject anchor;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	void FixedUpdate() {
		
		if (anchor != null) {
			this.transform.position = anchor.transform.position;
			
			if (GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().transform.localScale.x < 0) {
				this.transform.rotation = new Quaternion (anchor.transform.rotation.x, anchor.transform.rotation.y, -anchor.transform.rotation.z, 1.0f);
				this.transform.localScale = new Vector3 (-1.0f, 1.0f, 1.0f);
			}
			else {
				this.transform.rotation = anchor.transform.rotation;
				this.transform.localScale = new Vector3 (1.0f, 1.0f, 1.0f);
			}
		}
	}

	public void PlayerUsed()
	{
		anchor = GameObject.FindGameObjectWithTag ("SwordAnchor");
	}

	public void PlayerDropped()
	{
		anchor = null;
	}

	public void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag ("Enemy") && anchor != null && GameObject.FindGameObjectWithTag("Player").GetComponent<playerController>().inAttackAnimation) {
			other.GetComponent<E_Stat>().TakeDamage( FindObjectOfType<playerStats>().TotalDamageDealt());
		}
	}
}
