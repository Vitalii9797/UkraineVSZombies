using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectLevel : MonoBehaviour
{
    [SerializeField] AudioSource click;
    [SerializeField] Text coinsText;

    [SerializeField] GameObject map2Button;
    [SerializeField] GameObject map3Button;

    [SerializeField] GameObject map2Mask;
    [SerializeField] GameObject map3Mask;

    [SerializeField] SpriteRenderer map2PriceImage;
    [SerializeField] SpriteRenderer map3PriceImage;

    private int coins;
    private int map2bought, map3bought;
    private const int map2Price = 3000, map3Price = 5000;
    
    void Start()
    {
        /*  For checking new upgrades
         coins = 5000;
         PlayerPrefs.SetInt("coins", coins);
       */

        coins = PlayerPrefs.GetInt("coins");
        map2bought = PlayerPrefs.GetInt("map2Bought");
        map3bought = PlayerPrefs.GetInt("map3Bought");
        coinsText.text = coins.ToString();
        SetPriceImages();
        SetAccessToMaps();
    }

    private void SetPriceImages()
    {
        if(coins < map2Price)
        {
            map2PriceImage.color = Color.red; 
        }
        else
        {
            map2PriceImage.color = Color.white;
        }

        if(coins < map3Price)
        {
            map3PriceImage.color = Color.red;
        }
        else
        {
            map3PriceImage.color= Color.white;
        }
    }

    private void SetAccessToMaps()
    {
        if(map2bought == 1)
        {
            map2Mask.SetActive(false);
            map2Button.SetActive(true);
        }
        else
        {
            map2Button.SetActive(false);
            map2Mask.SetActive(true);
        }

        if (map3bought == 1)
        {
            map3Mask.SetActive(false);
            map3Button.SetActive(true);
        }
        else
        {
            map3Button.SetActive(false);
            map3Mask.SetActive(true);
        }
    }

    public void UnlockMap2()
    {
        click.Play();
        if(coins >= map2Price)
        {
            coins -= map2Price;
            coinsText.text = coins.ToString();
            map2bought = 1;
            PlayerPrefs.SetInt("coins", coins);
            PlayerPrefs.SetInt("map2Bought", map2bought);
            map2Mask.SetActive(false);
            map2Button.SetActive(true);
        }
        SetPriceImages();

    }

    public void UnlockMap3()
    {
        click.Play();
        if (coins >= map3Price)
        {
            coins -= map3Price;
            coinsText.text = coins.ToString();
            map3bought = 1;
            PlayerPrefs.SetInt("coins", coins);
            PlayerPrefs.SetInt("map3Bought", map3bought);
            map3Mask.SetActive(false);
            map3Button.SetActive(true);
        }
        SetPriceImages();

    }

    public void BackToMenu()
    {
        click.Play();

        SceneManager.LoadScene(1);
    }

}
