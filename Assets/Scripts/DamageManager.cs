using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageManager : MonoBehaviour
{

    [SerializeField]
    DmgReceiver disc;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        disc = GetComponentInChildren<DmgReceiver>();
    }

    // Update is called once per frame
    void Update()
    {
        if(disc.isTouching == true)
        {
            rb.AddForce(new Vector3(disc.enemyPos.x * (-1), 0,disc.enemyPos.z * (-1)).normalized * 100 + new Vector3(0,50,0));
        }
    }
}
