using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueOnceChoiceApproval : DialogueOneChoice
{
    //inherited data
    //string[] text - this si the lines of dialogue we are showing
    //int index - the current line of dialogue we are shoing
    //bool showDlg - the ability to turn on and off UI
    //int choiceIndex - this is the index of our quest...the marker for where to put the yes/no response
   [Header("How much the NPC likes us")]
    public int approval;//-1,0,1
   [Header("The dialogue based on approval")]
    public string[] likeText;//1
    public string[] neutralText;//0
    public string[] dislikeText;//-1

    private void Start()
    {
        //set dialogue and values to neutral
        approval = 0;
        ChangeDlg(approval);
    }

    private void ChangeDlg(int approval)
    {
        switch (approval)//assigns the values of text according to approval
        {
            case -1:
                text = dislikeText;
                break;
            case 0:
                text = neutralText;
                break;
            case 1:
                text = likeText;
                break;
        }
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
                    index++;//move on    
                    if (approval < 1)
                    {
                        approval++;
                    }
                    ChangeDlg(approval);
                                
                    
                }

                else if (GUI.Button(new Rect(GameManager.scr.x * 15, GameManager.scr.y * 8.5f, GameManager.scr.x * 1, GameManager.scr.y * 0.5f), "No"))//negative - no
                {
                    index = text.Length - 1;//skip to last line
                    if (approval > -1)
                    {
                        approval--;
                    }
                    ChangeDlg(approval);
                }
            }                   

            else
            {
                if (GUI.Button(new Rect(GameManager.scr.x * 15, GameManager.scr.y * 8.5f, GameManager.scr.x * 1, GameManager.scr.y * 0.5f), "Bye."))//bye button
                {
                    index = 0;
                    showDlg = false;//ends convo/exit convo
                    GameManager.gamePlayStates = GamePlayStates.Game;
                }

            }                   

        }

    }
}
