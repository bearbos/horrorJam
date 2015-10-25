using UnityEngine;
using System.Collections;

public class Lightning : MonoBehaviour {
    SpriteRenderer theRenderer;
    float opacity = 0.50f;
	// Use this for initialization
	void Start () {
        theRenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        opacity -= 0.05f;
        theRenderer.color = new Color(1, 1, 1, opacity);
        if(opacity <= 0)
        {
            Destroy(gameObject);
        }
	}
}
