using UnityEngine;
using System.Collections;

public class E_Stat : MonoBehaviour {

    [SerializeField]
    float currHealth;
    [SerializeField]
    float maxHealth;

    //varibles for the visual feedback when the enemy takes damage
    Color baseColor;
    bool changeColor;
    float delayColorChanger;


    // Use this for initialization
    void Start () {
        //save the color of the enemy at start and have a bool set to false
        baseColor = gameObject.GetComponent<SpriteRenderer>().color;
        changeColor = false;
        delayColorChanger = 0.0f;
    }
	
	// Update is called once per frame
	void Update () {
        //  if enemy took damage  
        if (changeColor == true)
        {
            //start the delaytimer and change the enemy's color to red
            delayColorChanger += Time.deltaTime;
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, 0, 0);

            //after the color is red change the color back to its normal color
            //and change the bool back to false
            if (delayColorChanger >= 0.1f)
            {
                gameObject.GetComponent<SpriteRenderer>().color = baseColor;
                delayColorChanger = 0.0f;
                changeColor = false;
            }
        }
        if (currHealth <= 0)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.grey;
        }
    }

   
    public void TakeDamage(float _dam)
    {
        currHealth -= _dam;
        changeColor = true;

        if (currHealth <= 0)
        {
            gameObject.SendMessage("Death");
            Vector3 scale = transform.localScale;
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z - 90);
            transform.localScale = scale;
            GetComponent<BoxCollider2D>().enabled = false;
        }
        
    }
}
