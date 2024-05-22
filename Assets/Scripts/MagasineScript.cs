using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

public class MagasineScript : MonoBehaviour
{
    [SerializeField]
    GameObject thisGameObject;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnCollisionEnter(Collision other) 
    {
        if (other.body.GetComponent<PlayerScript>())
        {
            Vector3 vector3 = new();
            vector3.x = Random.Range(-100,100);
            vector3.z = Random.Range(-100,100);
            vector3.y = 20;
            other.body.BroadcastMessage("OnMagazinecollide");
            Instantiate(thisGameObject,vector3,Quaternion.identity);
            Destroy(gameObject);
        }

    }
}
