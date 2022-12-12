using System.Collections;
using UnityEngine;

public class ZombieTank : MonoBehaviour
{
    public float Health = 5f;

    [SerializeField] private int price;
    [SerializeField] private float attack;
    [SerializeField] private float walkSpeed;
    [SerializeField] private ParticleSystem fire;
    [SerializeField] private AudioSource fireSound;
    [SerializeField] private BoxCollider2D boxCollider;

    private bool canWalk = true;
    private GameManager gameManager;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        canWalk = true;
        animator = GetComponent<Animator>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        SetOrderInLayer();
    }

    void FixedUpdate()
    {
        if (canWalk) transform.Translate(Vector2.left * walkSpeed * Time.deltaTime);
    }



    private void OnMouseOver()
    {
        if (Input.touchCount > 0)
            TakeDamage();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("barrier"))
        {
            canWalk = false;
            StartCoroutine(Attack());
        }
        if (collision.gameObject.CompareTag("bayraktar"))
        {
            Death();
        }
    }

    

    private IEnumerator Attack()
    {
        while (true)
        {
            gameManager.AttackBarricade(attack);
            yield return new WaitForSeconds(1.5f);
        }
    }

    public void TakeDamage()
    {
        if (gameManager.soldier.weaponLoaded && gameManager.bayraktar.isActive == false)
        {
            gameManager.SplashSparkle(transform.position);
            if (Health > gameManager.soldier.AttackStrength)
            {
                Health -= gameManager.soldier.AttackStrength;
            }
            else
            {
                Death();
            }
        }
        gameManager.soldier.Shoot();
    }

    private void Death()
    {
        gameManager.AddScore(price);
        fire.Play();
        fireSound.Play();
        spriteRenderer.color = new Color(0.4f, 0.4f, 0.4f);
        canWalk = false;
        boxCollider.enabled = false;   
        animator.enabled = false;
        Destroy(this.gameObject, 2f);
    }

    


    private void SetOrderInLayer()
    {
        if (transform.position.y > 0)
        {
            if (transform.position.y >= 3.4f) spriteRenderer.sortingOrder = 3;
            else if (transform.position.y >= 3.3f && transform.position.y < 3.4f) spriteRenderer.sortingOrder = 4;
            else if (transform.position.y >= 3.2f && transform.position.y < 3.3f) spriteRenderer.sortingOrder = 5;
            else if (transform.position.y >= 3.1f && transform.position.y < 3.2f) spriteRenderer.sortingOrder = 6;
            else if (transform.position.y >= 3.0f && transform.position.y < 3.1f) spriteRenderer.sortingOrder = 7;
            else if (transform.position.y >= 2.9f && transform.position.y < 3.0f) spriteRenderer.sortingOrder = 8;
            else if (transform.position.y >= 2.8f && transform.position.y < 2.9f) spriteRenderer.sortingOrder = 9;
            else if (transform.position.y >= 2.7f && transform.position.y < 2.8f) spriteRenderer.sortingOrder = 10;
            else if (transform.position.y >= 2.6f && transform.position.y < 2.7f) spriteRenderer.sortingOrder = 11;
            else if (transform.position.y >= 2.5f && transform.position.y < 2.6f) spriteRenderer.sortingOrder = 12;
            else if (transform.position.y >= 2.4f && transform.position.y < 2.5f) spriteRenderer.sortingOrder = 13;
            else if (transform.position.y >= 2.3f && transform.position.y < 2.4f) spriteRenderer.sortingOrder = 14;
            else if (transform.position.y >= 2.2f && transform.position.y < 2.3f) spriteRenderer.sortingOrder = 15;
            else if (transform.position.y >= 2.1f && transform.position.y < 2.2f) spriteRenderer.sortingOrder = 16;
            else if (transform.position.y >= 2.0f && transform.position.y < 2.1f) spriteRenderer.sortingOrder = 17;
            else if (transform.position.y >= 1.9f && transform.position.y < 2.0f) spriteRenderer.sortingOrder = 18;
            else if (transform.position.y >= 1.8f && transform.position.y < 1.9f) spriteRenderer.sortingOrder = 19;
            else if (transform.position.y >= 1.7f && transform.position.y < 1.8f) spriteRenderer.sortingOrder = 20;
            else if (transform.position.y >= 1.6f && transform.position.y < 1.7f) spriteRenderer.sortingOrder = 21;
            else if (transform.position.y >= 1.5f && transform.position.y < 1.6f) spriteRenderer.sortingOrder = 22;
            else if (transform.position.y >= 1.4f && transform.position.y < 1.5f) spriteRenderer.sortingOrder = 23;
            else if (transform.position.y >= 1.3f && transform.position.y < 1.4f) spriteRenderer.sortingOrder = 24;
            else if (transform.position.y >= 1.2f && transform.position.y < 1.3f) spriteRenderer.sortingOrder = 25;
            else if (transform.position.y >= 1.1f && transform.position.y < 1.2f) spriteRenderer.sortingOrder = 26;
            else if (transform.position.y >= 1.0f && transform.position.y < 1.1f) spriteRenderer.sortingOrder = 27;
            else if (transform.position.y >= 0.9f && transform.position.y < 1.0f) spriteRenderer.sortingOrder = 28;
            else if (transform.position.y >= 0.8f && transform.position.y < 0.9f) spriteRenderer.sortingOrder = 29;
            else if (transform.position.y >= 0.7f && transform.position.y < 0.8f) spriteRenderer.sortingOrder = 30;
            else if (transform.position.y >= 0.6f && transform.position.y < 0.7f) spriteRenderer.sortingOrder = 31;
            else if (transform.position.y >= 0.5f && transform.position.y < 0.6f) spriteRenderer.sortingOrder = 32;
            else if (transform.position.y >= 0.4f && transform.position.y < 0.5f) spriteRenderer.sortingOrder = 33;
            else if (transform.position.y >= 0.3f && transform.position.y < 0.4f) spriteRenderer.sortingOrder = 34;
            else if (transform.position.y >= 0.2f && transform.position.y < 0.3f) spriteRenderer.sortingOrder = 35;
            else if (transform.position.y >= 0.1f && transform.position.y < 0.2f) spriteRenderer.sortingOrder = 36;
            else if (transform.position.y >= 0.0f && transform.position.y < 0.1f) spriteRenderer.sortingOrder = 37;

        }
        else if (transform.position.y < 0)
        {
            if (transform.position.y >= -0.1f) spriteRenderer.sortingOrder = 38;
            else if (transform.position.y >= -0.2f && transform.position.y < -0.1f) spriteRenderer.sortingOrder = 39;
            else if (transform.position.y >= -0.3f && transform.position.y < -0.2f) spriteRenderer.sortingOrder = 40;
            else if (transform.position.y >= -0.4f && transform.position.y < -0.3f) spriteRenderer.sortingOrder = 41;
            else if (transform.position.y >= -0.5f && transform.position.y < -0.4f) spriteRenderer.sortingOrder = 42;
            else if (transform.position.y >= -0.6f && transform.position.y < -0.5f) spriteRenderer.sortingOrder = 43;
            else if (transform.position.y >= -0.7f && transform.position.y < -0.6f) spriteRenderer.sortingOrder = 44;
            else if (transform.position.y >= -0.8f && transform.position.y < -0.7f) spriteRenderer.sortingOrder = 45;
            else if (transform.position.y >= -0.9f && transform.position.y < -0.8f) spriteRenderer.sortingOrder = 46;
            else if (transform.position.y >= -1.0f && transform.position.y < -0.9f) spriteRenderer.sortingOrder = 47;
            else if (transform.position.y >= -1.1f && transform.position.y < -1.0f) spriteRenderer.sortingOrder = 48;
            else if (transform.position.y >= -1.2f && transform.position.y < -1.1f) spriteRenderer.sortingOrder = 49;
            else if (transform.position.y >= -1.3f && transform.position.y < -1.2f) spriteRenderer.sortingOrder = 50;
            else if (transform.position.y >= -1.4f && transform.position.y < -1.3f) spriteRenderer.sortingOrder = 51;
            else if (transform.position.y >= -1.5f && transform.position.y < -1.4f) spriteRenderer.sortingOrder = 52;
            else if (transform.position.y >= -1.6f && transform.position.y < -1.5f) spriteRenderer.sortingOrder = 53;
            else if (transform.position.y >= -1.7f && transform.position.y < -1.6f) spriteRenderer.sortingOrder = 54;
            else if (transform.position.y >= -1.8f && transform.position.y < -1.7f) spriteRenderer.sortingOrder = 55;
            else if (transform.position.y >= -1.9f && transform.position.y < -1.8f) spriteRenderer.sortingOrder = 56;
            else if (transform.position.y >= -2.0f && transform.position.y < -1.9f) spriteRenderer.sortingOrder = 57;
            else if (transform.position.y >= -2.1f && transform.position.y < -2.0f) spriteRenderer.sortingOrder = 58;
            else if (transform.position.y >= -2.2f && transform.position.y < -2.1f) spriteRenderer.sortingOrder = 59;
            else if (transform.position.y >= -2.3f && transform.position.y < -2.2f) spriteRenderer.sortingOrder = 60;
            else if (transform.position.y >= -2.4f && transform.position.y < -2.3f) spriteRenderer.sortingOrder = 61;
            else if (transform.position.y >= -2.5f && transform.position.y < -2.4f) spriteRenderer.sortingOrder = 62;
            else if (transform.position.y >= -2.6f && transform.position.y < -2.5f) spriteRenderer.sortingOrder = 63;
            else if (transform.position.y >= -2.7f && transform.position.y < -2.6f) spriteRenderer.sortingOrder = 64;
            else if (transform.position.y >= -2.8f && transform.position.y < -2.7f) spriteRenderer.sortingOrder = 65;
            else if (transform.position.y >= -2.9f && transform.position.y < -2.8f) spriteRenderer.sortingOrder = 66;
            else if (transform.position.y >= -3.0f && transform.position.y < -2.9f) spriteRenderer.sortingOrder = 67;
            else if (transform.position.y >= -3.1f && transform.position.y < -3.0f) spriteRenderer.sortingOrder = 68;
            else if (transform.position.y >= -3.2f && transform.position.y < -3.1f) spriteRenderer.sortingOrder = 69;
            else if (transform.position.y >= -3.3f && transform.position.y < -3.2f) spriteRenderer.sortingOrder = 70;
            else if (transform.position.y >= -3.4f && transform.position.y < -3.3f) spriteRenderer.sortingOrder = 71;
            else if (transform.position.y < -3.4f) spriteRenderer.sortingOrder = 72;

        }
        fire.GetComponent<Renderer>().sortingOrder = spriteRenderer.sortingOrder + 1;

    }
}
