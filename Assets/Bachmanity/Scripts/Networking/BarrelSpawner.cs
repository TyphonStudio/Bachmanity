﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelSpawner : NetworkSpawner {

    public static BarrelSpawner Instance { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        Instance = this;
    }
}
