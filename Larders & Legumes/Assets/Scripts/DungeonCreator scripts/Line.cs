﻿using System;
using System.Collections.Generic;
using UnityEngine;
public class Line : MonoBehaviour
{
    Orientation orientation;
    Vector2Int coordinates;

    public Line(Orientation orientation, Vector2Int coordinates)
    {
        this.Orientation = orientation;
        this.coordinates = coordinates;
    }

    public Orientation Orientation { get => orientation; set => orientation = value; }
    public Vector2Int Coordinates { get => coordinates; set => coordinates = value; }
}

public enum Orientation
{
    Horizontal = 0,
    Vertical = 1,
}