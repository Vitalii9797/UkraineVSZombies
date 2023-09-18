using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;


public class MainMenu : MonoBehaviour, IUnityAdsInitializationListener
{
    [SerializeField] AudioSource clickSound;
    [SerializeField] Button soundButton;
    [SerializeField] Sprite [] soundButtonSprite;
    [SerializeField] GameObject settingsPanel;
    [SerializeField] GameObject aboutPanel;
    [SerializeField] GameObject ratePopUp;

    private int firstEntry;
    private int rated;

    private void Awake()
    {
       StartCoroutine(InitializeAds()); 
    }

    private void Start()
    {
        Time.timeScale = 1;
        firstEntry = PlayerPrefs.GetInt("entry");
        rated = PlayerPrefs.GetInt("rated");
        AudioListener.volume = 1;
        SetButtonSprite();
        PopUpRate();

    }
    public void StartGame()
    {
        clickSound.Play();
        firstEntry += 1;
        PlayerPrefs.SetInt("entry", firstEntry);
        SceneManager.LoadScene(2);
    }

     private void PopUpRate()
    {
        if(firstEntry != 0 && rated == 0)
        {
            if(firstEntry == 1 || firstEntry%3 == 0)
            {
               ratePopUp.SetActive(true);
            }
        }
    }

    public void LikeApp()
    {
        Application.OpenURL("https://play.google.com/store/apps/details?id=com.NewBridge.UkraineVSZombies");
        rated += 1;
        PlayerPrefs.SetInt("rated", rated);
        ratePopUp.SetActive(false);
    }

    public void DontLikeApp()
    {
        ratePopUp.SetActive(false);
    }
    

    public void SoundButton()
    {
        if(AudioListener.volume == 1)
        {
            AudioListener.volume = 0;
            soundButton.GetComponent<Image>().sprite = soundButtonSprite[1];
        }
        else if(AudioListener.volume == 0)
        {
            AudioListener.volume = 1;
            soundButton.GetComponent<Image>().sprite = soundButtonSprite[0];
        }
    }

    private void SetButtonSprite()
    {
        if (AudioListener.volume == 1)
        {
            soundButton.GetComponent<Image>().sprite = soundButtonSprite[0];
        }
        else if (AudioListener.volume == 0)
        {
            soundButton.GetComponent<Image>().sprite = soundButtonSprite[1];
        }
    }

    public void SettingsButton()
    {
        settingsPanel.SetActive(true);
    }

    public void AboutPanel()
    {
        settingsPanel.SetActive(false);
        aboutPanel.SetActive(true);
    }

    public void CloseAbout()
    {
        aboutPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    public void OpenNewBridgeAccount()
    {
        Application.OpenURL("https://play.google.com/store/apps/dev?id=7273818406239829304");
    }
    



    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void OnInitializationComplete()
    {
        Debug.Log("Ads initialization successful");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log("Ads initialization failed" + message);
    }

    private IEnumerator InitializeAds()
    {
        while (!Advertisement.isInitialized)
        {
            Advertisement.Initialize("4894971", false, this);
            yield return new WaitForEndOfFrame();
        }
    }
}
