using UnityEngine;
using System.Collections;

public class playerStats : MonoBehaviour {

    public float baseDamage, damageModifier, maxHealth, currHealth, adrenaline, timer, notoriety, timeMulti, damageMulti;
	float adrenalineFalloffRate, adrenalineFalloffTime, superSayainDuration;
	public int score, candy;
	public bool superSayain;

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


		if (superSayainDuration > 0.0f) {
			superSayainDuration -= Time.deltaTime;
		} else if (superSayainDuration < 0.0f) {
			superSayainDuration = 0.0f;
			superSayain = false;
		}
	}

	public float TotalDamageDealt()
	{
		float damageTotal = baseDamage + damageModifier;

		return damageTotal;
	}

	public void IncreaseAdrenaline()
	{
		if (!superSayain) {
			adrenaline += 2;

			if (adrenaline > 100.0f)
				adrenaline = 100.0f;

			if (adrenaline == 100.0f) {
				superSayain = true;
				superSayainDuration = 10.0f;
			} else
				adrenalineFalloffTime = 2.5f;
		}
	}

	public void TakeDamage(float damage)
	{

	}
}
