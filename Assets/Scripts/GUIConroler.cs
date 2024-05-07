using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GUIConroler : MonoBehaviour
{
    [SerializeField]
    int ammo;
    [SerializeField]
    Text skott;
    [SerializeField]
    int magazine;
    [SerializeField]
    Text magazines;
    [SerializeField]
    private int _hp= 6;
    float timer = 0;
    [SerializeField]
    GameObject heart1;
    [SerializeField]
    GameObject heart2;
    [SerializeField]
    GameObject heart3;
    [SerializeField]
    GameObject heart4;
    [SerializeField]
    GameObject heart5;
    [SerializeField]
    GameObject heart6;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        skott.text = ToString(ammo);
        magazines.text = ToString(magazine);
        
        
        
        OnTakeDamage(0);
        
    }

    private string ToString(int result)
    {
        return Convert.ToString(result);
    }
   public void OnAmmoCount(int ammog)
    {
        ammo = ammog;
        
    }
    public void OnMagazineCount(int magazinesg)
    {
        magazine = magazinesg;
        
    }

    public void OnTakeDamage(int takeDamage)
    {
        _hp = _hp - takeDamage;
        if (_hp<0)
        {
            heart1.SetActive(false);
        }
        else if (_hp<1)
        {
            heart2.SetActive(false);
            heart1.SetActive(true);
        }
        else if (_hp<2)
        {
            heart3.SetActive(false);
            heart1.SetActive(true);
            heart2.SetActive(true);
        }
        else if (_hp<3)
        {
            heart4.SetActive(false);
            heart1.SetActive(true);
            heart2.SetActive(true);
            heart3.SetActive(true);
        }
        else if (_hp<4)
        {
            heart5.SetActive(false);
            heart1.SetActive(true);
            heart2.SetActive(true);
            heart3.SetActive(true);
            heart4.SetActive(true);
        }
        else if (_hp<5)
        {
            heart6.SetActive(false);
            heart1.SetActive(true);
            heart2.SetActive(true);
            heart3.SetActive(true);
            heart4.SetActive(true);
            heart5.SetActive(true);
        }
        else if (_hp>6)
        {
            heart1.SetActive(true);
            heart2.SetActive(true);
            heart3.SetActive(true);
            heart4.SetActive(true);
            heart5.SetActive(true);
            heart6.SetActive(true);
        }
    }
}
