using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinDetectorScript : MonoBehaviour
{
    public LogicScript logic;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Ship" || collision.gameObject.tag == "Shield")
        {
            logic.addScore();
            Destroy(gameObject);
        }
    }
}

