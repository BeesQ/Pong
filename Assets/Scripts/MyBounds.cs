using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyBounds
{
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    public MyBounds(float minX, float maxX, float minY, float maxY)
    {
        this.minX = minX;
        this.maxX = maxX;
        this.minY = minY;
        this.maxY = maxY;
    }

    public override string ToString()
    {
        return "x.min: " + minX + ", x.max: " + maxX + ", y.min: " + minY + ", y.max: " + maxY;
    }
}