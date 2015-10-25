using UnityEngine;
using System.Collections;

public enum weaponType {SWORD, FIST, THROWN};

public class weapon : MonoBehaviour {

    public float damage;
	public int price, durability;
    public string description;
	public weaponType weaponType;
	public GameObject anchor, player;
    public Sprite sprite;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (durability < 0) {
			player.SendMessage("DropItem");
		}
	}

	void FixedUpdate() {
		
		if (anchor != null) {
			this.transform.position = anchor.transform.position;
			
			if (player.GetComponent<Animator>().transform.localScale.x < 0) {
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

		player.GetComponent<playerStats> ().damageModifier += damage;
	}

	public void PlayerDropped()
	{
		anchor = null;

		player.GetComponent<playerStats> ().damageModifier -= damage;


		Destroy (this.gameObject);
	}

	public void OnTriggerEnter2D(Collider2D other)
	{
		if (weaponType != weaponType.THROWN){
		if ((other.CompareTag ("Enemy") || other.CompareTag ("Decoration"))
			&& anchor != null && player.GetComponent<playerController> ().inAttackAnimation) {
			other.SendMessage ("TakeDamage", GameObject.FindObjectOfType<playerStats> ().TotalDamageDealt ());
			--durability;
		} else if (other.CompareTag ("Enemy") && anchor == null && player == null) {
			other.SendMessage("TakeDamage", GameObject.FindObjectOfType<playerStats>().TotalDamageDealt());
				Destroy(this.gameObject);
				                  }
		}
	}
}
