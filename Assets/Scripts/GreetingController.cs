using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GreetingController : MonoBehaviour
{
    public GameObject firstMessage;
    public GameObject secondMessage;

    AudioSource notif;
   
    void Start() 
    {
        firstMessage.SetActive(true);
        secondMessage.SetActive(false);
        notif = GetComponent<AudioSource>();
    }
    
    //void Update() 
    //{
    
        
    
    //}

    public void ShowFirstMessage()
    {
        firstMessage.SetActive(true);
    }
    
    public void HideFirstMessage()
    {
        firstMessage.SetActive(false);
        notif.Play();
    }
    
    public void ShowSecondMessage()
    {
        secondMessage.SetActive(true);
    }
    
    public void HideSecondMessage()
    {   
        secondMessage.SetActive(false);
        notif.Play();
    }
    
}
