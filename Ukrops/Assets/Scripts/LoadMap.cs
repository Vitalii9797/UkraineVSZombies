using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMap : MonoBehaviour
{
    [SerializeField] private string map;
    [SerializeField] private GameObject fade;
    [SerializeField] AudioSource click;


    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = fade.GetComponent<SpriteRenderer>();
    }

    private void OnMouseDown()
    {
        click.Play();
        StartCoroutine(LoadingMap());
    }

    IEnumerator LoadingMap()
    {
        fade.GetComponent<Animator>().SetTrigger("fade");
        while(spriteRenderer.color.a < 0.95f)
        {
            yield return new WaitForEndOfFrame();

        }
        SceneManager.LoadScene(map);
    }

}
