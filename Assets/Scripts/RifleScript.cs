using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class RifleScript : MonoBehaviour
{
    PlayerScript playerScript;
    [SerializeField]
    GameObject barrel;
    [SerializeField]
    GameObject bull;
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
    private float _secundSecondTimer = 0;
    [SerializeField]
    float spread = 0.5f;
    private float _TD = 0;
    private bool limit =true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _TD = Time.deltaTime;
        _secundSecondTimer += 1*spread*_TD;
        _secondTimer += 1 *fireRatePerSeconds *_TD;
        if (_shoot && _secondTimer > 1)
        { 
            Instantiate(bull, barrel.transform.position, barrel.transform.rotation);
            _secondTimer = 0;
            _secundSecondTimer = 0;
        }
        if (_secundSecondTimer < 1&& limit)
        {
            BroadcastMessage("CursorSpreadAdd");
            limit = false;
            BroadcastMessage("UptdateSlider");
        }
        else if (_secundSecondTimer> 1 && !limit)
        {
            BroadcastMessage("CursorSpreadRemove");
            limit = true;
            BroadcastMessage("UptdateSlider");
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