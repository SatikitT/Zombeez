using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject gameUI;  
    public GameObject menuUI;
    public GameObject spawner;
    public GameObject player;
    public GameObject explode;
    public CarController car;
    public GunController gun;

    private MonoBehaviour[] scriptsToActivate;

    void Start()
    {
        gameUI.SetActive(false);
        menuUI.SetActive(true);
        spawner.SetActive(false);
        scriptsToActivate = player.GetComponents<MonoBehaviour>();
        foreach (MonoBehaviour script in scriptsToActivate)
        {
            script.enabled = false;
        }
    }

    void Update()
    {
        if (car.GetCurrentCarHealth() <= 0)
        {
            Debug.Log(car.GetCurrentCarHealth());
            EndGame();
        }
    }

    public void StartGame()
    {
        gameUI.SetActive(true);
        menuUI.SetActive(false);
        spawner.SetActive(true);
        foreach (MonoBehaviour script in scriptsToActivate)
        {
            script.enabled = true; 
        }
    }

    IEnumerator Wait()
    {
        explode.SetActive(true);
        yield return new WaitForSeconds(1f);
        explode.SetActive(false);
        gameUI.SetActive(false);
        menuUI.SetActive(true);

        spawner.SetActive(false);
        foreach (MonoBehaviour script in scriptsToActivate)
        {
            script.enabled = false; // Disable all scripts to end the game
        }

        gun.ammo = 30;
        car.ResetCar();

    }

    public void EndGame()
    {
        StartCoroutine(Wait());


    }
}
