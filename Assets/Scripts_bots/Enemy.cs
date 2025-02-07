using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;


public class Enemy : MonoBehaviour
{


    float maxSpeed;
    [SerializeField]
    LayerMask playerLayer;
    float speed = 0;
    [SerializeField]
    PlayerMovement player;

    float attackDistance = 5;

    float idleDistance = 15;

    float followDistance = 20;
    bool isAttacking = false;
    Vector3 randomOffset = Vector3.zero;

    public float range = 10f; // Maximum range for random points
    public float moveSpeed = 8f; // Movement speed
    public float stopDistance = 5f; // How close to get before choosing a new point

    private Vector3 targetPosition = Vector3.zero; // The current target position

    bool isWaiting = false;

    BeyBlade beyBlade = new BeyBlade();
    [SerializeField]
    Ability[] abilitky = new Ability[3];

    public enum BotState
    {
        Idle,
        Attack,
        Cooldown
    }

    public BotState currentState = BotState.Idle;
    [SerializeField]
    public float idleMoveCoolddown;


    public float cooldownTime = 5f;

    private float cooldownTimer = 3f;



    void Start()
    {
        setupBeyBlade();
        makeRandomOffset();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAttacking)
        {
            switch (currentState)
            {
                case BotState.Idle:
                    HandleIdleState();
                    break;

                case BotState.Attack:
                    HandleAttackState();
                    break;

                case BotState.Cooldown:
                    HandleCooldownState();
                    break;
            }
        }
        
    
    }

    private void HandleCooldownState()
    {
        cooldownTimer -= Time.deltaTime;

        if (cooldownTimer <= 0)
        {
            Debug.Log("Cooldown complete!");
            currentState = BotState.Idle;
        }
    }

    private void HandleAttackState()
    {
        Debug.Log("atttaaaackkk stateee");
        if (Vector3.Distance(player.transform.position, transform.position) > idleDistance)
            {
            Debug.Log("moc daleko");
                 currentState = BotState.Idle;
                return;
            }



        if(Vector3.Distance(player.transform.position, transform.position) < attackDistance)
        {
            isAttacking = true;
            Debug.Log("attack");
            //Play attack anim
            isAttacking = false; // az se animace dokonci dat na false
            beyBlade.parts[0].ability.runAbility();
            GetComponent<Rigidbody>().velocity = Vector3.zero;
           cooldownTimer = cooldownTime;
            currentState = BotState.Cooldown;
        }
        else
        {
            Debug.Log("following");
          //  Vector3.MoveTowards(transform.position, player.transform.position, 10000);
            Vector3 direction = (player.transform.position - transform.position).normalized;
           // print(direction);
            GetComponent<Rigidbody>().velocity = direction * moveSpeed * Time.deltaTime * 100;
        }

        


    }

    private void HandleIdleState()
    {
        

        if (Vector3.Distance(player.transform.position, transform.position) <= followDistance)
        {
           // Debug.Log(Vector3.Distance(player.transform.position, transform.position));
            Debug.Log("from idle to attack");
            currentState = BotState.Attack;
            return;
        }
        else
        {
            Debug.Log("not following");
            //Debug.Log(Vector3.Distance(player.transform.position, transform.position));
        }


        targetPosition = randomOffset;
        float distance = Vector3.Distance(transform.position, targetPosition);
        
        if (distance <= stopDistance)
        {
            makeRandomOffset();
            Debug.Log("new target");
            StartCoroutine(wait());
           
            
            
            
            return;
        }
        else
        {
            
            Vector3 direction = (targetPosition - transform.position).normalized;
            //print(direction);
            GetComponent<Rigidbody>().velocity = direction * moveSpeed * Time.deltaTime * 100;
            //GetComponent<Rigidbody>().MovePosition(direction * moveSpeed * Time.deltaTime * 100);
            //transform.position += direction 

        }


    }

    IEnumerator wait()
    {
        isWaiting = true;
        moveSpeed = 0;
        yield return new WaitForSeconds(1);
        moveSpeed = 8;
        isWaiting = false;

    }

    void makeRandomOffset()
    {
        randomOffset = new Vector3(
           UnityEngine.Random.Range(-range, range), 0, UnityEngine.Random.Range(-range, range)
       );
       // Debug.Log(randomOffset);
    }

    void setupBeyBlade()
    {
        beyBlade.parts[0] = new DefaultPart();
        beyBlade.setUp();
        maxSpeed = beyBlade.speed + 60;
    }
}
