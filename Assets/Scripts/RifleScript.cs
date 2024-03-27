using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class RifleScript : MonoBehaviour
{
    private bool _shoot;
    [SerializeField]
    float attackDmg = 37;
    [SerializeField]
    float critDmg = 23;
    [SerializeField]
    int critChans = 30;
    [SerializeField]
    float reloadTimeSeconds = 3.5f;
    [SerializeField]
    float fireRatePerSeconds = 1f;
    private float _secondTimer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _secondTimer += 1 *fireRatePerSeconds *Time.deltaTime;
        if (_shoot && _secondTimer > 1)
        {
            print("baaam");
            _secondTimer = 0;
        }
    }
    void OnFire(InputValue bTrue)
    {
        if (bTrue.Get<float>()>0)
        {
            _shoot = true;
        }
        else
        {
            _shoot = false;
        }
    }


}