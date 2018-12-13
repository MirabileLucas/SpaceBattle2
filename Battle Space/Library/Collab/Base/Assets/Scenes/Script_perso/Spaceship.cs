using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public enum FireMode { Default, Through, Triple };

[System.Serializable]
public class BordersMap
{
    [Tooltip("offset from viewport borders for player's movement")]
    public float minXOffset = 1.5f, maxXOffset = 1.5f, minYOffset = 1.5f, maxYOffset = 1.5f;
    [HideInInspector] public float minX, maxX, minY, maxY;
}

public class Spaceship : NetworkBehaviour {
    public bool localPlayer;

    public BordersMap borders;
    public float speed;
    public float torque;

   //public GameObject player;
    public string horizontalAxis = "Horizontal";
    public string verticalAxis = "Vertical";
    private Rigidbody2D rb;
    //Camera mainCamera;

    public Canvas canvas;
    public FixedJoystick joystick;


    public Dictionary<string, GameObject> shotsDico = new Dictionary<string, GameObject>();
    public GameObject[] shots;
    public GameObject shot;
    public Dictionary<string, Transform> shotSpawnPointsDico = new Dictionary<string, Transform>();
    public Transform[] shotSpawnPoints;
    public float fireRate;
    private float nextFire;
    public FireMode firemode;

    public bool hasShotBonus = false;

    public float fuel = 100;

    //Allow the identification by the parent (localPlayer or not)
    public void setLocalPlayer(bool local)
    {
        this.localPlayer = local;
    }

    // Use this for initialization
    void Start () {
        //mainCamera = Camera.main;
        rb = GetComponent<Rigidbody2D>();
        borders.maxY = 100;
        borders.maxX = 100;
        borders.minY = -100;
        borders.minX = -100;
        //joystick = this.GetComponentInChildren(typeof(Canvas)).GetComponentInChildren(typeof(Joystick)) as Joystick;
        //shotSpawnPoint = this.GetComponentInChildren(typeof(GameObject)).transform;


        shotsDico.Add("Default", shots[0]);
        shotsDico.Add("Fast", shots[1]);
        shotsDico.Add("Triple", shots[2]);
        shotsDico.Add("Through", shots[3]);

        shotSpawnPointsDico.Add("Default", shotSpawnPoints[0]);
        shotSpawnPointsDico.Add("Center", shotSpawnPoints[0]);
        shotSpawnPointsDico.Add("TripleLeft", shotSpawnPoints[1]);
        shotSpawnPointsDico.Add("TripleRight", shotSpawnPoints[2]);

    }
       
	
	// Update is called once per frame
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

    public void move()
    {
        Vector3 moveVector = (Vector3.right * joystick.Horizontal + Vector3.up * joystick.Vertical);

        if (moveVector != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(Vector3.forward, moveVector);
            transform.Translate(moveVector * speed * Time.deltaTime, Space.World);
            //fuel -= 0.04f;
        }

        transform.position = new Vector2    //if 'Player' crossed the movement borders, returning him back 
               (
               Mathf.Clamp(transform.position.x, borders.minX, borders.maxX),
               Mathf.Clamp(transform.position.y, borders.minY, borders.maxY)
               );
    }



    public void shoot()
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

    private void shootDefault()
    {
        GameObject o = Instantiate(shot, shotSpawnPointsDico["Default"].position, shotSpawnPointsDico["Default"].rotation);
        o.GetComponent<DestroyByContact>().shooter = this;
    }

    private void shootThrough()
    {
        GameObject o = Instantiate(shot, shotSpawnPointsDico["Default"].position, shotSpawnPointsDico["Default"].rotation);
        o.GetComponent<DestroyByContactThrough>().shooter = this;
    }

    private void shootTriple()
    {
        GameObject o;

        o = Instantiate(shot, shotSpawnPointsDico["Center"].position, shotSpawnPointsDico["Center"].rotation);
        o.GetComponent<DestroyByContact>().shooter = this;

        o = Instantiate(shot, shotSpawnPointsDico["TripleLeft"].position, shotSpawnPointsDico["TripleLeft"].rotation);
        o.GetComponent<DestroyByContact>().shooter = this;

        o = Instantiate(shot, shotSpawnPointsDico["TripleRight"].position, shotSpawnPointsDico["TripleRight"].rotation);
        o.GetComponent<DestroyByContact>().shooter = this;
    }

}
