using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;


public class AudioDescription : MonoBehaviour {

    
    public string animalName = "Dauphin d'Irrawadd";
    public string[] numbers = {"321445", "321446"};
    public float radius = 2.8f;
  
    Vector3 myPos;
    GameController gameController;
    PlayerController playerController;
    AudioSource description;

    private string listenMsg;

    private string stopMsg;

    private bool displayingText = false;    
    
	// Use this for initialization
	void Start () {

        gameController = GameObject.FindWithTag("GameController")
            .GetComponent<GameController>();
            
        playerController = GameObject.FindWithTag("PlayerController").
            GetComponent<PlayerController>();
            
        description = GetComponent<AudioSource>();
        myPos = transform.position;
        
        listenMsg = ("Voulez-vous écouter l'audio description '"
            + animalName + "' ? Pressez le bouton X."
        );
        
        stopMsg = ("Voulez-vous arrêter l'audio description '"
            + animalName + "' ? Pressez le bouton X."
        );
        
	}
	
	// Update is called once per frame
	void Update () {

        // If player is in the object radius
        // and the description is not playing
        // We want a message box to pop up 
        // indicating that an audio description
        // can be played.
        if (IsPlayerInRadius() && !description.isPlaying && !gameController.audioPlaying)
        {

            if (!gameController.lightsOn) {
            
                gameController.SwitchLightOff(numbers: numbers);
            }
            
            // pop the message
            gameController.ShowMessage(msg:listenMsg);
            
            displayingText = true;

            // If E is pressed play the audio description
            if (Input.GetKeyDown("e") 
                || playerController.keyCodes.ContainsKey("X")
                && Input.GetKeyDown(playerController.keyCodes["X"]) 
                //|| Input.GetKeyDown("Joystick 1 Button 0"))
                )
            {

                // Only shutdown the other lights.
                // use the numbers to exclude 
                // the lights from the current parent object
                gameController.SwitchLightOff(numbers: numbers);
                gameController.HideMessage();
                      
                description.PlayDelayed(1.0f);
                gameController.SetAudioPlaying(true);
                
                displayingText = false;

            }      
            
        }

        else if (description.isPlaying) 
        {

            gameController.ShowMessage(msg:stopMsg);

            displayingText = true;
                        
            if (Input.GetKeyDown("e") 
                || playerController.keyCodes.ContainsKey("X")
                && Input.GetKeyDown(playerController.keyCodes["X"])
                //|| Input.GetKeyDown("Joystick 1 Button 0"))
                )
            {
            
                gameController.SwitchLightOn();
                gameController.HideMessage();
               
                description.Stop();
                gameController.SetAudioPlaying(false);

                displayingText = false;
                
            }
            
        }

        else if (!IsPlayerInRadius() && displayingText && !description.isPlaying)
        {
        
            gameController.SwitchLightOn();
            //gameController.SetAudioPlaying(false);
            gameController.HideMessage();

            displayingText = false;
            
        }

	}

    private bool IsPlayerInRadius()
    {
        Collider[] colliders = Physics.OverlapSphere(myPos, radius);
        foreach (Collider hit in colliders) {
           // Debug.Log("There are things in my FOV!");
            if (hit.transform.name.Contains("Player")) {
                //Debug.Log("I see the player in my radius!");
                return true;
            }
        }
        return false;
    }
   
}



    