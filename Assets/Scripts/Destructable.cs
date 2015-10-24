using UnityEngine;
using System.Collections;

public class Destructable : MonoBehaviour
{
    public float HP;

    // Use this for initialization
    void Start()
    {
        Vector3 newPos;
        newPos = gameObject.transform.position;
        newPos.z = newPos.y;
        gameObject.transform.position = newPos;
    }

    // Update is called once per frame
    void Update()
    {
        if(HP <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void TakeDamage(float _dam)
    {
        HP -= _dam;
    }
}
