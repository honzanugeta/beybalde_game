using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    BeyBlade beyBlade = new BeyBlade();
    float speed = 0;
    // Start is called before the first frame update
    void Start()
    {
        setupBeyBlade();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(beyBlade.parts[0].ability.key)) {
            beyBlade.parts[0].ability.runAbility();
        }

        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        Debug.Log(speed);
    }


    void setupBeyBlade()
    {
        beyBlade.parts[0] = new DefaultPart();
        beyBlade.setUp();
        speed = beyBlade.speed + 20;
    }
}
