using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class RewardedAd : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [SerializeField] string _androidAdUnitId = "Rewarded_Android";
    [SerializeField] Text noadsText;
    [SerializeField] GameManager gameManager;
    [SerializeField] GameObject adsPopUp;

    private Animator noadsAnim;


    
    private void Start()
    {
        noadsAnim = noadsText.GetComponent<Animator>();
        LoadAd();
    }



    public void LoadAd()
    {
        Debug.Log("Loading Ad: " + _androidAdUnitId);
        Advertisement.Load(_androidAdUnitId, this);
    }

    public void OnUnityAdsAdLoaded(string adUnitId)
    {
        Debug.Log("RewardedAdsLoaded");
    }

    public void ShowAd()
    {
        Advertisement.Show(_androidAdUnitId, this);
    }

    // Implement the Show Listener's OnUnityAdsShowComplete callback method to determine if the user gets a reward:
    public void OnUnityAdsShowComplete(string adUnitId, UnityAdsShowCompletionState showCompletionState)
    {
        if (adUnitId.Equals(_androidAdUnitId) && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED))
        {
            Debug.Log("Unity Ads Rewarded Ad Completed");
            // Grant a reward.
            gameManager.AddScore(100);

            LoadAd();
        }
    }

    public void OnUnityAdsFailedToLoad(string adUnitId, UnityAdsLoadError error, string message)
    {
        Debug.Log($"Error loading Ad Unit {adUnitId}: {error.ToString()} - {message}");
    }

    public void OnUnityAdsShowFailure(string adUnitId, UnityAdsShowError error, string message)
    {
        Debug.Log($"Error showing Ad Unit {adUnitId}: {error.ToString()} - {message}");
        noadsAnim.SetTrigger("noads");

    }

    public void OnUnityAdsShowStart(string adUnitId) { }
    public void OnUnityAdsShowClick(string adUnitId) { }



    public void TVButton()
    {
        adsPopUp.SetActive(true);
    }

    public void NoButton()
    {
        adsPopUp.SetActive(false);
    }

    public void YesButton()
    {
        ShowAd();
        adsPopUp.SetActive(false);
    }
}
