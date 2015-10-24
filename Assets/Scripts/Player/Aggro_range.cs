using UnityEngine;
using System.Collections;

public class Aggro_range : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            if (coll.gameObject.GetComponent<e_StateMachine>())
            {
                coll.gameObject.SendMessage("SetAggro");
                coll.gameObject.GetComponent<e_StateMachine>().eGuard = false;
            }
        }
    }
}
