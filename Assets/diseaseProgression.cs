using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class diseaseProgression : SMAAgent
{
    public int m_state;
    public SpriteRenderer m_renderer;
    public float timer = 0f;
    public MoveRandCrab movementscript;
    public bool dead;


    // Use this for initialization
    void Start()
    {
        dead = false;
        m_state = 0;
        m_renderer.color = Color.white;
    }

    public override void SMAUpdate(float dt)
    {
        if (dead == false)
        {
            timer += dt;
            if (timer >= 1f)
            {
                timer = 0f;

                if (m_state == 1)
                {
                    m_renderer.color = Color.green;

                    int fortitudeSave = Random.Range(1, 20);
                    if (fortitudeSave >= 15)
                    {
                        m_state = 2;
                        m_renderer.color = Color.red;
                    }
                    if (fortitudeSave >= 1 && fortitudeSave <= 5)
                    {
                        die();
                        //isDead = true;
                        //gameObject.SetActive(false);
                        //Destroy(m_renderer.gameObject);
                    }
                }

                

                if (m_state == 0)
                {
                    int roll = Random.Range(1, 100);
                    if (roll >= 90)
                    { 
                        m_state = 1;
                        m_renderer.color = Color.green;
                    }
                }
            }
        }


    }

    public override void SMAFixedUpdate(float dt)
    {   
    
    }
    public void die()
    {
        Destroy(m_renderer.gameObject);
        //if (gameObject.tag == "female" or gameObject.tag == "male")
        //instantiate sprite skel

    }
}
