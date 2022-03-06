using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//this script can be found in the Component section under the option PRG/Character Movement
[AddComponentMenu("RPG Game/Character/Movement")]
//This script requires the componet Character controller to be attached to the Game Object
[RequireComponent(typeof(CharacterController))]

public class PlayerMovement : MonoBehaviour
{
    #region Extra Study
    //Input Manager(https://docs.unity3d.com/Manual/class-InputManager.html)
    //Input(https://docs.unity3d.com/ScriptReference/Input.html)
    //CharacterController allows you to move the character kinda like Rigidbody (https://docs.unity3d.com/ScriptReference/CharacterController.html)
    #endregion

    #region Variables
    [Header("Character")]
    [Tooltip("use this to apply movement in worldspace")]
    public CharacterController charC; //this is our reference variable to the character controller
    public Vector3 moveDir; //we will use this apply movement in worldspace
    [Header("Speeds")]//headers create a header for the variable directly below
    public float moveSpeed = 5f;
    public float jumpSpeed = 8f, gravity = 20f;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        //assign a compontent to our reference
        charC = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        if (GameManager.gamePlayStates == GamePlayStates.Game)
        {
            if (charC.isGrounded)//if our character is grounded
            {
                //set moveDir to the inputs direction
                moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
                //moveDir's forward is changed from global z (forward) to the Game Objects local z (forward)//allows us to move where player is facing
                moveDir = transform.TransformDirection(moveDir); //allows us to move where player is facing
                //moveDir is multiplied by speed so we move at a decent pace

                moveDir *= moveSpeed;
                //if the input buttion for jump is pressed then
                if (Input.GetButton("Jump"))
                {
                    //our moveDir.y is equal to our jump speed
                    moveDir.y = jumpSpeed;
                }
            }
            //regardless of if we are grounded or not the players moveDir.y is always affected by gravity timesed my time.deltaTime to normalize it
            moveDir.y -= gravity * Time.deltaTime;
            //we then tell the character Controller that it is moving in a direction multiplied Time.deltaTime
            charC.Move(moveDir*Time.deltaTime);
        }

    }
}
