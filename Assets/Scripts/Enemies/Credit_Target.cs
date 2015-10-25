using UnityEngine;
using System.Collections;

public class Credit_Target : MonoBehaviour {

    float hitPoints = 1;
    Color yellow = new Color(1, 1, 0, 1);
    bool spin = false;
    bool scored = false;

    float spinTimer = 0.0f;
    bool reset = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        

        if(spinTimer >= 2.0f && reset)
        {
            Quaternion newrotation = new Quaternion(0, 0, 0, 0);
            gameObject.transform.rotation = newrotation;
            reset = false;
        }
        else if (hitPoints < 0.0f)
        {
            gameObject.GetComponent<TextMesh>().color = yellow;
        }

        if(spin && reset)
        {
            gameObject.transform.Rotate(new Vector3(1, 0, 0), (Time.deltaTime * 180));
            spinTimer += Time.deltaTime;

            if (!scored)
            {
                //GameObject temp = GameObject.FindWithTag("CreditScoreMarker");
                //temp.GetComponent<Credits_Score>().AddScore();
                scored = true;
            }
        }
    }

    public void TakeDamage(float _dmg)
    {
        hitPoints -= _dmg;
        spin = true;
    }

}
