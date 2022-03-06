using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GamePlayStates gamePlayStates;
    public static Vector2 scr;

    // Start is called before the first frame update
    void Start()
    {
        scr.x = Screen.width / 16;
        scr.y = Screen.height / 9;
        gamePlayStates = GamePlayStates.Game;
    }

    // Update is called once per frame
    void Update()
    {
        if (Screen.width/16 != scr.x)
        {
            scr.x = Screen.width / 16;
            scr.y = Screen.height / 9;
        }

        switch (gamePlayStates)//only goes through 1 condition
        {
            case GamePlayStates.PreGame://a case is the same as an if or else if which will allow us to check our condition
                if (!Cursor.visible)
                {
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                }
                break;
            case GamePlayStates.Game:
                if (Cursor.visible)
                {
                    Cursor.visible = false;
                    Cursor.lockState = CursorLockMode.Locked;
                }
                break;
            case GamePlayStates.MenuPause:
                if (!Cursor.visible)
                {
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                }
                break;
            case GamePlayStates.PostGame:
                if (!Cursor.visible)
                {
                    Cursor.visible = false;
                    Cursor.lockState = CursorLockMode.Locked;
                }
                break;
            default://default is your else and gets anything that you didnt state above
                if (!Cursor.visible)
                {
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                }
                break;
        }
    }
}

public enum GamePlayStates
{
    PreGame, //main menu scenes
    Game, //when the game is running
    MenuPause, //when the menu is paused
    PostGame //dead respawn 
}
