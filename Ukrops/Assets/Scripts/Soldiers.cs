using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldiers : MonoBehaviour
{
    public Soldier Soldier1;
    public Soldier Soldier2;
    public Soldier Soldier3;

    public int soldierIndex;


    void Awake()
    {
        soldierIndex = PlayerPrefs.GetInt("soldierIndex");
    }

    public Soldier SetSoldier()
    {
        if(soldierIndex == 0)
        {
            Soldier1.gameObject.SetActive(true);
            Soldier2.gameObject.SetActive(false);
            Soldier3.gameObject.SetActive(false);
            return Soldier1;
        }
        else if(soldierIndex == 1)
        {
            Soldier1.gameObject.SetActive(false);
            Soldier2.gameObject.SetActive(true);
            Soldier3.gameObject.SetActive(false);
            return Soldier2;
        }
        else if(soldierIndex == 2)
        {
            Soldier1.gameObject.SetActive(false);
            Soldier2.gameObject.SetActive(false);
            Soldier3.gameObject.SetActive(true);
            return Soldier3;
        }
        else
        {
            Soldier1.gameObject.SetActive(false);
            Soldier2.gameObject.SetActive(true);
            return Soldier2;
        }
    }

    

}
