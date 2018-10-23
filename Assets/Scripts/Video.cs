using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;


public class Video : MonoBehaviour {

    GameController gameController;
    
    Vector3 myPos;

    VideoPlayer description;
    
    float radius = 4;
   
	// Use this for initialization
	void Start () {

        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
        description = GetComponent<VideoPlayer>();
        description.enabled = false;
        myPos = transform.position;
        
	}
	
	// Update is called once per frame
	void Update () {
        
        if (IsPlayerInRadius() && !description.isPlaying){
            //gameController.ShowAudioUI();
            description.enabled = true;
            description.Play();
            
        }

        else if (!IsPlayerInRadius() && description.isPlaying) {
            description.enabled = false;
            //description.Stop();
        }
       
		
	}
    
    public void RunAudioDescription () {
        description.Play();
    }

    bool IsPlayerInRadius()
    {
        Collider[] colliders = Physics.OverlapSphere(myPos, radius);
        foreach (Collider hit in colliders) {
            Debug.Log("There are things in my FOV!");

            if (hit.transform.name.Contains("Player")) {
                Debug.Log("I see the player in my radius!");
                return true;
            }
        }

        return false;
       
    }
   
}
    