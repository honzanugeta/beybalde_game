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
    PlayerMovement player;
    [SerializeField]
    float attackDistance = 5;
    


    public enum BotState
    {
        Idle,
        Attack,
        Cooldown
    }

    public BotState currentState = BotState.Idle;
    [SerializeField]
    public float idleMoveCoolddown;

    public Transform target;
    public float moveSpeed = 5f;
    public float attackRange = 3f;
    public float cooldownTime = 2f;

    private float cooldownTimer = 0f;



    void Start()
    {
        setupBeyBlade();
    }

    // Update is called once per frame
    void Update()
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

    private void HandleCooldownState()
    {
        throw new NotImplementedException();
    }

    private void HandleAttackState()
    {
        throw new NotImplementedException();
    }

    private void HandleIdleState()
    {
        

        if (Vector3.Distance(player.transform.position, transform.position) <= attackDistance)
        {
            currentState = BotState.Attack;
            return;
        }

       // if()
        //Play idle anim




    }

    void MoveEnemy()
    {
        





    }




    void setupBeyBlade()
    {
        beyBlade.parts[0] = new DefaultPart();
        beyBlade.setUp();
        maxSpeed = beyBlade.speed + 20;
    }
}
