using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerUp : PowerUps
{
    [SerializeField] private float speedBoost = 10f;
    protected override void HandleCollision(Collision collision)
    {
        base.HandleCollision(collision);
        Debug.Log("Speed boost activated!");

        if (collision != null)
        {

            PlayerMovement playerMovement = collision.gameObject.GetComponentInParent<PlayerMovement>();
            if (playerMovement != null)
            {
                playerMovement.ActivateSpeedBoost(speedBoost, Duration);
            }
        }
    }
}
