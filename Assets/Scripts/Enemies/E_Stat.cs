using UnityEngine;
using System.Collections;

public class E_Stat : MonoBehaviour {

    [SerializeField]
    float currHealth;
    [SerializeField]
    float maxHealth;

    


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

   
    public void TakeDamage(float _dam)
    {
        currHealth -= _dam;

        if (currHealth <= 0)
            gameObject.SendMessage("Death");
        
    }
}
