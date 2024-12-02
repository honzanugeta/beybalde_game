using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    private BeyBlade beyBlade = new BeyBlade();
    private float speed = 0;
    private float maxSpeed;

    private Coroutine speedBoostCoroutine;
    private bool speedBoostActive = false;


    private void Start()
    {
        setupBeyBlade();
    }

    // Update is called once per frame
    private void Update()
    {
        MovePlayer();

        if (Input.GetKeyDown(beyBlade.parts[0].ability.key))
        {
            beyBlade.parts[0].ability.runAbility();
        }

        Debug.Log(maxSpeed);
    }

    private void MovePlayer()
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

    private void setupBeyBlade()
    {
        beyBlade.parts[0] = new DefaultPart();
        beyBlade.setUp();
        //maxSpeed = beyBlade.speed;
        maxSpeed = 30;
    }

    public void ActivateSpeedBoost(float speed, float duration)
    {
        if (!speedBoostActive)
        {
            maxSpeed += speed; 
            speedBoostActive = true; 
        }

        if (speedBoostCoroutine != null)
        {
            StopCoroutine(speedBoostCoroutine); 
        }
        speedBoostCoroutine = StartCoroutine(SpeedBoostCoroutine(duration));
    }

    private IEnumerator SpeedBoostCoroutine(float duration)
    {
        yield return new WaitForSeconds(duration);
        maxSpeed = 30;
        speedBoostActive = false; 
    }
}

