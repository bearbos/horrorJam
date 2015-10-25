using UnityEngine;
using System.Collections;

public class Mask : MonoBehaviour
{
    [SerializeField]
    string maskName;
    public int price;
    public string description;
    public int wantedLevel;
    float spookMulti = 1f;
    bool isHockey = false;
    public Sprite sprite;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isHockey && maskName == "HockeyMask")
        {
            GameObject[] kids = GameObject.FindGameObjectsWithTag("Kids");
            for (int i = 0; i < kids.Length; i++)
            {
                kids[i].GetComponent<KidsBehavior>().minCandy += 2;
                kids[i].GetComponent<KidsBehavior>().maxCandy += 2;
            }
        }
        else if (!isHockey && maskName == "HockeyMask")
        {
                GameObject[] kids = GameObject.FindGameObjectsWithTag("Enemy");
                for (int i = 0; i < kids.Length; i++)
                {
                    if (kids[i].GetComponent<KidsBehavior>() != null)
                    {
                        kids[i].GetComponent<KidsBehavior>().minCandy -= 2;
                        kids[i].GetComponent<KidsBehavior>().maxCandy -= 2; 
                    }
                }
        }
    }
    public void ApplyBuff()
    {
        switch (maskName)
        {
            case "Werewolf":
                GameObject.FindGameObjectWithTag("Player").GetComponent<playerStats>().timeMulti = 0.8f;
                break;
            case "DevilMask":
                GameObject.FindGameObjectWithTag("Player").GetComponent<playerStats>().damageMulti += 0.2f;
                break;
            case "NunsHabit":
                spookMulti = 0.8f;
                break;
            case "HockeyMask":
                isHockey = true;
                break;
            case "TrollMask":
                break;
        }
    }
    public void ResetBuff()
    {
        switch (maskName)
        {
            case "Werewolf":
                GameObject.FindGameObjectWithTag("Player").GetComponent<playerStats>().timeMulti = 1f;
                break;
            case "DevilMask":
                GameObject.FindGameObjectWithTag("Player").GetComponent<playerStats>().damageMulti -= 0.2f;
                break;
            case "NunsHabit":
                spookMulti = 1f;
                break;
            case "HockeyMask":
                isHockey = false;
                break;
            case "TrollMask":
                break;
        }
    }
}
