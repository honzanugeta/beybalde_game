using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DmgReceiver : MonoBehaviour
{
    public bool isTouching = false;
    public Vector3 enemyPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("touching");
       if(collision.gameObject.GetComponentInParent<Enemy>() != null)
        {
            isTouching = true;
            enemyPos = collision.transform.position;
        }   
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.GetComponentInParent<Enemy>() != null)
        {
            isTouching = false;
            enemyPos = Vector3.zero;
        }
    }
}
