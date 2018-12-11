/* Spaceship_solo.cs */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Fire mode available.
/// </summary>
public enum FireMode_Solo
{
    /// <summary> No bonus or BonusShotFast type active.</summary>
    Default,
    /// <summary> BonusShotThrough type active.</summary>
    Through,
    /// <summary> No bonus or BonusShotFast type active.</summary>
    Triple
};

/// <summary>
/// Provides limits for the map where the players can move and a further one
/// to make properly disappear all projectiles.
/// </summary>
[System.Serializable]
public class BordersMap_Solo
{
    [Tooltip("offset from viewport borders for player's movement")]
    public float minXOffset = 1.5f, maxXOffset = 1.5f, minYOffset = 1.5f, maxYOffset = 1.5f;
    [HideInInspector] public float minX, maxX, minY, maxY;
}

/// <summary>
/// Represents the playable spaceship in solo mode,
/// it includes all the doable actions by a player like move, shoot...
/// </summary>
public class Spaceship_solo : MonoBehaviour
{
    // BORDERS //
    public BordersMap_Solo borders;

    // SPEED ATTRIBUTES //
    public float speed;
    public float torque;

    // EVENT LISTENER AXIS //
    public string horizontalAxis = "Horizontal";
    public string verticalAxis = "Vertical";

    // SPACESHIP MATERIAL //
    public GameObject ship;
    private Rigidbody2D rb;
    Camera mainCamera;
    public Joystick joystick;

    // SHOT DECLARATIONS //
    public Dictionary<string, GameObject> shotsDico = new Dictionary<string, GameObject>();
    public GameObject[] shots;
    public GameObject shot;
    public Dictionary<string, Transform> shotSpawnPointsDico = new Dictionary<string, Transform>();
    public Transform[] shotSpawnPoints;

    // SHOT ATTRIBUTES //
    public float fireRate;
    private float nextFire;
    public FireMode_Solo firemode;

    // SHOT FLAGS //
    public bool hasShotBonus = false;
    public bool hasSpeedBonus = false;

    // FUEL ATTRIBUTES //
    public float fuel = 100;
    public bool fuelWarning;

    // FUEL GUI //
    public SimpleHealthBar fuelBar;
    public Color fuelWarningColor;
    public Color fuelColor;
    

    /// <summary>
    /// Initializes a new instance of the <see cref="Spaceship_solo"/> class.
    /// </summary>
    void Start()
    {
        mainCamera = Camera.main;
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

        fuelWarning = false;
        fuelBar.UpdateBar(fuel, 100);
    }


    /// <summary>
    /// Update the state and behaviour of each <see cref="Spaceship_solo"/>
    /// instances once per frame. Allow player to move his spaceship.
    /// </summary>
    void Update()
    {
        move();
        /*if (fuel <= 15 && !fuelWarning)
        {
            fuelWarning = true;
            fuelBar.UpdateColor(fuelWarningColor);
        }
        if (fuel >= 15 && fuelWarning)
        {
            fuelWarning = false;
            fuelBar.UpdateColor(fuelColor);
        }*/
        if (fuel <= 0) Destroy(ship);


    }

    /// <summary>
    /// Move the spaceship according to the joystick orientation.
    /// It handles fuel reduction too.
    /// </summary>
    public void move()
    {
        Vector3 moveVector = (Vector3.right * joystick.Horizontal + Vector3.up * joystick.Vertical);

        if (moveVector != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(Vector3.forward, moveVector);
            transform.Translate(moveVector * speed * Time.deltaTime, Space.World);
            // FUEL HANDLING //
            fuel -= 0.04f;
            fuelBar.UpdateBar(fuel, 100);
        }

        transform.position = new Vector2    //if 'Player' crossed the movement borders, returning him back 
               (
               Mathf.Clamp(transform.position.x, borders.minX, borders.maxX),
               Mathf.Clamp(transform.position.y, borders.minY, borders.maxY)
               );
    }


    /// <summary>
    /// Create a shot according to optional bonus when the shoot button is clicked.
    /// </summary>
    public void shoot()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;

            switch (firemode)
            {
                case FireMode_Solo.Default:
                    shootDefault();
                    break;
                case FireMode_Solo.Through:
                    shootThrough();
                    break;
                case FireMode_Solo.Triple:
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
        o.GetComponent<DestroyByContact_Solo>().shooter = this;
    }

    /// <summary>
    /// Instantiate and spawn a shot with a BonusShotThrough type.
    /// </summary>
    private void shootThrough()
    {
        GameObject o = Instantiate(shot, shotSpawnPointsDico["Default"].position, shotSpawnPointsDico["Default"].rotation);
        o.GetComponent<DestroyByContactThrough_Solo>().shooter = this;
    }

    /// <summary>
    /// Instantiate and spawn a shot with a BonusShotTriple type.
    /// </summary>
    private void shootTriple()
    {
        GameObject o;

        o = Instantiate(shot, shotSpawnPointsDico["Center"].position, shotSpawnPointsDico["Center"].rotation);
        o.GetComponent<DestroyByContact_Solo>().shooter = this;

        o = Instantiate(shot, shotSpawnPointsDico["TripleLeft"].position, shotSpawnPointsDico["TripleLeft"].rotation);
        o.GetComponent<DestroyByContact_Solo>().shooter = this;

        o = Instantiate(shot, shotSpawnPointsDico["TripleRight"].position, shotSpawnPointsDico["TripleRight"].rotation);
        o.GetComponent<DestroyByContact_Solo>().shooter = this;
    }

}
