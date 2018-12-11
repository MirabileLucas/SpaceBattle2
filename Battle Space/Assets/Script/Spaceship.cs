/* Spaceship.cs */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

/// <summary>
/// Fire mode availables
/// </summary>
public enum FireMode {
    /// <summary> No bonus or BonusShotFast type active </summary>
    Default,
    /// <summary> BonusShotThrough type active</summary>
    Through,
    /// <summary> No bonus or BonusShotFast type active</summary>
    Triple
};

    /// <summary>
    /// Provides limits for the map where the players can move and a further one
    /// to make properly disappear all projectiles.
    /// </summary>
[System.Serializable]
public class BordersMap
{
    [Tooltip("offset from viewport borders for player's movement")]
    public float minXOffset = 1.5f, maxXOffset = 1.5f, minYOffset = 1.5f, maxYOffset = 1.5f;
    [HideInInspector] public float minX, maxX, minY, maxY;
}

/// <summary>
/// Represents the playable spaceship in networked games,
/// it includes all the doable actions by a player like move, shoot...
/// </summary>
public class Spaceship : NetworkBehaviour {
    // BORDERS //
    public BordersMap borders;

    // SPEED ATTRIBUTES //
    public float speed;
    public float torque;

    // EVENT LISTENER AXIS //
    public string horizontalAxis = "Horizontal";
    public string verticalAxis = "Vertical";

    // SPACESHIP MATERIAL //
    private Rigidbody2D rb;
    public float fuel = 100;

    // CANVAS ATTRIBUTES //
    public Canvas canvas;
    public FixedJoystick joystick;

    // SHOT DECLARATIONS //
    public Dictionary<string, GameObject> shotsDico = new Dictionary<string, GameObject>();
    public Dictionary<string, Transform> shotSpawnPointsDico = new Dictionary<string, Transform>();
    public GameObject[] shots;
    public GameObject shot;
    public Transform[] shotSpawnPoints;

    // SHOT ATTRIBUTES // 
    public float fireRate;
    private float nextFire;
    public FireMode firemode;

    // SHOT FLAGS //
    public bool hasShotBonus = false;
    public bool hasSpeedBonus = false;

    // AUTHORITY FLAG //
    public bool localPlayer;

    /// <summary>
    /// Allow the identification by the parent (localPlayer or not).
    /// </summary>
     /// <param name="local"> Specifies if his parent is the localPLayer 
    /// (this means running his own game instance).
    /// </param>
    public void setLocalPlayer(bool local)
    {
        this.localPlayer = local;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Spaceship"/> class.
    /// </summary>
    void Start () {
        
        rb = GetComponent<Rigidbody2D>();
        borders.maxY = 100;
        borders.maxX = 100;
        borders.minY = -100;
        borders.minX = -100;

        shotsDico.Add("Default", shots[0]);
        shotsDico.Add("Fast", shots[1]);
        shotsDico.Add("Triple", shots[2]);
        shotsDico.Add("Through", shots[3]);

        shotSpawnPointsDico.Add("Default", shotSpawnPoints[0]);
        shotSpawnPointsDico.Add("Center", shotSpawnPoints[0]);
        shotSpawnPointsDico.Add("TripleLeft", shotSpawnPoints[1]);
        shotSpawnPointsDico.Add("TripleRight", shotSpawnPoints[2]);

    }


    /// <summary>
    /// Update the state and behaviour of each <see cref="Spaceship"/>
    /// instances once per frame. Allow player to move is spaceship.
    /// </summary>
    void Update () {
        if (!localPlayer)
        {
            canvas.enabled = false;
            return;
        }
        canvas.enabled = true;
        move();

        //if (fuel == 0) Destroy(this);
    }

    /// <summary>
    /// Move the spaceship according to the joystick orientation.
    /// </summary>
    public void move()
    {
        Vector3 moveVector = (Vector3.right * joystick.Horizontal + Vector3.up * joystick.Vertical);

        if (moveVector != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(Vector3.forward, moveVector);
            transform.Translate(moveVector * speed * Time.deltaTime, Space.World);
            //fuel -= 0.04f;
        }

        //if 'Player' crossed the movement borders, returning him back 
        transform.position = new Vector2                   
            (
               Mathf.Clamp(transform.position.x, borders.minX, borders.maxX),
               Mathf.Clamp(transform.position.y, borders.minY, borders.maxY)
            );
    }

    /// <summary>
    /// Create a shot according to optional bonus when the shoot button is clicked.
    /// </summary>
    /// <remarks> Command attribute indicates to the developper,
    /// that method is called by a client instance but,
    /// it's running by server.
    /// </remarks>
    [Command]
    public void CmdShoot()
    {
        if (!localPlayer) return;
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;

            switch (firemode)
            {
                case FireMode.Default:
                    shootDefault();
                    break;
                case FireMode.Through:
                    shootThrough();
                    break;
                case FireMode.Triple:
                    shootTriple();
                    break;
            }
        }
    }

    /// <summary>
    /// Instantiate and spawn a shot without bonus or with a BonusShotFast type.
    /// </summary>
    private void shootDefault()
    {
        GameObject o = Instantiate(shot, shotSpawnPointsDico["Default"].position, shotSpawnPointsDico["Default"].rotation);
        o.GetComponent<DestroyByContact>().shooter = this;
        NetworkServer.Spawn(o);
    }

    /// <summary>
    /// Instantiate and spawn a shot with a BonusShotThrough type.
    /// </summary>
    private void shootThrough()
    {
        GameObject o = Instantiate(shot, shotSpawnPointsDico["Default"].position, shotSpawnPointsDico["Default"].rotation);
        o.GetComponent<DestroyByContactThrough>().shooter = this;
        NetworkServer.Spawn(o);
    }

    /// <summary>
    /// Instantiate and spawn a shot with a BonusShotTriple type.
    /// </summary>
    private void shootTriple()
    {
        GameObject o;
        GameObject o1;
        GameObject o2;

        o = Instantiate(shot, shotSpawnPointsDico["Center"].position, shotSpawnPointsDico["Center"].rotation);
        o.GetComponent<DestroyByContact>().shooter = this;
        o1 = Instantiate(shot, shotSpawnPointsDico["TripleLeft"].position, shotSpawnPointsDico["TripleLeft"].rotation);
        o1.GetComponent<DestroyByContact>().shooter = this;
        o2 = Instantiate(shot, shotSpawnPointsDico["TripleRight"].position, shotSpawnPointsDico["TripleRight"].rotation);
        o2.GetComponent<DestroyByContact>().shooter = this;

        NetworkServer.Spawn(o);
        NetworkServer.Spawn(o1);
        NetworkServer.Spawn(o2);
    }

}
