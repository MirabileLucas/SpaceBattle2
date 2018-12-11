/* MainMenu_Option.cs */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Provide the GUI for option menu in the main menu.
/// </summary>
public class MainMenu_Option : MonoBehaviour {

    // GUI COMPONENTS //
    public GameObject Canava_MainMenu_Option, Canava_MainMenu;
    public Button b_Return,b_Quit;

    /// <summary>
    /// Initialize an instance of <see cref="MainMenu_Option"/> class.
    /// It also sets up listeners.
    /// </summary>
    private void Start()
    {
        
        b_Return.onClick.AddListener(ReturnClick);
        b_Quit.onClick.AddListener(QuitonClick);
    }

    /// <summary>
    /// Occurs when a user clicks on quit button.
    /// It quits the application.
    /// </summary>
    void QuitonClick()
    {
        Application.Quit();
    }

    /// <summary>
    /// Occurs when a user clicks on return button.
    /// It sends the user back to the main menu.
    /// </summary>
    public void ReturnClick()
    {
        Canava_MainMenu.SetActive(true);

        Canava_MainMenu_Option.SetActive(false);
       
    }
}
