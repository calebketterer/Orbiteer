using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebrisMovementScript : MonoBehaviour
{
    public float MovementSpeed = 5;
    public float DeadZone = -25;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.down * MovementSpeed) * Time.deltaTime;
        if (transform.position.y < DeadZone) {
            Destroy(gameObject);        
        }    
    
    }
}
