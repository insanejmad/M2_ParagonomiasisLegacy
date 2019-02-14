using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class humandiseaseProgression : SMAAgent
{
    public int m_state;
    public SpriteRenderer m_renderer;
    public float timer = 0f;
    public Move movementscript;
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


    }

    public override void SMAFixedUpdate(float dt)
    {
        if (dead == false)
        {
            timer += dt;
            if (timer >= 1f)
            {
                timer = 0f;

                if (m_state == 1)
                {
                    int fortitudeSave = Random.Range(0, 20);
                    if (fortitudeSave >= 19)
                    {
                        m_state = 2;
                        m_renderer.color = Color.red;
                    }
                    if (fortitudeSave >= 1 && fortitudeSave <= 3)
                    {
                        die();
                        //isDead = true;
                        //gameObject.SetActive(false);
                        
                    }
                }
                
            }
        }

    }

    
    public void die()
    {
        Destroy(m_renderer.gameObject);
        //m_renderer.color = Color.black;
        //dead = true;
        //movementscript.isdead = true;
    }

    public void activate()
    {
        m_state = 1;
        m_renderer.color = Color.green;

    }
}
