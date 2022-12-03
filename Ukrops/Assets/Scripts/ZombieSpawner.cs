using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZombieSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] zombiePrefab;
    [SerializeField] private float spawnDelay;
    [SerializeField] private Text waveText;

    private Animator waweTextAnim;
    private int waveCount;
    private int waveNumber;
    private float xSpawnPosition = 13f;
    private float ySpawnPosition = 3f;

    

    private int counter = 0;
    private bool isSpawning;

    void Start()
    {
        waweTextAnim = waveText.GetComponent<Animator>();
        LoadValues();
        ShowWaveNumber();
        StartCoroutine(SpawnZombie());
    }

    private void LoadValues()
    {
        waveCount = PlayerPrefs.GetInt("waveCount");
        waveNumber = PlayerPrefs.GetInt("waveNumber");

       
        if(waveCount <= 0)
        {
            waveCount = 5;
        }
        if(waveNumber <= 0)
        {
            waveNumber = 1;
        }
    }

    private float SetSpawnDelay()
    {
         if(waveNumber > 50)
        {
            return spawnDelay + 0.2f;
        }
        else if(waveNumber > 100)
        {
            return spawnDelay + 0.3f;
        }
        else if(waveNumber > 150)
        {
            return spawnDelay + 0.4f;
        }
        else if(waveNumber > 200)
        {
            return spawnDelay + 0.5f;
        }
        else if(waveNumber > 250)
        {
            return spawnDelay + 0.6f;
        }
        else
        {
            return spawnDelay;
        }
    }

    private IEnumerator SpawnZombie()
    {
        while (counter < waveCount)
        {
            isSpawning = true;
            yield return new WaitForSeconds(SetSpawnDelay());
            Instantiate(GetRandomZombie(), new Vector2(xSpawnPosition, Random.Range(-ySpawnPosition, ySpawnPosition)), Quaternion.identity);
            counter++;
        }
        counter = 0;
        isSpawning=false;
        StartCoroutine(WaitForNewWave());
    }

    private void UpdateWave()
    {
        waveCount++;
        waveNumber++;
        PlayerPrefs.SetInt("waveCount", waveCount);
        PlayerPrefs.SetInt("waveNumber", waveNumber);
    }



    

    private void ShowWaveNumber()
    {
        waveText.text = "DAY " + waveNumber.ToString();
        waweTextAnim.SetTrigger("wave");
    }

    private IEnumerator WaitForNewWave()
    {
        while (true)
        {
            if(GameObject.FindGameObjectWithTag("zombie") == null && isSpawning == false)
            {
           
                UpdateWave();
                ShowWaveNumber();
                StartCoroutine(SpawnZombie());
            }
            yield return new WaitForSeconds(3);
        }
    }



    private GameObject GetRandomZombie()
    {
        return zombiePrefab[Random.Range(0, zombiePrefab.Length)];
    }

}
