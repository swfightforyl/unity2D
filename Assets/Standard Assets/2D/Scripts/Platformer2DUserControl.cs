﻿using UnityEngine;

namespace UnitySampleAssets._2D
{

    [RequireComponent(typeof (PlatformerCharacter2D))]
    public class Platformer2DUserControl : MonoBehaviour
    {
        private PlatformerCharacter2D character;
        private bool jump;

        private void Awake()
        {
            character = GameObject.Find("Player1").GetComponent<PlatformerCharacter2D>();
        }

        private void Update()
        {
            if(!jump)
            // Read the jump input in Update so button presses aren't missed.
			if(Input.GetKeyDown(KeyCode.W)){                  
				jump = true;
			}      
        }


        float timeLost = 0;
        private void FixedUpdate()
        {
            // Read the inputs.
            bool crouch = Input.GetKey(KeyCode.LeftControl);
			float h = Input.GetAxis("Horizontal");
            // Pass all parameters to the character control script.
            character.Move(h, crouch, jump);
            jump = false;

            //手动触发切换武器            
            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (Time.time-timeLost>1)
                {
                    Debug.Log("you have clicked button Q");
                    character.ChangeWeapon();
                }
                timeLost = Time.time;
            }
        }
     
    }
}