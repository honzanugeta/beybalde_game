using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class PlayerMovement : MonoBehaviour
{


    float maxSpeed;
    [SerializeField]
    LayerMask layerMask;
    BeyBlade beyBlade = new BeyBlade();
    float speed = 0;



    void Start()
    {
        setupBeyBlade();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();

        if (Input.GetKeyDown(beyBlade.parts[0].ability.key))
        {
            beyBlade.parts[0].ability.runAbility();
        }
    }

    void MovePlayer()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        //Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);
        if (Physics.Raycast(ray, out hit, 100, layerMask))
        {
            //Debug.Log(hit.transform.name);
            float distance = (transform.position - hit.point).magnitude;
            speed = Mathf.Round(distance * 100) * 0.01f;
            //Debug.Log(distance);
            if (speed >= maxSpeed)
            {
                speed = maxSpeed;
            }

            transform.position = Vector3.MoveTowards(transform.position, hit.point, speed * Time.deltaTime);

        }

      


       
    }
    



    void setupBeyBlade()
    {
        beyBlade.parts[0] = new DefaultPart();
        beyBlade.setUp();
        maxSpeed = beyBlade.speed;
    }
}
