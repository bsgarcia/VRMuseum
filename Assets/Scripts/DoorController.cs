using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DoorController : MonoBehaviour 
{

    GameController gameController;
    PlayerController playerController;
  
    Vector3 myPos;
    AudioSource myAudio;
    Animator animator;

    private bool opened = false;
    private bool displayingText;
    private float radius = 2.4f;
   
	// Use this for initialization
	void Start () 
    {

        gameController = GameObject.FindWithTag("GameController").
            GetComponent<GameController>();
            
        playerController = GameObject.FindWithTag("PlayerController").
            GetComponent<PlayerController>();
                   
        animator = GetComponent<Animator>();
        myPos = transform.position;
        
	}

    // Update is called once per frame
    void Update()
    {

        //if (IsPlayerInRadius() && !opened)
        //{
        //    gameController.ShowMessage("Pressez la touche action pour ouvrir la porte.");
        //    displayingText = true;

        //    if (Input.GetKeyDown("e") 
        //        || playerController.keyCodes.ContainsKey("X")
        //        && Input.GetKeyDown(playerController.keyCodes["X"]))
        //    {
        //        Open();
        //        gameController.HideMessage();
        //        displayingText = false;
        //    }
        //    //gameController.ShowAudioUI();
        //}
        //else if (IsPlayerInRadius() && opened)
        //{
        //    gameController.ShowMessage("Press E to close the door.");
        //    displayingText = true;

        //    if (Input.GetKeyDown("e")
        //         || playerController.keyCodes.ContainsKey("X")
        //        && Input.GetKeyDown(playerController.keyCodes["X"]))
        //    {
        //        Close();
        //        gameController.HideMessage();
        //        displayingText = false;
        //    }

        //}

        //if (!IsPlayerInRadius() && displayingText) 
        //{
        //    gameController.HideMessage();
        //    displayingText = false;
        //}
    }


    private bool IsPlayerInRadius()
    {
        Collider[] colliders = Physics.OverlapSphere(myPos, radius);
        foreach (Collider hit in colliders)
        {
            Debug.Log("There are things in my FOV!");

            if (hit.transform.name.Contains("Player"))
            {
                Debug.Log("I see the player in my radius!");
                return true;
            }
        }

        return false;

    }

    private void Open()
    {
        opened = true;
        animator.SetBool("open", true);
    }

    private void Close()
    {
        opened = false;
        animator.SetBool("open", false);

    }
}
    