using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    Rigidbody2D rb;
    [SerializeField]
    public Vector2 Distance;
    public GameObject[] differenttypes;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(Distance);
        Invoke("ZeroGravity", 1.4f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void ZeroGravity()
    {
        rb.gravityScale = 0.0f;
        rb.velocity = Vector2.zero;
    }
}
