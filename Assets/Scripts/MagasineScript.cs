using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagasineScript : MonoBehaviour
{
    protected int _maxAmmo = 14;
    private int _ammoAmount;
    
    // Start is called before the first frame update
    void Start()
    {
        _ammoAmount = Random.Range(0,_maxAmmo);
    }

    // Update is called once per frame
    void Update()
    {
     if (_ammoAmount > _maxAmmo)
     {
        _ammoAmount = _maxAmmo;
     }   
     if (_ammoAmount < 0)
     {
        _ammoAmount = 0;
     }
    }
}
