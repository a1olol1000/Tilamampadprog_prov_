using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyCTRL : MonoBehaviour
{
    [SerializeField]
    GameObject worldVariableKeeper;
    [SerializeField]
    GameObject thisGameObject;
    [SerializeField]
    GameObject magazines;
    [SerializeField]
    int enemyHealth = 3;
    int spawncance = 0;
    public bool enemy = true;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -200)
        {
        Vector3 vector3 = new();
        vector3.x = Random.Range(-50,50);
        vector3.z = Random.Range(-50,50);
        vector3.y = 20;
        Instantiate(thisGameObject,vector3,Quaternion.identity);
        Destroy(this.gameObject);
        }
    }
    void OnBulletCollide()
    {
        enemyHealth --;
        if (enemyHealth <0)
        {
            Destroy(thisGameObject,0.5f);
            Vector3 vector3 = new();
            vector3.x = Random.Range(-50,50);
            vector3.z = Random.Range(-50,50);
            vector3.y = 20;
            Instantiate(thisGameObject,vector3,Quaternion.identity);
            spawncance = worldVariableKeeper.GetComponent<CheckInts>().spawnChance;
            if (Random.Range(0, 100) < spawncance)
            {
                vector3.x = Random.Range(-50,50);
                vector3.z = Random.Range(-50,50);
                vector3.y = 20;
                Instantiate(thisGameObject,vector3,Quaternion.identity);
                
                worldVariableKeeper.BroadcastMessage("OnSpawnChansReset");
            }
            else 
            {
                worldVariableKeeper.BroadcastMessage("OnSpawnChansAdd");
            }
            vector3 = new(thisGameObject.transform.position.x,20,thisGameObject.transform.position.z);
            Instantiate(magazines,vector3,Quaternion.identity);
        }
       
    }
    
    public void OnPlayerEnter()
    {
        
        print("died");
        Vector3 vector3 = new();
        vector3.x = Random.Range(-50,50);
        vector3.z = Random.Range(-50,50);
        vector3.y = 20;
        Instantiate(thisGameObject,vector3,Quaternion.identity);
        Destroy(this.gameObject);
        
        
    }
    
}
