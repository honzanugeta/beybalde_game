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
    [SerializeField]
    Ability[] abilitky = new Ability[3];
    float speed = 0;
    float rotationTime = 0;
    float maxRotationTime = 0;
    float rotationSpeed = 0;
    Animator childAnimator;
    [SerializeField]
    GameObject failPanel;
    [SerializeField]
    PartSO part;
    [SerializeField]
    Transform emptyBit;
    [SerializeField]
    Transform emptyRatchet;
    [SerializeField]
    Transform emptyDisc;


    void Start()
    {
        setupBeyBlade();
        childAnimator = GetComponentInChildren<Animator>();
    }
    float MapZeroToXToZeroToOne(float value, float maxRange)
    {
        return value / maxRange; // Maps 0 to X -> 0 to 1
    }

    // Update is called once per frame
    void Update()
    {
        if (rotationTime > 0) {
            rotationSpeed = MapZeroToXToZeroToOne(rotationTime, maxRotationTime);
            

            rotationTime -= Time.deltaTime;
            if (childAnimator.GetCurrentAnimatorStateInfo(0).IsName("RotateAnim"))
            {
                childAnimator.speed = rotationSpeed;
            }

        }
        else
        {
            failPanel.SetActive(true);
        }


        Debug.Log(rotationSpeed);

        MovePlayer();

        if (Input.GetKeyDown(beyBlade.parts[0].Ability.key))
        {
            beyBlade.parts[0].Ability.runAbility();
        }
    }

    void dealDamage(float dmg)
    {

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
            Vector3 direction = (hit.point - transform.position).normalized;

            // Calculate tilt based on speed
            float tiltFactor = speed / maxSpeed; // Normalize speed (0 to 1)

            // Create a target rotation with amplified tilt
            float tiltX = Mathf.Lerp(27 * direction.x, -27f * direction.x, 1/ (tiltFactor * 2)); 
            float tiltZ = Mathf.Lerp(-27 * direction.z, 27f * direction.z, 1/(tiltFactor * 2)); 

            // Smoothly interpolate the current rotation to the target tilt
            this.GetComponentInParent<Transform>().rotation = Quaternion.Euler(tiltZ,0,tiltX);

            // Move towards the target point
            transform.position = Vector3.MoveTowards(transform.position, hit.point, speed * Time.deltaTime);

        }      
    }
    
    void setupBeyBlade()
    {
        Debug.Log("setting parts");
        beyBlade.parts[0] = new DefaultPart(GlobalVariables.SelectedCore);
        GameObject bit = beyBlade.parts[0].mesh;
        Instantiate(bit, emptyBit.transform.position, Quaternion.identity,emptyBit);
        beyBlade.parts[1] = new DefaultPart(GlobalVariables.SelectedRatchet);
        GameObject ratchet = beyBlade.parts[1].mesh;
        Instantiate(ratchet, emptyRatchet.transform.position, Quaternion.identity, emptyRatchet);
        beyBlade.parts[2] = new DefaultPart(GlobalVariables.SelectedBlade);
        GameObject disc = beyBlade.parts[2].mesh;
        Instantiate(disc, emptyDisc.transform.position, Quaternion.identity, emptyDisc);
        beyBlade.setUp();
        /* DO
        for(int i = 0; i < beyBlade.parts.Length; i++)
        {
            abilitky[i] = beyBlade.parts[i].ability;
        } */
        maxSpeed = beyBlade.speed + 20;
        for (int i = 0; i < beyBlade.parts.Length; i++)
        {
            maxRotationTime += beyBlade.parts[i].RotationTime;
            Debug.Log(beyBlade.parts[i].RotationTime);
        }
        rotationTime = maxRotationTime;
    }
}
