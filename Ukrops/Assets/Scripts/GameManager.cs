using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Soldiers soldiers;
    public Soldier soldier;
    public Bayraktar bayraktar;

    [SerializeField] private GameObject himarsFire;
    [SerializeField] private ParticleSystem blood;
    [SerializeField] private ParticleSystem sparkle;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private Text coinsText;
    [SerializeField] private Barricades barricades;
    [SerializeField] private Button upgradeButton;
    [SerializeField] private Sprite[] upgradeButtons;
    [SerializeField] private ZombieSpawner zombieSpawner;
    [SerializeField] private Button bayraktarButton;
    [SerializeField] private AudioSource clickSound;
    [SerializeField] private AudioSource explosionSound;
    [SerializeField] private AudioSource [] zombieDeathSound;
    [SerializeField] private Button soundButton;
    [SerializeField] Sprite[] soundButtonSprite;
    [SerializeField] private Sprite[] soldierUpgradeButtonSprites;
    [SerializeField] private Button himarsButton;
    [SerializeField] private Button soldierUpgradeButton;


    private Camera mainCamera;
    private Animator cameraAnim;
    private int coins;
    private int level;
    private const int maxLevel = 10;
    private const int soldierMaxLevel = 2;
    private int upgradeCost;
    private int bayraktarCost = 20;
    private float himarsXStart = -2f, himarsXFinish = 9f, himarsYLimit = 4f;
    private int himarsCounter = 6;
    private int count;
    private int himarsCost = 40;
    private int soldier2Cost = 1000;
    private int soldier3Cost = 2000;
    private int soldierUpgradeCost;

    private void Start()
    {

        /*  For checking new upgrades
          coins = 50000;
          PlayerPrefs.SetInt("coins", coins);
        */

        Time.timeScale = 1;
        soldierUpgradeCost = SetSoldierUpgradeCost();
        soldier = soldiers.SetSoldier();
        mainCamera = Camera.main;
        cameraAnim = mainCamera.GetComponent<Animator>();
        LoadValues();
        barricades.SetBarricadeLevel(level);
        SetUpgradeBtnSprite();
        SetSoldierButtonSprite();
        CheckForUpdate();
        coinsText.text = coins.ToString();
        SetButtonSprite();


    }

   

    private void LoadValues()
    {
        coins = PlayerPrefs.GetInt("coins");
        level = PlayerPrefs.GetInt("level");
        soldierUpgradeCost = SetSoldierUpgradeCost();
        switch (level)
        {
            case 0:
                upgradeCost = 100;
                break;
            case 1:
                upgradeCost = 200;
                break;
            case 2:
                upgradeCost = 300;
                break;
            case 3:
                upgradeCost = 400;
                break;
            case 4:
                upgradeCost = 500;
                break;
            case 5:
                upgradeCost = 600;
                break;
            case 6:
                upgradeCost = 700;
                break ;
            case 7:
                upgradeCost = 800;
                break;
            case 8:
                upgradeCost = 900;
                break;
            case 9:
                upgradeCost = 1000;
                break;
        }

    }

    private void Update()
    {
        if(Input.touchCount > 0)
        {
            soldier.Shoot();
        }
    }
    private int SetSoldierUpgradeCost()
    {
        if(soldiers.soldierIndex == 0)
        {
            return soldier2Cost;
        }
        else if(soldiers.soldierIndex == 1)
        {
            return soldier3Cost;
        }
        else
        {
            return 100000;
        }
    }

    public void AttackBarricade(float attack)
    {
        if(barricades.barricadeHealth.fillAmount > 0.01f)
        {
            barricades.barricadeHealth.fillAmount -= (attack / barricades.Health);
        }
        else if (barricades.barricadeHealth.fillAmount <= 0.01f)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        gameOverPanel.SetActive(true);  
        Time.timeScale = 0f;
    }

    public void SplashBlood(Vector3 position)
    {
        Vector3 offset = new Vector3(0.2f, 0.2f, 0f);
        blood.transform.position = position - offset;
        blood.Play();
    }

    public void SplashSparkle(Vector3 position)
    {
        Vector3 offset = new Vector3(0.2f, 0.2f, 0f);
        sparkle.transform.position = position - offset;
        sparkle.Play();
    }

    public void AddScore(int score)
    {
        coins += score;
        coinsText.text = coins.ToString();
        PlayerPrefs.SetInt("coins", coins);
        CheckForUpdate();
        SetUpgradeBtnSprite();
        SetSoldierButtonSprite();
       
    }

    private void SetUpgradeBtnSprite()
    {
        LoadValues();
        upgradeButton.GetComponent<Image>().sprite = upgradeButtons[level];
        if ( level >= maxLevel)
        {
            upgradeButton.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f);
            upgradeButton.interactable = false;
        }
        else if (coins < upgradeCost)
        {
            upgradeButton.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f);
            upgradeButton.interactable = false;
        }
        else
        {
            if (level < maxLevel)
            {
                upgradeButton.GetComponent<Image>().color = new Color(1f, 1f, 1f);
                upgradeButton.interactable = true;
            }
        }
    }

    private void SetSoldierButtonSprite()
    {
        LoadValues();

        
         soldierUpgradeButton.GetComponent<Image>().sprite = soldierUpgradeButtonSprites[soldiers.soldierIndex];
        

        if ( soldiers.soldierIndex >= soldierMaxLevel)
        {
            soldierUpgradeButton.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f);
            soldierUpgradeButton.interactable = false;
        }
        else if(coins < soldierUpgradeCost)
        {
            soldierUpgradeButton.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f);
            soldierUpgradeButton.interactable = false;
        }
        else
        {
            if (soldiers.soldierIndex < 2)
            {
                soldierUpgradeButton.GetComponent<Image>().color = new Color(1f, 1f, 1f);
                soldierUpgradeButton.interactable = true;
            }
        }
    }

    private void CheckForUpdate()
    {
        LoadValues();
        

        

        if(coins < bayraktarCost)
        {
            bayraktarButton.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f);
            bayraktarButton.interactable = false;
        }
        else
        {
            bayraktarButton.GetComponent<Image>().color = new Color(1f, 1f, 1f);
            bayraktarButton.interactable = true;
        }

        if (coins < himarsCost)
        {
            himarsButton.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f);
            himarsButton.interactable = false;
        }
        else
        {
            himarsButton.GetComponent<Image>().color = new Color(1f, 1f, 1f);
            himarsButton.interactable = true;
        }

    }

    private Vector3 GetRandomHimarsPosition()
    {
        return new Vector3(Random.Range(himarsXStart, himarsXFinish), Random.Range(-himarsYLimit, himarsYLimit), 1f);
    }

    public AudioSource GetRandomZombieSound()
    {
        return zombieDeathSound[Random.Range(0, zombieDeathSound.Length)];
    }

    private IEnumerator FireHimars()
    {
        while (count < himarsCounter)
        {
            Instantiate(himarsFire, GetRandomHimarsPosition(), Quaternion.identity);
            cameraAnim.SetTrigger("Shake");
            explosionSound.Play();
            count++;
            yield return new WaitForSeconds(0.5f);
        }
        count = 0;
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




    //************************************BUTTONS**********************************\\
    public void PauseButton()
    {
        clickSound.Play();
        pausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void ResumeButton()
    {
        Time.timeScale = 1; 
        pausePanel.SetActive(false);
        clickSound.Play();

    }

    public void ExitButton()
    {
        SceneManager.LoadScene(1);
        clickSound.Play();

    }

    public void RestartButton()
    {
        clickSound.Play();

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void UpgradeButton()
    {
        if(coins >= upgradeCost)
        {
            clickSound.Play();

            coins -= upgradeCost;
            coinsText.text = coins.ToString();
            if(level < maxLevel)
            {
                level += 1;
            }
            else
            {
                level = maxLevel;
            }
            PlayerPrefs.SetInt("level", level);
            PlayerPrefs.SetInt("coins", coins);

            barricades.SetBarricadeLevel(level);
            barricades.barricadeHealth.fillAmount = 1f;
            CheckForUpdate();
            SetUpgradeBtnSprite();
        }
    }

    public void UpgradeSoldier()
    {
        if(coins >= soldierUpgradeCost)
        {
            clickSound.Play();

            coins -= soldierUpgradeCost;
            coinsText.text = coins.ToString();
            if(soldiers.soldierIndex < soldierMaxLevel)
            {
                soldiers.soldierIndex += 1;
            }
            else
            {
                soldiers.soldierIndex = soldierMaxLevel;
            }
            PlayerPrefs.SetInt("soldierIndex", soldiers.soldierIndex);
            PlayerPrefs.SetInt("coins", coins);


            soldierUpgradeCost = SetSoldierUpgradeCost();
            soldier = soldiers.SetSoldier();
            SetSoldierButtonSprite();
            CheckForUpdate();

        }
    }

    public void BayraktarButton()
    {

        if(coins >= bayraktarCost)
        {
            bayraktar.ActivateBayraktar();
            coins -= bayraktarCost;
            coinsText.text = coins.ToString();
            PlayerPrefs.SetInt("coins", coins);
            CheckForUpdate();
        }

    }

    public void HimarsButton()
    {
        if(coins >= himarsCost)
        {
            StartCoroutine(FireHimars());
            coins -= himarsCost;
            coinsText.text = coins.ToString();
            PlayerPrefs.SetInt("coins", coins);
            CheckForUpdate();
        }
    }

    public void SoundButton()
    {
        if (AudioListener.volume == 1)
        {
            AudioListener.volume = 0;
            soundButton.GetComponent<Image>().sprite = soundButtonSprite[1];
        }
        else if (AudioListener.volume == 0)
        {
            AudioListener.volume = 1;
            soundButton.GetComponent<Image>().sprite = soundButtonSprite[0];
        }
    }

    

    
}
