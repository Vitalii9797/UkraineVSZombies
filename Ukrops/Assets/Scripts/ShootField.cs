using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootField : MonoBehaviour
{
    [SerializeField] GameManager gameManager;

    private void OnMouseOver()
    {
       if (Input.touchCount > 0)
        gameManager.soldier.Shoot();
    }
}
