using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Scipt_MainMenu_Option : MonoBehaviour {

    public GameObject Canava_MainMenu_Option, Canava_MainMenu;
    public Button b_Return;

    private void Start()
    {
        
        b_Return.onClick.AddListener(ReturnClick);
    }

    public void ReturnClick()
    {
        Canava_MainMenu.SetActive(true);

        Canava_MainMenu_Option.SetActive(false);
       
    }

    // Update is called once per frame
    void Update()
    {

    }
}
