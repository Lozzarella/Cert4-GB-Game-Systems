using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueOneChoice : Dialogue
{
    [Header("Choice Index")] 
    public int choiceIndex;

    void OnGUI()
    {
        if (showDlg)
        {
            //box
            GUI.Box(new Rect(GameManager.scr.x * 0, GameManager.scr.y * 6, GameManager.scr.x * 16, GameManager.scr.y * 3), text[index]);

            //if we are not at the end of our dialogue and we are not at our choice
            if (index < text.Length - 1 && index != choiceIndex) //not choice
            {
                //Button - Next
                // ++
                if (GUI.Button(new Rect(GameManager.scr.x * 15, GameManager.scr.y * 8.5f, GameManager.scr.x * 1, GameManager.scr.y * 0.5f), "Next"))
                {
                    index++;
                }
            }

            //if we are at the choice
            else if (index == choiceIndex) //choice
            {
                //Buttion - Yes 14
                //++
                if (GUI.Button(new Rect(GameManager.scr.x * 14, GameManager.scr.y * 8.5f, GameManager.scr.x * 1, GameManager.scr.y * 0.5f), "Yes"))
                {
                    index++;
                }

                else if (GUI.Button(new Rect(GameManager.scr.x * 15, GameManager.scr.y * 8.5f, GameManager.scr.x * 1, GameManager.scr.y * 0.5f), "No"))
                {
                    //button - no 15
                    //end of dlg = text.Length -1
                    index = text.Length-1;
                }

            }
            
            //we are at the end of our dialogue
            else //bye
            {
                //button - Bye
                //0
                //false
                if (GUI.Button(new Rect(GameManager.scr.x * 15, GameManager.scr.y * 8.5f, GameManager.scr.x * 1, GameManager.scr.y * 0.5f), "Bye."))
                {
                    index = 0;
                    showDlg = false;
                    GameManager.gamePlayStates = GamePlayStates.Game;
                }
            }
        }
    }
}
