using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnCrab : SMAAgent
{
    public GameObject crab;
    public Transform self;// Use this for initialization
    public float timer = 0f;
    public Vector3 vector;

    void Start()
    {
        vector = new Vector3(0, 20.0f, 0);
        GameObject newObject = Instantiate(crab, self.position - vector, Quaternion.identity);
        
        SMAManager.instance.Add(newObject.gameObject.GetComponent<SMAAgent>());
    }
    public override void SMAUpdate(float dt)
    {
        timer += dt;
        if (timer >= 1f)
        {
            timer = 0f;
            GameObject newObject = Instantiate(crab, self.position - vector, Quaternion.identity);

            SMAManager.instance.Add(newObject.gameObject.GetComponent<SMAAgent>());
        }
    }

    public override void SMAFixedUpdate(float dt)
    {
        
    }
}