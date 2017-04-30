﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class MenuScript : MonoBehaviour {

    public Canvas quitMenu;
    public Canvas credits;
    public Button multiplayerText;
    public Button singleplayerText;
    public Button exitText;

    Canvas menu;
    bool creditsEnabled = false;

	void Start ()
    {
        menu = this.GetComponent<Canvas>();
        quitMenu = quitMenu.GetComponent<Canvas>();
        multiplayerText = multiplayerText.GetComponent<Button>();
        singleplayerText = singleplayerText.GetComponent<Button>();
        exitText = exitText.GetComponent<Button>();

        quitMenu.enabled = false;
        credits.enabled = false;
	}

    public void ExitPress()
    {
        quitMenu.enabled = true;
        multiplayerText.enabled = false;
        singleplayerText.enabled = false;
        exitText.enabled = false;
    }

    public void NoPress()
    {
        quitMenu.enabled = false;
        multiplayerText.enabled = true;
        singleplayerText.enabled = true;
        exitText.enabled = true;
    }

    public void MultiplayerPress()
    {
        GameManager.SetGameType(GameType.multiplayer);
        SceneManager.LoadScene("Sandbox");
    }

    public void SingleplayerPress()
    {
        GameManager.SetGameType(GameType.singleplayer);
        SceneManager.LoadScene("Sandbox");
    }

    public void ToggleCredits()
    {
        if (!creditsEnabled)
        {
            menu.enabled = false;
            credits.enabled = creditsEnabled = true;
        }
        else
        {
            menu.enabled = true;
            credits.enabled = creditsEnabled = false;
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
