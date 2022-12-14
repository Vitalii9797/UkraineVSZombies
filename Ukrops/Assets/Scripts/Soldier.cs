using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : MonoBehaviour
{
    public float AttackStrength = 1f;
    public bool weaponLoaded = true;
    public GameManager gameManager;


    [SerializeField] ParticleSystem shotParticle;
    [SerializeField] private float fireRate;
    [SerializeField] private AudioSource shootSound;

    private Animator soldierAnim;

    void Start()
    {
        soldierAnim = GetComponent<Animator>();
    }

    private void OnMouseDown()
    {
       Shoot();
    }

    public void Shoot()
    {
        if(weaponLoaded && gameManager.bayraktar.isActive == false)
        {
            soldierAnim.SetTrigger("shoot");
            shootSound.Play();
            shotParticle.Play();
            weaponLoaded = false;
            StartCoroutine(Reload(fireRate));
        }
    }

    private IEnumerator Reload(float rate)
    {
        yield return new WaitForSeconds(rate);
        weaponLoaded = true;
    }
}
