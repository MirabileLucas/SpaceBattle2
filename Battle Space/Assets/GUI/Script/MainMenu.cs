/* MainMenu.cs */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Provide the GUI of the main menu you get by launching the app.
/// </summary>
public class MainMenu : MonoBehaviour {

    // GUI COMPONENTS //
    public GameObject canava_MainMenu, canava_CreateMatch, canava_MainMenu_Option, canva_Join_Match;
    public Button b_Create_Match, b_Option, b_Join_Match;

    // MENU ENTITIES //
    private GameObject gameobj_CreateMatch;
    private GameObject obj_Join_Match;

    /// <summary>
    /// Initialize an instance of the <see cref="MainMenu"/> class.
    /// It sets up listeners and displays canvas.
    /// </summary>
    private void Start()
    {
        gameobj_CreateMatch = GameObject.Find("CreateMatch");
        canava_CreateMatch = gameobj_CreateMatch.GetComponent<CreateMatch>().canva_CreateMatch;
        
        b_Create_Match.onClick.AddListener(ButtonCreateonClick);
        b_Option.onClick.AddListener(OptionClick);
        b_Join_Match.onClick.AddListener(JoinonClick);
    }

    /// <summary>
    /// Occurs when a user clicks on <see cref="b_Join_Match"/> button.
    /// It changes canvas to display the joining match menu.
    /// </summary>
    public void JoinonClick()
    {
        canva_Join_Match.SetActive(true);

        obj_Join_Match = GameObject.Find("Join_Match");
        obj_Join_Match.GetComponent<Join_Match>().actif = true;

        canava_MainMenu.SetActive(false);
    }

    /// <summary>
    /// Occurs when a user clicks on <see cref="b_Option"/> button.
    /// It changes canvas to display the option menu.
    /// </summary>
    public void OptionClick()
    {
        canava_MainMenu_Option.SetActive(true);
        canava_MainMenu.SetActive(false);
    }

    /// <summary>
    /// Occurs when a user clicks on <see cref="b_Create_Match"/> button.
    /// It changes canvas to display the creation match menu.
    /// </summary>
    void ButtonCreateonClick()
    {
        canava_CreateMatch.SetActive(true);
        canava_MainMenu.SetActive(false);
    }

}
