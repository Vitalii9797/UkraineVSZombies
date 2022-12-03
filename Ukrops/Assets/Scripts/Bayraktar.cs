using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bayraktar : MonoBehaviour
{
    public bool isActive = false;

    [SerializeField] private float xLeftLimit, xRightLimit, yLimit;
    [SerializeField] private ParticleSystem explosion;
    [SerializeField] private GameObject triger;
    [SerializeField] private GameObject jet;
    [SerializeField] private AudioSource explosionSound;

    private SpriteRenderer spriteRenderer;
    private Camera mainCamera;
    private Animator cameraAnim;


    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        mainCamera = Camera.main;
        cameraAnim = mainCamera.GetComponent<Animator>();
        spriteRenderer.enabled = false;
    }

    public void ActivateBayraktar()
    {
        jet.SetActive(true);
        spriteRenderer.enabled = true;
        isActive = true;
    }

    void FixedUpdate()
    {
        if(spriteRenderer.enabled)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                float moveX = touch.deltaPosition.x * 0.005f;
                float moveY = touch.deltaPosition.y * 0.005f;

                transform.Translate(moveX, moveY, 0f);

                if(touch.phase == TouchPhase.Ended)
                {
                    triger.SetActive(true);
                    spriteRenderer.enabled = false;
                    jet.SetActive(false);
                    explosion.transform.position = transform.position;  
                    explosion.Play();
                    explosionSound.Play();
                    cameraAnim.SetTrigger("Shake");
                    StartCoroutine(DeactivateTrigger());
                }
            }
            Vector3 position = transform.position;
            position.x = Mathf.Clamp(position.x, -xLeftLimit, xRightLimit);
            position.y = Mathf.Clamp(position.y, -yLimit, yLimit);
            transform.position = position;
        }

        IEnumerator DeactivateTrigger()
        {
            yield return new WaitForSeconds(0.5f);
            triger.SetActive(false);
            isActive = false;
        }
    }

   
}
