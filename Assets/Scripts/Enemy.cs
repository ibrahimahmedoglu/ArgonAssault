using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathVfx;
    [SerializeField] GameObject hitVfx;
    [SerializeField] int amountToincrease = 15;
    [SerializeField] int hitPoints = 4;

    ScoreBoard scoreBoard;
    GameObject parentGameObject;

    void Start() 
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
        parentGameObject = GameObject.FindWithTag("SpawnAtRuntime");
        AddRigidbody();
    }

    void AddRigidbody()
    {
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
    }
    // Start is called before the first frame update
    private void OnParticleCollision(GameObject other) 
    {
        ProcessHit();
        if(hitPoints < 1)
        {
        ProcessKill();
        }
    }

    void ProcessHit()
    {
        hitPoints--;
        GameObject vfx = Instantiate(hitVfx,transform.position,Quaternion.identity);
        vfx.transform.parent = parentGameObject.transform;
        scoreBoard.IncreaseScore(amountToincrease);
    }
    void ProcessKill()
    {
        GameObject vfx = Instantiate(deathVfx,transform.position,Quaternion.identity);
        vfx.transform.parent = parentGameObject.transform;
        Destroy(gameObject);
    }
    
}
