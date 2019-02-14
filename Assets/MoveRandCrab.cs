using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveRandCrab : SMAAgent
{
    public float m_speed = 75.0f;
    public Rigidbody2D m_rigidbody;
    public Vector2 velocity;
    public diseaseProgression selfdisease;
    // Use this for initialization
    void Start()
    {
        selfdisease = GetComponent<diseaseProgression>();
        velocity = new Vector2(0, 0);
    }

    // Update is called once per frame
    public override void SMAUpdate(float dt)
    {


    }

    public override void SMAFixedUpdate(float dt)
    {
        
            int changedirectionchances = Random.Range(1, 100);
            if (changedirectionchances > 95)
            {
                int directionid = Random.Range(0, 4);

                if (directionid == 0)
                {
                    Vector2 newvelocity = new Vector2(0, m_speed);

                    velocity = newvelocity;
                }

                if (directionid == 1)
                {
                    Vector2 newvelocity = new Vector2(0, -m_speed);

                    velocity = newvelocity;

                }

                if (directionid == 2)
                {
                    Vector2 newvelocity = new Vector2(m_speed, 0);


                    velocity = newvelocity;

                }

                if (directionid == 3)
                {
                    Vector2 newvelocity = new Vector2(-m_speed, 0);
                    velocity = newvelocity;

                }
            }
            m_rigidbody.MovePosition(m_rigidbody.position + velocity * dt);

    }
      

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "movingsand")
        {
            m_speed = m_speed / 2;

        }

        if (other.gameObject.tag == "Crab")
        {
            if (selfdisease.m_state == 1)
            {
                diseaseProgression otherdisease = other.GetComponent<diseaseProgression>();
                if (otherdisease.m_state == 0)
                {
                    int roll = Random.Range(1, 20);
                    if (roll == 1)
                    {
                        otherdisease.m_state = 1; //Transmits the disease.
                    }
                }
            }

        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "movingsand")
        {
            m_speed = m_speed * 2;

        }
    }

    //void Oldmove()
    //{
    //    if (Input.GetKey(KeyCode.UpArrow))
    //    {
    //        gameObject.transform.Translate(new Vector3(0, m_speed * Time.deltaTime, 0));
    //        m_renderer.sprite = m_backSprite;
    //    }

    //    if (Input.GetKey(KeyCode.DownArrow))
    //    {
    //        gameObject.transform.Translate(new Vector3(0, -m_speed * Time.deltaTime, 0));
    //        m_renderer.sprite = m_frontSprite;
    //    }

    //    if (Input.GetKey(KeyCode.RightArrow))
    //    {
    //        gameObject.transform.Translate(new Vector3(m_speed * Time.deltaTime, 0, 0));
    //        m_renderer.sprite = m_sideSprite;
    //        m_renderer.flipX = false;
    //    }

    //    if (Input.GetKey(KeyCode.LeftArrow))
    //    {
    //        gameObject.transform.Translate(new Vector3(-m_speed * Time.deltaTime, 0, 0));
    //        m_renderer.sprite = m_sideSprite;
    //        m_renderer.flipX = true;
    //    }

}

