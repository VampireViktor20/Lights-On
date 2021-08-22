using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{
    [SerializeField]
    private Light torchLight;
    [SerializeField]
    private bool isTorchOn = false;
    [SerializeField]
    private int maxBatteries = 4;
    [SerializeField]
    private float currentBatteries = 1f;
    [SerializeField]
    private float maxIntensity = 4f;

    

    public void Awake()
    {
        maxIntensity = torchLight.intensity;
    }
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isTorchOn == false)
            {
                if(currentBatteries > 0)
                {
                    float intensityPerc = (float)currentBatteries / (float)maxBatteries;

                    float intensityFac = maxIntensity * intensityPerc;

                    torchLight.intensity = intensityFac;
                }
                torchLight.enabled = true;
                isTorchOn = true;
                
            }
            else
            {
                torchLight.enabled = false;
                isTorchOn = false;
            }


        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            AddBattery();
        }

        if(isTorchOn == true)
        {
            currentBatteries -= (Time.deltaTime / 5f);

            float intensityPerc = (float)currentBatteries / (float)maxBatteries;

            float intensityFac = maxIntensity * intensityPerc;

            torchLight.intensity = intensityFac;

        }
    }
    public void AddBattery()
    {
        if(currentBatteries >= maxBatteries)
        {
            return;
        }
        currentBatteries++;
    }

    
}