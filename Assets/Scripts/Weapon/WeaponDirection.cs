using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    Up, Down, Side
}

[Serializable]
public class WeaponDirection
{
    public Direction direction;
    public Sprite gunSprite;
    public Vector2 gunLocalPosition;
    public Vector2 muzzleLocalPosition;
    public Quaternion muzzleLocalRotation;
}
