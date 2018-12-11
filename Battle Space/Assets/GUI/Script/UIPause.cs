/* UIPause.cs */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

/// <summary>
/// Provide a GUI for the pause menu.
/// </summary>
public class UIPause : MonoBehaviour {

    // GUI COMPONENTS //
    public GameObject Canva_UIPause, Canva_IG_GUI;
    public Button b_Return,b_quit,b_menu;

    // SERVER FLAG //
    public bool isServer=false;

    /// <summary>
    /// Initialize an instance of the <see cref="UIPause"/> class.
    /// It also sets up listeners.
    /// </summary>
    private void Start()
    {
        b_Return.onClick.AddListener(ButtonStartonClick);
        b_quit.onClick.AddListener(QuitonClick);
        b_menu.onClick.AddListener(MenuonClick);
    }

    public void SetIsServer(bool t) {
        this.isServer = t;
    }

    /// <summary>
    /// Occurs when a player clicks on <see cref="b_quit"/> button.
    /// It stops the <see cref="NetworkManager"/> instance
    /// and quits the application.
    /// </summary>
    void QuitonClick() {
        if (isServer)
        {
            NetworkManager.singleton.StopServer();
        }
        else
        {
            NetworkManager.singleton.StopClient();
        }
        Application.Quit();
    }

    /// <summary>
    /// Occurs when a player clicks on <see cref="b_menu"/> button.
    /// It disconnect the player of the game
    /// and send him back to the main menu.
    /// </summary>
    void MenuonClick() {
        Canva_UIPause.SetActive(false);
        if (isServer) {
            NetworkManager.singleton.StopHost();
        }
        else
        {
            NetworkManager.singleton.StopClient();
        }
        
        SceneManager.LoadScene("Scene_GUI");
    }

    /// <summary>
    /// Occurs when a player clicks on <see cref="b_Return"/> button.
    /// The player quits pause menu.
    /// </summary>
    void ButtonStartonClick()
    {
        Canva_IG_GUI.SetActive(true);

        Canva_UIPause.SetActive(false);
    }

}
