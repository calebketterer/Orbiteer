using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldScript : MonoBehaviour
{

    public GameObject Shield;

    // Start is called before the first frame update
    void Start()
    {
        SpawnShield();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnShield()
    {
        Instantiate(Shield, new Vector3(0, 0, 0), transform.rotation = Quaternion.identity); // Can remove rotation
    }
}
