using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShipScript : MonoBehaviour
{
    public MenuScript menus;
    public LogicScript logic;
    //public ShieldScript shieldscript;
    //public DebrisMovementScript dms;

    public Rigidbody2D myRigidbody;
    public float UpSpeed = 10, DownSpeed = 10, HorizontalSpeed = 10;
    public float RotationSpeed = 1;
    public bool ShipIsFlyable = true;
    public bool FlightPersistance = false;
    public Vector2 MouseLocation;
    public Vector2 DirectionToMouse;

    public float PrimarySpeedOnClick = 10;
    public float SecondarySpeedOnClick = 10;

    public Vector2 TargetPosition;
    

    // Start is called before the first frame update
    void Start()
    {
        menus = GameObject.FindGameObjectWithTag("Menu").GetComponent<MenuScript>();
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        //shieldscript = GameObject.FindGameObjectWithTag("Shield").GetComponent<ShieldScript>();
        //dms = GameObject.FindGameObjectWithTag("DebrisMovement").GetComponent<DebrisMovementScript>().enabled = false;
    }

    // Update is called once per frame. Good for INPUTS.
    void Update()
    {

        if (ShipIsFlyable || FlightPersistance)
        {
            MouseLocation = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            DirectionToMouse = (MouseLocation - (Vector2)transform.position).normalized;
            myRigidbody.transform.up = DirectionToMouse;

            if (Input.GetMouseButton(0))
            {
                TargetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                transform.position = Vector2.MoveTowards(transform.position, TargetPosition, PrimarySpeedOnClick * Time.deltaTime); // This works for movement, but not physics
                //myRigidbody.velocity = Vector2.MoveTowards(myRigidbody.velocity, TargetPosition, SpeedOnClick * Time.deltaTime); // This works for a while, but I think the velocities added up
            }

            if (Input.GetMouseButton(1))
            {
                TargetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                transform.position = Vector2.MoveTowards(transform.position, TargetPosition, SecondarySpeedOnClick  * Time.deltaTime); // This works for movement, but not physics
                //myRigidbody.velocity = Vector2.MoveTowards(myRigidbody.velocity, TargetPosition, SpeedOnClick * Time.deltaTime); // This works for a while, but I think the velocities added up
            }



            if (Input.GetKey(KeyCode.W))
            {
                myRigidbody.velocity = Vector2.up * UpSpeed;
            }

            if (Input.GetKey(KeyCode.S))
            {
                myRigidbody.velocity = Vector2.down * DownSpeed;
            }

            if (Input.GetKey(KeyCode.A))
            {
                myRigidbody.velocity = Vector2.left * HorizontalSpeed;
            }

            if (Input.GetKey(KeyCode.D))
            {
                myRigidbody.velocity = Vector2.right * HorizontalSpeed;
            }

            if (Input.GetKey(KeyCode.Q))
            {
                myRigidbody.rotation += RotationSpeed;
            }

            if (Input.GetKey(KeyCode.E))
            {
                myRigidbody.rotation -= RotationSpeed;
            }

            if (Input.GetKeyDown(KeyCode.P))
            {
                FlightPersistance = !FlightPersistance;
                if (FlightPersistance) { 
                    Debug.Log("Flight Persistance Enabled.");
                    
                }
                else
                {
                    Debug.Log("Flight Persistance Disabled.");
                }
               
            }
        }
    }

    // Fixed Update is called to run once, zero, or several times per frame, depending on how many physics frames per second are set. Good for physics calculations.
    private void FixedUpdate()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag== "Meteor" && !FlightPersistance) {
            logic.GameOver();
            ShipIsFlyable = false;
            myRigidbody.gravityScale = 1;
        }
    }

}
