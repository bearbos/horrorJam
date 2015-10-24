using UnityEngine;
using System.Collections;

public class playerStats : MonoBehaviour {

    public float baseDamage, damageModifier, maxHealth, currHealth, adrenaline, timer, notoriety, timeMulti, damageMulti,pressure;
	public int score, candy;

	// Use this for initialization
	void Start () {
		baseDamage = 20.0f;
        timeMulti = 1.0f;
	}
	
	// Update is called once per frame
	void Update () {
        damageModifier = 20.0f * damageMulti;
        timer -= (Time.deltaTime * timeMulti);
        if(pressure >= 1)
        {
            if (notoriety < 5)
                notoriety += 1;
            pressure = 0;
        }
	}

	public float TotalDamageDealt()
	{
		float damageTotal = baseDamage + damageModifier;

		return damageTotal;
	}
}
