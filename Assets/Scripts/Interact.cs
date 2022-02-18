using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//this script can be found in the Component section under the option PRG/Interact
[AddComponentMenu("RPG Game/Character/Interact")]

public class Interact : MonoBehaviour
{
    #region RayCasting Info
    //RAY - A ray is an infinite line starting at origin and going in some direction.
    //RAYCASTING - Casts a ray, from point origin, in direction, of length maxDistance, against all colliders in the scene.
    //RAYCASTHIT - Strucutre used to get information back from a raycast
    #endregion
    //https://docs.unity3d.com/ScriptReference/Physics.Raycast.html
    //https://docs.unity3d.com/530/Documentation/ScriptReference/Physics.Raycast.html

    // Update is called once per frame
    void Update()
    {
        //if our interact key is pressed
        if (Input.GetKeyDown(KeyCode.E))
        {
            //create ray - //this is our line...Our Ray/Line doesnt a direction
            Ray interact;

            //this ray is shooting cut from the main cameras screen point center of screen
            //assinging origin
            interact = Camera.main.ScreenPointToRay(new Vector2(Screen.width/2, Screen.height/2));

            //create hit info
            RaycastHit hitInfo;

            //if this physics raycast hits something with 10 units
            if (Physics.Raycast(interact, out hitInfo, 10))
            {
                #region NPC tag
                //and that hits info is tagged NPC
                if (hitInfo.collider.tag == "NPC")
                {
                    Debug.Log("NPC");
                }
                #endregion

                #region Item
                //and that hits info is tagged Item
                if (hitInfo.collider.CompareTag("Item"))
                {
                    Debug.Log("Item");
                }
                #endregion

                #region Chest
                if (hitInfo.collider.tag == "Chest")
                {
                    Debug.Log("Chest");
                }
                #endregion
            }
        }
    }
    private void OnGUI()
    {
        //start positions x and y //size x and y 
        //GUI.Box(new Rect(0,0,0,0), "");
        for (int x = 0; x < 16; x++)
        {
            for (int y = 0; y < 9; y++)
            GUI.Box(new Rect(GameManager.scr.x*x, GameManager.scr.y*y, GameManager.scr.x, GameManager.scr.y),"");
        }
        GUI.Box(new Rect(0, 0, GameManager.scr.x*.25f, GameManager.scr.y*.25f), "");
    }

 }
