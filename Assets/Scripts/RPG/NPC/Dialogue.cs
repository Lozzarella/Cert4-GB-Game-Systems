using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    [Header("Dialogue Display")]
    public string[] text;
    [Header("Current Index")]
    public int index;
    [Header("Show Dialogue")]
    public bool showDlg;

    void OnGUI()
    {
        if (showDlg)
        {
            //box
            //entire bottom third of the screen
            GUI.Box(new Rect(GameManager.scr.x * 0, GameManager.scr.y * 6, GameManager.scr.x * 16, GameManager.scr.y * 3), text[index]);
                        
            if (index < text.Length -1)//if we are not at the end of our conversation
            {
                //button to increment the dialogue by one
                if (GUI.Button(new Rect(GameManager.scr.x * 15, GameManager.scr.y * 8.5f, GameManager.scr.x * 1, GameManager.scr.y * 0.5f),"Next"))
                {
                    index++;
                }

            }

            else // we are on the last line of dialogue
            {
                //button to exit the dialogue
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
