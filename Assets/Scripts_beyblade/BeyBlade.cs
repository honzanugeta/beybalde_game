using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeyBlade {
    private int Hp;
    public int hp { get => Hp; }

    public float rotation_time;
    public float knockback_force;
    public float passive_dmg;
    public float speed;
    public Part[] parts = new Part[3];

    public void setUp()
    {
        setUpSpeed();
        setUpRotationTime();
        setUpKnockback();
        setUpDamage();
        setUpHp();
        
    }

    private void setUpHp()
    {
        throw new NotImplementedException();
    }

    private void setUpDamage()
    {
        throw new NotImplementedException();
    }

    private void setUpKnockback()
    {
        throw new NotImplementedException();
    }

    private void setUpRotationTime()
    {
        
    }

    private void setUpSpeed() {
     /*   foreach (var part in parts) {
            speed += part.Speed;
        }*/
     speed = parts[0].Speed;
    }
}

