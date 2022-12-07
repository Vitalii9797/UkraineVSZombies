using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class Logo : MonoBehaviour, IUnityAdsInitializationListener
{
    [SerializeField] private string _gameId;

    [SerializeField] private CanvasGroup logo; 

    private void Awake()
    {
        InitializeAds();
    }
    void Start()
    {
        StartCoroutine(GameStart());
    }

    private IEnumerator GameStart()
    {
        while (logo.alpha > 0.01f)
        {
            yield return new WaitForEndOfFrame();
        }

        SceneManager.LoadScene(1);

    }

    public void InitializeAds()
    {
        Advertisement.Initialize(_gameId, false, this);
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
