using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BordersMap
{
    [Tooltip("offset from viewport borders for player's movement")]
    public float minXOffset = 1.5f, maxXOffset = 1.5f, minYOffset = 1.5f, maxYOffset = 1.5f;
    [HideInInspector] public float minX, maxX, minY, maxY;
}

public class Spaceship : MonoBehaviour {
    public BordersMap borders;
    public float speed;
    public float torque;
    public GameObject player;
    private Rigidbody2D rb;
    Camera mainCamera;
    // Use this for initialization
    void Start () {
        mainCamera = Camera.main;
        rb = GetComponent<Rigidbody2D>();
        borders.maxY = 100;
        borders.maxX = 100;
        borders.minY = -100;
        borders.minX = -100;
    }
       
	
	// Update is called once per frame
	void Update () {
#if UNITY_STANDALONE || UNITY_EDITOR
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        float angle = 60.0f;
        
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);


        rb.AddForce(transform.up * speed * moveVertical);

        //rb.AddForce(movement * speed);
        //rb.MoveRotation(angle * speed);
        //rb.MoveRotation(Mathf.LerpAngle(rb.rotation, 180.0f, 1.0f* Time.deltaTime));
        rb.AddTorque(transform.position.y * torque * moveHorizontal);
        transform.position = new Vector2    //if 'Player' crossed the movement borders, returning him back 
                (
                Mathf.Clamp(transform.position.x, borders.minX, borders.maxX),
                Mathf.Clamp(transform.position.y, borders.minY, borders.maxY)
                );
#endif
#if UNITY_IOS || UNITY_ANDROID //if current platform is mobile, 

        if (Input.touchCount == 1) // if there is a touch
        {
            Touch touch = Input.touches[0];
            Vector3 touchPosition = mainCamera.ScreenToWorldPoint(touch.position);  //calculating touch position in the world space
            touchPosition.z = transform.position.z;
            transform.position = Vector3.MoveTowards(transform.position, touchPosition, 30 * Time.deltaTime);
        }
#endif
    }
}
