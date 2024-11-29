using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField]
    float maxSpeed;
    [SerializeField]
    GameObject player;

    float speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    void MovePlayer() 
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);
        if (Physics.Raycast(ray, out hit, 100))
        {
            Debug.Log(hit.transform.name);
            float distance = (hit.transform.position - player.transform.position).magnitude;
            speed = Mathf.Round(distance * 10000) * 0.01f;
            Debug.Log(distance);
            if (speed >= maxSpeed)
            {
                speed = maxSpeed;
            }

        }

    }
}
