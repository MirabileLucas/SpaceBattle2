/* Screen_Rotation.cs */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Provide a system handling screen rotation.
/// </summary>
public class Screen_Rotation : MonoBehaviour {

    /// <summary>
    /// Initialize an instance of <see cref="Screen_Rotation"/> class.
    /// It enables auto rotation of the app when you rotate your phone.
    /// </summary>
    void Start()
    {
        Screen.autorotateToPortrait = false;
        Screen.autorotateToPortraitUpsideDown = false;
        Screen.autorotateToLandscapeLeft = true;
        Screen.autorotateToLandscapeRight = true;

        Screen.orientation = ScreenOrientation.AutoRotation;
    }
}
