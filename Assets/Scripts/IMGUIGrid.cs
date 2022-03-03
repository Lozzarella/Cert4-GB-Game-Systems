using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IMGUIGrid : MonoBehaviour
{
    private void OnGUI()//allows you to render events and UI elements on the screen & runs on update every screen
    {
        //start positions x and y //size x and y 
        //GUI.Box(new Rect(0,0,0,0), "");//centre of the screen

        for (int x = 0; x < 16; x++) //For loop repeats until complete
        {
            for (int y = 0; y < 9; y++)
            {
                GUI.Box(new Rect(GameManager.scr.x * x, GameManager.scr.y * y, GameManager.scr.x, GameManager.scr.y), x + ":" + y);
            }
               
        }
        GUI.Box(new Rect(GameManager.scr.x * 7.875f, GameManager.scr.y * 4.375f, GameManager.scr.x * .25f, GameManager.scr.y * .25f), "");
        GUI.Box(new Rect(GameManager.scr.x * (8f - 0.125f), GameManager.scr.y * (4.5f - 0.125f), GameManager.scr.x * .25f, GameManager.scr.y * .25f), "");
        //half of 0.25 is 0.125
        //8-0.125 = 7.875
        //4.5-0.125
    }
}
