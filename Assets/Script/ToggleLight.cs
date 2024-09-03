using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleLight : MonoBehaviour
{
    public GameObject highLight;
    public GameObject lowLight;
    public Image EnergyBar;
    public float energy = 100;

    void Update()
    {
        EnergyBar.fillAmount = energy / 100f;

        if (energy < 0)
        {
            highLight.SetActive(false);
            lowLight.SetActive(true);
        }

        if (energy > 100)
        {
            energy = 100;
        }

        if (highLight.activeSelf == true)
        {
            energy -= 0.01f;
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            if(highLight.activeSelf == false && energy > 0)
            {
                highLight.SetActive(true);
                lowLight.SetActive(false);
            }
            else
            {
                highLight.SetActive(false);
                lowLight.SetActive(true);
            }
        }
    }
}
