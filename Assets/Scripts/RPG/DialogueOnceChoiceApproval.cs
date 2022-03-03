using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueOnceChoiceApproval : MonoBehaviour
{
    [Header("Display Dialogue")]
    public string[] text;
    [Header("Index Markers")]
    public int choiceIndex;
    public int index;
    [Header("How much the NPC likes us")]
    public int approval;
    [Header("Can We See the DLG")]
    public bool showDlg;
    [Header("The dialogue based on approval")]
    public string[] likeText;
    public string[] neutralText;
    public string[] dislikeText;

    private void Start()
    {
        //set dialogue and values to neutral
        approval = 0;
    }

    void OnGUI()
    {
        if (showDlg)
        {
            GUI.Box(new Rect(GameManager.scr.x * 0, GameManager.scr.y * 6, GameManager.scr.x * 16, GameManager.scr.y * 3), text[index]);//Box to display your Dialogue

            if (index < text.Length - 1 && index != choiceIndex)//if we are not at the end and not on choice
            {
                if (GUI.Button(new Rect(GameManager.scr.x * 15, GameManager.scr.y * 8.5f, GameManager.scr.x * 1, GameManager.scr.y * 0.5f), "Next"))//next
                {
                    index++;
                }
            }

            else if (index == choiceIndex) // else if we are on the choice
            {
                if (GUI.Button(new Rect(GameManager.scr.x * 14, GameManager.scr.y * 8.5f, GameManager.scr.x * 1, GameManager.scr.y * 0.5f), "Yes"))//positive option - yes
                {
                    //like you
                    //change what we are reading from
                    approval = 1;
                    index++;//move on                
                    
                }

                else if (GUI.Button(new Rect(GameManager.scr.x * 15, GameManager.scr.y * 8.5f, GameManager.scr.x * 1, GameManager.scr.y * 0.5f), "No"))//negative - no
                {
                    //like you less
                    //change what we are reading from
                    approval = -1;
                    index = text.Length - 1;//skip to last line
                }
            }                   

            else
            {
                if (GUI.Button(new Rect(GameManager.scr.x * 15, GameManager.scr.y * 8.5f, GameManager.scr.x * 1, GameManager.scr.y * 0.5f), "Bye."))//bye button
                {
                    index = 1;//set index to 1
                    showDlg = false;//ends convo/exit convo
                }

            }                   

        }

    }
}
