using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcdiseaseProgression : SMAAgent
{
    public int m_state;
    public SpriteRenderer m_renderer;
    public float timer = 0f;
    //public MoveRand movementscript;
    //public bool dead;


    // Use this for initialization
    void Start()
    {
        //dead = false;
        m_state = 0;
        m_renderer.color = Color.white;
    }

    public override void SMAUpdate(float dt)
    {


    }

    public override void SMAFixedUpdate(float dt)
    {
        timer += dt;
        if (timer >= 1f)
        {
            timer = 0f;
            if (m_state == 1)
            {
                int fortitudeSave = Random.Range(1, 20);
                if (fortitudeSave >= 19)
                {
                    m_state = 2;
                    m_renderer.color = Color.red;
                }
                if (fortitudeSave >= 1 && fortitudeSave <= 2)
                {
                    die();
                   
                }
            }

        }

    }


    public void die()
    {
        Destroy(m_renderer.gameObject);

    }

    public void activate()
    {
        m_state = 1;
        m_renderer.color = Color.green;

    }
}
