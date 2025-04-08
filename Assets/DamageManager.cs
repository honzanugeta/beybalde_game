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
    }

    // Update is called once per frame
    void Update()
    {
        if(disc.isTouching == true)
        {
            rb.AddForce(new Vector3(disc.enemyPos.x * (-1), disc.enemyPos.y).normalized * 50);
        }
    }
}
