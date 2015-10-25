using UnityEngine;
using System.Collections;

public class playerStats : MonoBehaviour {

    public float  damageModifier, maxHealth, currHealth, adrenaline, timer, notoriety, timeMulti, damageMulti;
	float baseDamage, adrenalineFalloffRate, adrenalineFalloffTime, superSaiyanDuration;
	public int score, candy;
	public bool superSaiyan;
	public GameObject childAnimator;

	// Use this for initialization
	void Start () {
		baseDamage = 20.0f;
        timeMulti = 1.0f;
		damageMulti = 1.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (superSaiyan)
			childAnimator.GetComponent<Animator>().SetBool ("superSaiyan", true);
		else
			childAnimator.GetComponent<Animator>().SetBool ("superSaiyan", false);

		GetComponentInChildren<Animator> ().transform.localScale = GetComponent<Animator> ().transform.localScale;

        timer -= (Time.deltaTime * timeMulti);

		if (currHealth > maxHealth)
			currHealth = maxHealth;

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
			damageMulti -= 1.5f;
		}
	}

	public float TotalDamageDealt()
	{
		float damageTotal = (baseDamage + damageModifier) * damageMulti;

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
				damageMulti += 1.5f;
				superSaiyanDuration = 10.0f;
			} else
				adrenalineFalloffTime = 2.5f;
		}
	}

	public void TakeDamage(float damage)
	{

	}
}
