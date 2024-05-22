using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class RifleScript : MonoBehaviour
{
    System.Random magazineamount= new();
    [SerializeField]
    int magazines = 2;
    int ammo = 14;
    PlayerScript playerScript;
    private float _magTimer;
    [SerializeField]
    GameObject barrel;
    [SerializeField]
    GameObject bull;
    private bool _shoot;
    private bool _reload;
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
    private float _fireRateTimer = 0;
    private float _spreadTimer = 0;
    [SerializeField]
    float spread = 0.5f;
    private float _TD = 0;
    private bool limit =true;
    // Start is called before the first frame update
    void Start()
    {
        BroadcastMessage("OnAmmoCount",ammo);
        BroadcastMessage("OnMagazineCount",magazines);
    }

    // Update is called once per frame
    void Update()
    {
        _TD = Time.deltaTime;
        _spreadTimer += 1*spread*_TD;
        _fireRateTimer += 1 *fireRatePerSeconds *_TD;
        _magTimer += 1 * _TD;

        if (_shoot && _fireRateTimer > 1&& ammo>0)
        { 
            Instantiate(bull, barrel.transform.position, barrel.transform.rotation);
            _fireRateTimer = 0;
            _spreadTimer = 0;
            ammo --;
            BroadcastMessage("GunFire");
            BroadcastMessage("OnAmmoCount",ammo);
        }
        if (_spreadTimer < 1&& limit)
        {
            BroadcastMessage("CursorSpreadAdd");
            limit = false;
            BroadcastMessage("UptdateSlider");
        }
        else if (_spreadTimer> 1 && !limit)
        {
            BroadcastMessage("CursorSpreadRemove");
            limit = true;
            BroadcastMessage("UptdateSlider");
        }
        if (_reload&& magazines>0&&_magTimer>1)
        {
            magazines --;
            ammo= 0;
            ammo = magazineamount.Next(1,15);
            BroadcastMessage("OnAmmoCount",ammo);
            BroadcastMessage("OnMagazineCount",magazines);
            _magTimer =0; 
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
    void OnReload(InputValue btrue)
    {
        if (btrue.Get<float>()>0)
        {
            _reload = true;
        }
        else 
        {
            _reload = false;
        }
    }
    void OnMagazinecollide()
    {
        magazines ++;
        BroadcastMessage("OnMagazineCount",magazines);
    }

}