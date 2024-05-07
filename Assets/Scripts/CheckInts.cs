using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckInts : MonoBehaviour
{
    [SerializeField]
    public int spawnChance = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnSpawnChansReset()
    {
        spawnChance = 0;
    }
    void OnSpawnChansAdd()
    {
        spawnChance ++;
    }
    int CheckSpawnChance()
    {
        return spawnChance;

    }

}
