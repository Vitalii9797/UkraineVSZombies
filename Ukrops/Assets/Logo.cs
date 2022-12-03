using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class Logo : MonoBehaviour, IUnityAdsInitializationListener
{
    [SerializeField] private string _gameId;


    [SerializeField] private GameObject fadeImage;
    [SerializeField] private GameObject e1;
    [SerializeField] private GameObject e2;
    [SerializeField] private GameObject e3;

    private Animator fadeAnim;
    private SpriteRenderer fadeRenderer;
    private SpriteRenderer e1Renderer;
    private SpriteRenderer e2Renderer;
    private SpriteRenderer e3Renderer;

    private void Awake()
    {
        InitializeAds();
    }
    void Start()
    {
        fadeAnim = fadeImage.GetComponent<Animator>();
        fadeRenderer = fadeImage.GetComponent<SpriteRenderer>();

        e1Renderer = e1.GetComponent<SpriteRenderer>();
        e2Renderer = e2.GetComponent<SpriteRenderer>();
        e3Renderer = e3.GetComponent<SpriteRenderer>();

        StartCoroutine(StartAnims());
    }

    IEnumerator StartAnims()
    {
        yield return new WaitForSeconds(1);
            e1.SetActive(true);
        StartCoroutine(Logo1Play());

    }

    IEnumerator Logo1Play()
    {
        while(e1Renderer.color.a < 0.98f)
        {
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForSeconds(2f);
        e2.SetActive(true);
        StartCoroutine(Logo2Play());
    }

    IEnumerator Logo2Play()
    {
        while (e2Renderer.color.a < 0.98f)
        {
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForSeconds(2f);
        e3.SetActive(true);
        StartCoroutine (Logo3Play());   
    }

    IEnumerator Logo3Play()
    {
        while (e3Renderer.color.a < 0.98f)
        {
            yield return new WaitForEndOfFrame();
        }
        StartCoroutine(GameStart());
    }

    private IEnumerator GameStart()
    {
        yield return new WaitForSeconds(5f);

        fadeAnim.SetTrigger("fade");
        while (fadeRenderer.color.a < 0.98f)
        {
            yield return new WaitForEndOfFrame();
        }

        SceneManager.LoadScene(1);

    }

    public void InitializeAds()
    {
        Advertisement.Initialize(_gameId, true, this);
    }

    public void OnInitializationComplete()
    {
        Debug.Log("Unity Ads initialization complete.");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
    }

}
