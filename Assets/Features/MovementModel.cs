using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementModel
{
    public int speed;
    public Transform transform;

    public MovementModel(int speed, Transform transform)
    {
        this.speed = speed;
        this.transform = transform;
    }

    public void Move(Vector2 direction)
    {
        transform.position += (Vector3)direction * speed * Time.deltaTime;
    }
}
