using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{   
    
    [HideInInspector]
    public GameObject gameControllerObject;
    [HideInInspector]
    public Dictionary<string, KeyCode> keyCodes = new Dictionary<string, KeyCode>();
    
    public float speed = 5.0f;

    public bool keyboardActivation = false;
    public bool bluetoothController = true;


    GameController gameController;

    AudioSource footstep;

    bool detectionDone = false;
      
   
    void Start()
    {

        gameController = gameControllerObject.GetComponent<GameController>();
        footstep = GetComponent<AudioSource>();
    }

    // each frame update
    void Update()
    {
        // if input detection is not finished
        if (bluetoothController && !detectionDone)
        {
            GetKey();
        }

        // if all keys are saved
        else if (bluetoothController && detectionDone)
        {
            if (Input.GetKey(keyCodes["up"]))
            {
                MoveForward();
                
            }

            //else if (Input.GetKey(keyCodes["down"]))
            //{

            //    MoveBack();
            //}

            else {
                footstep.Stop();
            }
        }

        if (keyboardActivation)
        {

            if (Input.GetKey("z"))
            {
                MoveForward();

            }

            else if (Input.GetKey("s"))
            {
                MoveBack();

            }

            else if (Input.GetKey("q"))
            {

                MoveLeft();
            }

            else if (Input.GetKey("d"))
            {
                MoveRight();
            }

            else if (Input.GetKey("x"))
            {
                ;
            }
            
            else {
               footstep.Stop();
            }

        }
    }

    private void GetKey()
    {
        // Little workaround to get inputs working with bluetooth controller
        // on android.
        // First check if all keys are not already registered

        // Iter on all keycodes
        foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
        {
            // If the current key is pressed
            if (Input.GetKey(vKey))
            {
                // If first key to register, save it as "up"
                if (vKey.ToString().Contains("Joystick") && keyCodes.Keys.Count == 0)
                {
                    keyCodes.Add("up", vKey);
                    gameController.greetingController.HideFirstMessage();
                    gameController.greetingController.ShowSecondMessage();
                }

                //// If second key to register save it as down
                //else if (vKey.ToString().Contains("Joystick") && keyCodes.Keys.Count == 1
                //&& vKey != keyCodes["up"])
                //{
                //    keyCodes.Add("down", vKey);
                //    MoveBack();
                    
                //    //gameController.HidePressDownUI();
                //    //gameController.ShowPressActionUI();

                //}

                else if (vKey.ToString().Contains("Joystick") && keyCodes.Keys.Count == 1
                        && vKey != keyCodes["up"])
                {
                    keyCodes.Add("X", vKey);

                    gameController.greetingController.HideSecondMessage();

                    // all keys are saved!
                    detectionDone = true;
                }
            }
        }
    }

    private void MoveForward()
    {
        // get camera orientation
        Vector3 direction = Camera.main.transform.forward;

        // fixed y
        direction.y = 0.0f;

        // Move
        transform.position += direction * speed * Time.deltaTime;
        PlayFootstep();

    }

    private void MoveBack()
    {
        // get camera orientation
        Vector3 direction = Camera.main.transform.forward;

        // fixed y
        direction.y = 0.0f;

        transform.position -= direction * speed * Time.deltaTime;
        
        PlayFootstep();

    }

    private void MoveRight()
    {
        // get camera orientation
        Vector3 direction = Camera.main.transform.right;

        // fixed y and z
        direction.y = 0.0f;

        transform.position += direction * speed * Time.deltaTime;

        PlayFootstep();
    }

    private void MoveLeft()
    {
        // get camera orientation
        Vector3 direction = Camera.main.transform.right;

        // fixed y and z
        direction.y = 0.0f;

        transform.position -= direction * speed * Time.deltaTime;
        
        PlayFootstep();

    }

    private void PlayFootstep()
    {
        if (!footstep.isPlaying)
        {
            footstep.Play();
        }
    }
}  
    