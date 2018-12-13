using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Screen_Rotation : MonoBehaviour {

    void Start()
    {
        Screen.autorotateToPortrait = false;

        Screen.autorotateToPortraitUpsideDown = true;

        Screen.orientation = ScreenOrientation.AutoRotation;
    }
}
