using UnityEngine;
using UnityEngine.UI;

public class Barricades : MonoBehaviour
{
    public float Health;
    public Image barricadeHealth;

    public GameObject[] barricades;

    public void SetBarricadeLevel(int index)
    {
        switch (index)
        {
            case 0:

                for (int i = 0; i < barricades.Length; i++)
                {
                    barricades[i].SetActive(false);
                }
                barricades[0].SetActive(true);
                Health = 10f;
                break;
            case 1:

                for (int i = 0; i < barricades.Length; i++)
                {
                    barricades[i].SetActive(false);
                }
                barricades[1].SetActive(true);
                Health = 15f;
                break;
            case 2:

                for (int i = 0; i < barricades.Length; i++)
                {
                    barricades[i].SetActive(false);
                }
                barricades[2].SetActive(true);
                Health = 20f;
                break;
            case 3:

                for (int i = 0; i < barricades.Length; i++)
                {
                    barricades[i].SetActive(false);
                }
                barricades[3].SetActive(true);
                Health = 25f;
                break;
            case 4:

                for (int i = 0; i < barricades.Length; i++)
                {
                    barricades[i].SetActive(false);
                }
                barricades[4].SetActive(true);
                Health = 30f;
                break;
            case 5:

                for (int i = 0; i < barricades.Length; i++)
                {
                    barricades[i].SetActive(false);
                }
                barricades[5].SetActive(true);
                Health = 35f;
                break;
            case 6:

                for (int i = 0; i < barricades.Length; i++)
                {
                    barricades[i].SetActive(false);
                }
                barricades[6].SetActive(true);
                Health = 40f;
                break;
            case 7:

                for (int i = 0; i < barricades.Length; i++)
                {
                    barricades[i].SetActive(false);
                }
                barricades[7].SetActive(true);
                Health = 45f;
                break;
            case 8:

                for (int i = 0; i < barricades.Length; i++)
                {
                    barricades[i].SetActive(false);
                }
                barricades[8].SetActive(true);
                Health = 50f;
                break;
            case 9:

                for (int i = 0; i < barricades.Length; i++)
                {
                    barricades[i].SetActive(false);
                }
                barricades[9].SetActive(true);
                Health = 55f;
                break;
            case 10:
                for (int i = 0; i < barricades.Length; i++)
                {
                    barricades[i].SetActive(false);
                }
                barricades[10].SetActive(true);
                Health = 60f;
                break;
            case 11:
                for (int i = 0; i < barricades.Length; i++)
                {
                    barricades[i].SetActive(false);
                }
                barricades[10].SetActive(true);
                Health = 65f;
                break;

        }
    }
}
