/* RespawnController.cs */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

/// <summary>
/// Provide a system handling player respawn in networked games.
/// </summary>
public class RespawnController : NetworkBehaviour
{
    // PLAYER MATERIAL // 
    public GameObject player;
    public Spaceship spaceship;//public GameObject spaceship;
    public GameObject camera;
    public FixedJoystick joystick;
    public Button button;
    private Spaceship instantiatedSpaceship;//private GameObject instantiatedSpaceship;

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
    /// Update the state and behaviour of a <see cref="RespawnController"/>
    /// instance once per frame. Check if a player need to respawn
    /// </summary>
    void Update()
    {
        if (waiting == false && camera.GetComponent<camera>().target == null)
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
        while(waiting)
        {
            // DEFINING RESPAWN POSITION //
            Vector2 spawnPosition = new Vector2(Random.Range(-halfSize_X, halfSize_X), Random.Range(-halfSize_Y, halfSize_Y));
            Collider2D other = Physics2D.OverlapCircle(spawnPosition, radius, Physics2D.AllLayers, minZ);
            if (other != null) continue;

            // WAIT FOR RESPAWN //
            yield return new WaitForSeconds(RespawnTime);

            // START OF RESPAWNING SEQUENCE //
            instantiatedSpaceship = Instantiate(spaceship, spawnPosition, Quaternion.Euler(0, 0, Random.Range(0, 360)));
            instantiatedSpaceship.transform.parent = player.transform;
            foreach (NetworkTransformChild networkTransformChild in player.GetComponents<NetworkTransformChild>())
            {
                if (networkTransformChild.target == null)
                {
                    networkTransformChild.target = instantiatedSpaceship.transform; ;
                    break;
                }
            }            //NetworkServer.Spawn(instantiatedSpaceship.gameObject);

            // SETTING UP AUTHORITY //
            if (isLocalPlayer)
                instantiatedSpaceship.setLocalPlayer(true);
            else
                instantiatedSpaceship.setLocalPlayer(false);

            // SETTING UP PLAYER MATERIAL //
            camera.GetComponent<camera>().target = instantiatedSpaceship.transform;
            instantiatedSpaceship.joystick = joystick;
            button.onClick.AddListener(instantiatedSpaceship.CmdShoot);

            waiting = false;
        }
    }
}
