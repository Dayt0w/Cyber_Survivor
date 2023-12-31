using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] enemyObjects;
    public GameObject swarmEnemy;
    private float time;
     private float time2;
    public float spawnRate;
    private GameObject player;
    public bool swarm;
    public float swarmDurration;
    private bool positionSet;
    private Vector2 randCircularSpawn;
    void Start()
    {
        positionSet = false;
        player = GameObject.Find("Player");
        GetCurrentTime();
        swarm = false;
    }

    // Update is called once per frame
    void Update()
    {
        if((Time.realtimeSinceStartup - time) > spawnRate ){
            Vector2 playerPositio = player.transform.position;
            float angle = Random.Range(0,2 * Mathf.PI);
             Vector2 randPosition = playerPositio + (new Vector2( Mathf.Cos(angle), Mathf.Sin(angle)) * 12);
             GameObject enemyObject = enemyObjects[Random.Range(0,enemyObjects.Length)];
            Instantiate(enemyObject, randPosition, transform.rotation);
            GetCurrentTime();
            //Debug.Log("Spawned");
        }
        if(swarm){
            SwarmUpdate();
        }
    }
    void GetCurrentTime(){
        time = Time.realtimeSinceStartup;
    }
    void GetSwarmTime(){
        time2 = Time.realtimeSinceStartup;
    }
    void SwarmUpdate(){
        if(Time.realtimeSinceStartup - time2 < swarmDurration && positionSet){
            
            Instantiate(swarmEnemy, randCircularSpawn, transform.rotation);
        }
        else if(!positionSet){
            SwarmPosition();
        }
        else{
            swarm = false;
            positionSet = false;
        }

    }
    void SwarmPosition(){
            GetSwarmTime();
            Vector2 playerPositio = player.transform.position;
            float angle = Random.Range(0,2 * Mathf.PI);
            Vector2 randPosition = playerPositio + (new Vector2( Mathf.Cos(angle), Mathf.Sin(angle)) * 12);
           randCircularSpawn = randPosition + Random.insideUnitCircle * 1;
           positionSet = true;
            
    }
}
