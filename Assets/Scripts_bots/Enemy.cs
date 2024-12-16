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
    BeyBlade beyBlade = new BeyBlade();
    float speed = 0;
    [SerializeField]
    PlayerMovement player;
    [SerializeField]
    float attackDistance = 2;
    [SerializeField]
    float idleDistance = 5;
    [SerializeField]
    float followDistance = 7;
    bool isAttacking = false;

    public float range = 10f; // Maximum range for random points
    public float moveSpeed = 8f; // Movement speed
    public float stopDistance = 0.5f; // How close to get before choosing a new point

    private Vector3 targetPosition; // The current target position



    public enum BotState
    {
        Idle,
        Attack,
        Cooldown
    }

    public BotState currentState = BotState.Idle;
    [SerializeField]
    public float idleMoveCoolddown;


    public float cooldownTime = 2f;

    private float cooldownTimer = 0f;



    void Start()
    {
        setupBeyBlade();
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

        if (cooldownTimer <= 0f)
        {
            Debug.Log("Cooldown complete!");
            currentState = BotState.Idle;
        }
    }

    private void HandleAttackState()
    {
        if (Vector3.Distance(player.transform.position, transform.position) < idleDistance)
            {
            print("moc daleko");
                 currentState = BotState.Idle;
                return;
            }



        if(Vector3.Distance(player.transform.position, transform.position) < attackDistance)
        {
            isAttacking = true;
            print("attack");
            //Play attack anim
            isAttacking = false; // az se animace dokonci dat na false
            cooldownTimer = cooldownTime;
            currentState = BotState.Cooldown;
        }

        Vector3.MoveTowards(transform.position, player.transform.position, 100);


    }

    private void HandleIdleState()
    {
        

        if (Vector3.Distance(player.transform.position, transform.position) <= followDistance)
        {
            currentState = BotState.Attack;
            return;
        }

        Vector3 randomOffset = new Vector3(
            UnityEngine.Random.Range(-range, range),
            0, // Keep it on the same Y level
            UnityEngine.Random.Range(-range, range)
        );
        print(randomOffset);
        targetPosition = transform.position + randomOffset;
        // Calculate the distance to the target
        float distance = Vector3.Distance(transform.position, targetPosition);

        // If close enough to the target, pick a new position
        if (distance <= stopDistance)
        {
            return;
        }
        else
        {
            // Move towards the target position
            Vector3 direction = (targetPosition - transform.position).normalized;
            transform.position += direction * moveSpeed * Time.deltaTime;
        }


    }

    void setupBeyBlade()
    {
        beyBlade.parts[0] = new DefaultPart();
        beyBlade.setUp();
        maxSpeed = beyBlade.speed + 20;
    }
}
