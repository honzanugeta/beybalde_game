using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    [SerializeField] private float duration;
    public float Duration => duration;
    private void OnCollisionEnter(Collision collision)
    {
        HandleCollision(collision);
    }

    protected virtual void HandleCollision(Collision collision)
    {
        Destroy(gameObject);
        //Edit in specific PowerUp, like SpeedPowerUp
    }
}
