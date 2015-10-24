using UnityEngine;
using System.Collections;

public class playerStats : MonoBehaviour {

    public float baseDamage, damageModifier, maxHealth, currHealth, adrenaline, timer, notoriety, timeMulti, damageMulti;
	float adrenalineFalloffRate, adrenalineFalloffTime, superSaiyanDuration;
	public int score, candy;
	public bool superSaiyan;

	// Use this for initialization
	void Start () {
		baseDamage = 20.0f;
        timeMulti = 1.0f;
	}
	
	// Update is called once per frame
	void Update () {
        damageModifier = 20.0f * damageMulti;
        timer -= (Time.deltaTime * timeMulti);

		
		adrenalineFalloffRate = 10.0f * Time.deltaTime;
		if (adrenaline > 0.0f) {
			adrenalineFalloffTime -= Time.deltaTime;

			if (adrenalineFalloffTime <= 0.0f) {
				adrenaline -= adrenalineFalloffRate;
			}
		}

		if (adrenaline < 0.0f)
			adrenaline = 0.0f;


		if (superSaiyanDuration > 0.0f) {
			superSaiyanDuration -= Time.deltaTime;
		} else if (superSaiyanDuration < 0.0f) {
			superSaiyanDuration = 0.0f;
			superSaiyan = false;
		}
	}

	public float TotalDamageDealt()
	{
		float damageTotal = baseDamage + damageModifier;

		return damageTotal;
	}

	public void IncreaseAdrenaline()
	{
		if (!superSaiyan) {
			adrenaline += 2;

			if (adrenaline > 100.0f)
				adrenaline = 100.0f;

			if (adrenaline == 100.0f) {
				superSaiyan = true;
				superSaiyanDuration = 10.0f;
			} else
				adrenalineFalloffTime = 2.5f;
		}
	}

	public void TakeDamage(float damage)
	{

	}
}
