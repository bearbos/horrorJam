using UnityEngine;
using System.Collections;

public class weapon : MonoBehaviour {

    public float damage;
	public int price, durability;
    public string description;
	GameObject anchor;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	void FixedUpdate() {
		
		if (anchor != null) {
			this.transform.position = anchor.transform.position;
			
			if (GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().transform.localScale.x < 0)
				this.transform.rotation = new Quaternion (anchor.transform.rotation.x, anchor.transform.rotation.y, -anchor.transform.rotation.z, 1.0f);
			else
				this.transform.rotation = anchor.transform.rotation;
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
}
