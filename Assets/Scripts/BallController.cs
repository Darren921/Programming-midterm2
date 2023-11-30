using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    private bool Swap;
    private bool Started;
    [SerializeField] float speed;
    private bool isFalling;
    LayerMask mask;
    

    private void Start()
    {
        isFalling = false;
        Started = false;
        Swap = false;
        InputManager.Init(this);
        InputManager.EnableInGame();
         mask = LayerMask.GetMask("Platform");
        
    }

    private void Update()
    {
       

        if (Started == true && isFalling == false ) 
        {
            Debug.DrawRay(gameObject.transform.position, -transform.up * 100,Color.red, 1);
            if (!Physics.Raycast(gameObject.transform.position, -transform.up, 1000, mask) == false)
            {

                isFalling = true;
            }
            else
            {
                isFalling = false;
   
            }
            
            if (Swap == false)
            {
                gameObject.transform.position += new Vector3(speed, 0, 0);
            }
            if (Swap == true)
            {
                gameObject.transform.position += new Vector3(0, 0, speed);
            }
          
        }
        if (isFalling == true) 
        {
            GameObject.Find("Ball").GetComponent<Rigidbody>().useGravity = true;
            this.enabled = false;
        }
        


    }


   

    public void startGame()
    {
        if (Started == false)
        {
            Started = true;
            return;
        }
    }

    public void SwitchAxisMovement()
    {
        if (Swap == false)
        {
            Swap = true;
            return;
        }
        if (Swap == true)
        {
            Swap = false;
            return;
        }
    }



}
