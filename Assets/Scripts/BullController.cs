using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BullController : MonoBehaviour
{
    [SerializeField]
    GameObject bull;
    [SerializeField]
    float speed = 100f;
    Rigidbody rigidbody;
    // Start is called before the first frame update
    void Awake() 
    {
        rigidbody = bull.GetComponent<Rigidbody>();
    }
    void Start()
    {
        
        Destroy(this.gameObject,10);
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody.AddRelativeForce(0,0,speed);
        speed = speed/2;
    }
    private void OnCollisionEnter(Collision other)
    {
        other.body.BroadcastMessage("OnBulletCollide");
        Destroy(this.gameObject);
        
    }
}
