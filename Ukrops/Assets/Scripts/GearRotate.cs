using UnityEngine;

public class GearRotate : MonoBehaviour
{
   
    private float speed = 1f;

    void FixedUpdate()
    {
        transform.Rotate(0f, 0f, -speed);
    }
}
