using UnityEngine;
using System.Collections;

public class Warning_range : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            if (coll.gameObject.GetComponent<e_StateMachine>())
            {
                if (coll.gameObject.GetComponent<e_StateMachine>().eAggro)
                {

                }
                else
                    coll.gameObject.SendMessage("SetGuard");
            }
        }
    }
}
