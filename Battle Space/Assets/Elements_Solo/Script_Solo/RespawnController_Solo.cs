/* RespawnController.cs */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Provide a system handling player respawn.
/// </summary>
public class RespawnController_Solo : MonoBehaviour
{
    // PLAYER MATERIAL //
    public GameObject spaceship;
    public GameObject camera;
    public Joystick joystick;
    public Button button;
    public SimpleHealthBar fuelBar;
    private GameObject instantiatedSpaceship;

    // SPAWN POSITION //
    public float halfSize_X;
    public float halfSize_Y;
    public float radius;
    public float minZ;

    // TIME OPTION //
    public float RespawnTime;

    // START RESPAWN FLAG //
    public bool waiting = false;

    /// <summary>
    /// Update the state and behaviour of a <see cref="RespawnController_Solo"/>
    /// instance once per frame. Check if a player need to respawn
    /// </summary>
    void Update()
    {
        if (waiting == false && camera.GetComponent<Camera_solo>().target == null)
        {
            waiting = true;

            StartCoroutine(Respawn());
        }
    }


    /// <summary>
    /// Handle the player respawn and gives him back authority to play.
    /// It makes spawn the spaceship in a random way, then 
    /// re-affects all the material (joystick, button, camera).
    /// </summary>
    /// <returns>A temporary suspension of the StartCoroutine method.</returns>
    /// <seealso cref="YieldInstruction"/>
    /// <seealso cref="Coroutine"/>
    IEnumerator Respawn()
    {
        while (waiting)
        {
            // DEFINING RESPAWN POSITION //
            Vector2 spawnPosition = new Vector2(Random.Range(-halfSize_X, halfSize_X), Random.Range(-halfSize_Y, halfSize_Y));
            Collider2D other = Physics2D.OverlapCircle(spawnPosition, radius, Physics2D.AllLayers, minZ);
            if (other != null) continue;

            // WAIT FOR RESPAWN //
            yield return new WaitForSeconds(RespawnTime);

            // START OF RESPAWNING SEQUENCE //
            instantiatedSpaceship = Instantiate(spaceship, spawnPosition, Quaternion.Euler(0, 0, Random.Range(0, 360)));

            // SETTING UP PLAYER MATERIAL //
            camera.GetComponent<Camera_solo>().target = instantiatedSpaceship.transform;
            instantiatedSpaceship.GetComponent<Spaceship_solo>().joystick = joystick;
            instantiatedSpaceship.GetComponent<Spaceship_solo>().fuelBar = fuelBar;
            button.onClick.AddListener(instantiatedSpaceship.GetComponent<Spaceship_solo>().shoot);

            waiting = false;
        }
    }
}
