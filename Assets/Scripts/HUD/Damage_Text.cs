using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Damage_Text : MonoBehaviour {

    string damageText;
    float textDecay = 0.0f;
    Color startColor;
    Color endColor;

	// Use this for initialization
	void Start ()
    {
        startColor = new Color(1, 1, 1, 1);
        endColor = startColor;
	}
	
	// Update is called once per frame
	void Update ()
    {
        textDecay += Time.deltaTime;
        endColor.b -= Time.deltaTime;
        endColor.g -= (Time.deltaTime * 0.5f);
        gameObject.GetComponent<TextMesh>().color = endColor;

        Vector3 newPos = gameObject.transform.position;
        newPos.y += Time.deltaTime;
        gameObject.transform.position = newPos;

        if (textDecay >= 1.0f)
        {
            Destroy(gameObject);
        }
	}

    public void SetDamageText(int _damage)
    {
        damageText = _damage.ToString();
        gameObject.GetComponent<TextMesh>().text = damageText;

        Vector3 newPos = gameObject.transform.position;
        newPos.y += 2;
        gameObject.transform.position = newPos;
    }
}
