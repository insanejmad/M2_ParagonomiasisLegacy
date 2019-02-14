using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnHuman : SMAAgent
{
    public GameObject human_m;
    public GameObject human_f;
    public Transform self;// Use this for initialization
    public float timer = 0f;
    public Vector3 vector;
    public float fecundity_timer;

    void Start()
    {
        vector = new Vector3(0, 10.0f, 0);
        self = GetComponent<Transform>();
        fecundity_timer = 0;
    }
    public override void SMAUpdate(float dt)
    {
        fecundity_timer += dt;

    }

    public override void SMAFixedUpdate(float dt)
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "female" && self.gameObject.tag == "male" || other.gameObject.tag == "male" && self.gameObject.tag == "female")
        {
            if (fecundity_timer >= 10f)
            {
                fecundity_timer = 0f;
                int fecundity = Random.Range(0, 100);
                if (fecundity >= 50)
                {

               
                        int genetichazard = Random.Range(0, 2);
                        if (genetichazard == 0)
                        {
                            GameObject newObject = Instantiate(human_m, self.position - vector, Quaternion.identity);

                            SMAManager.instance.Add(newObject.gameObject.GetComponent<SMAAgent>());
                        }

                        if (genetichazard == 1)
                        {
                            GameObject newObject = Instantiate(human_f, self.position - vector, Quaternion.identity);

                            SMAManager.instance.Add(newObject.gameObject.GetComponent<SMAAgent>());
                        }
                    }

            }
        }
      
    }
}