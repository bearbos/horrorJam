using UnityEngine;
using System.Collections;

public class Destructable : MonoBehaviour
{
    public float HP;
    // Use this for initialization
    void Start()
    {
        
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
