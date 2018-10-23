﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameController : MonoBehaviour
{
    
    public GreetingController greetingController;
    public GameObject messagePanel;
    
    public bool VREnabled = true;
    
    AudioSource switchSound;
    AudioSource backgroundMusic;
    
    List<GameObject> lights = new List<GameObject>();
    
    [HideInInspector]
    public bool audioPlaying;
    [HideInInspector]
    public bool lightsOn = true;
       
    void Awake()
    {        
        switchSound = GameObject.FindGameObjectWithTag("Switch")
            .GetComponent<AudioSource>();
            
        backgroundMusic = GameObject.FindGameObjectWithTag("BGMusic")
            .GetComponent<AudioSource>();

        UnityEngine.XR.XRSettings.enabled = VREnabled;

        GetLights();
    }

    void GetLights()
    {
        foreach (GameObject l in GameObject.FindGameObjectsWithTag("Light"))
        {
            lights.Add(l);
        }
    }

    public void HideMessage()
    {
        messagePanel.SetActive(false);
    }

    public void ShowMessage(string msg)
    {
        messagePanel.SetActive(true);
        messagePanel.GetComponent<Text>().text = msg;
    }

    public void SwitchLightOff(string[] numbers)
    {
        if (lightsOn)
        {
            foreach (GameObject l in lights)
            {
                if (!l.name.Contains(numbers[0]) && !l.name.Contains(numbers[1]))
                {
                    l.SetActive(false);
                }
            }
            switchSound.Play();
            lightsOn = false;
            PauseBackgroundMusic();
            RenderSettings.ambientIntensity = 0.0f;
        }
        
    }

    public void SwitchLightOn()
    {
        if (!lightsOn)
        {
            foreach (GameObject l in lights)
            {
                l.SetActive(true);
            }

            switchSound.Play();
            lightsOn = true;
            PlayBackgroundMusic();
            RenderSettings.ambientIntensity = 1.11f;

        }
    }

    public void SetAudioPlaying(bool value)
    {
        audioPlaying = value;
    }

    public void PauseBackgroundMusic()
    {
        backgroundMusic.Pause();
    }
    
    public void PlayBackgroundMusic()
    {
    
        backgroundMusic.PlayDelayed(1);
    }
}
    