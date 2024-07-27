using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebrisSpawner : MonoBehaviour
{
    public LogicScript logic;
    public ShipScript ship;

    public float HorizontalOffset = 20;
    private float MeteorTimer = 0;
    private float ItemTimer = 0;

    public GameObject Meteor;
    public GameObject Meteor01;
    public GameObject Meteor02;
    public GameObject Meteor03;
    public float MeteorSpawnRate;
    
    public GameObject Coin;
    public float CoinSpawnRate;

    public int degrees;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        ship = GameObject.FindGameObjectWithTag("Ship").GetComponent<ShipScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (logic.GameIsRunning && ship.ShipIsFlyable)
        {
            if (MeteorTimer < MeteorSpawnRate)
            {
                MeteorTimer = MeteorTimer + Time.deltaTime;
            }
            else
            {
                SpawnMeteor();
                MeteorTimer = 0;
                MeteorSpawnRate = 4 / Random.Range(2, 6);
            }

            if (ItemTimer < CoinSpawnRate)
            {
                ItemTimer = ItemTimer + Time.deltaTime;
            }
            else
            {
                SpawnCoin();
                ItemTimer = 0;
                CoinSpawnRate = 8 / Random.Range(2, 6);

            }
        }
    }

    void SpawnMeteor() 
    {
        float leftmostPoint = transform.position.x - HorizontalOffset;
        float rightmostPoint = transform.position.x + HorizontalOffset;

        int MeteorType = Random.Range(0,4);

        switch (MeteorType) {
            case 0: 
                Instantiate(Meteor, new Vector3(Random.Range(leftmostPoint, rightmostPoint), transform.position.y, 0), transform.rotation = Quaternion.Euler(Vector3.forward * degrees));
                break;

            case 1:
                Instantiate(Meteor01, new Vector3(Random.Range(leftmostPoint, rightmostPoint), transform.position.y, 0), transform.rotation = Quaternion.Euler(Vector3.forward * degrees));
                break;

            case 2:
                Instantiate(Meteor02, new Vector3(Random.Range(leftmostPoint, rightmostPoint), transform.position.y, 0), transform.rotation = Quaternion.Euler(Vector3.forward * degrees));
                break;

            case 3:
                Instantiate(Meteor03, new Vector3(Random.Range(leftmostPoint, rightmostPoint), transform.position.y, 0), transform.rotation = Quaternion.Euler(Vector3.forward * degrees));
                break;

            default:
                Debug.Log("Meteor failed to spawn.");
                break;
        }
        degrees = Random.Range(0, 360);
    }

    void SpawnCoin()
    {
        float leftmostPoint = transform.position.x - HorizontalOffset/2;
        float rightmostPoint = transform.position.x + HorizontalOffset/2;

        Instantiate(Coin, new Vector3(Random.Range(leftmostPoint, rightmostPoint), transform.position.y, 0), transform.rotation = Quaternion.Euler(Vector3.forward * degrees));
        degrees = Random.Range(0,360);
    }

}
