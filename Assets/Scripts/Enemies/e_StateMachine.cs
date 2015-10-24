using UnityEngine;
using System.Collections;

public class e_StateMachine : MonoBehaviour {
    bool eIdle,
         eAggro,
         eGuard;
    bool isRight;

    float timer = 0;

    Animator theAnimator;

    


	// Use this for initialization
	void Start () {
        eIdle = true;
        eAggro = false;
        eGuard = false;
        theAnimator = gameObject.GetComponent<Animator>();
	    
	}
	
	// Update is called once per frame
	void Update () {

        if (eIdle)
        {
            timer += Time.deltaTime;
            if (timer >= 2.5f)
            {
                if (isRight)
                {
                    theAnimator.transform.localScale = new Vector3(-1, 1, 1);
                    isRight = false;
                }
                else
                {
                    theAnimator.transform.localScale = new Vector3(1, 1, 1);
                    isRight = true;
                }
            }

        }
        if(eAggro)
        {
            gameObject.SendMessage("Move");
        }

        if (eGuard)
        {
            gameObject.SendMessage("Guard");
        }

    
  




	
	}

    public void SetIdle()
    {
        eIdle = true;
        eAggro = false;
        eGuard = false;
    }
    public void SetAggro()
    {
        eIdle = false;
        eAggro = true;
        eGuard = false;
    }
    public void SetGuard()
    {
        eIdle = false;
        eAggro = false;
        eGuard = true;
    }
}
