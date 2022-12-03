using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockLevel : MonoBehaviour
{
    public SelectLevel selectLevel;

    [SerializeField] int level;
    private void OnMouseDown()
    {
        if(level == 2)
        {
            selectLevel.UnlockMap2();
        }
        else if(level == 3)
        {
            selectLevel.UnlockMap3();
        }
        else
        {

        }
    }
}
