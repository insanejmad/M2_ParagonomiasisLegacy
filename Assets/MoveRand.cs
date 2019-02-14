using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveRand : SMAAgent {
    public float m_speed = 75.0f;
    private Animator anim;
    public Rigidbody2D m_rigidbody;
    public Vector2 velocity;
    public npcdiseaseProgression m_disease;
    public AudioClip eatcrab;

    // Use this for initialization
    void Start () {

        m_disease = GetComponent<npcdiseaseProgression>();
        velocity = new Vector2(0, 0);
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    public override void SMAUpdate(float dt) {
        

    }

    public override void SMAFixedUpdate(float dt) {
        
            int changedirectionchances = Random.Range(1, 100);
            if (changedirectionchances > 95)
            {
                int directionid = Random.Range(0, 4);

                if (directionid == 0)
                {
                    Vector2 newvelocity = new Vector2(0, m_speed);
                    if (anim.GetCurrentAnimatorStateInfo(0).IsName("eat_crab") || anim.GetCurrentAnimatorStateInfo(0).IsName("growing_up"))
                    {
                        return;
                    }
                    anim.Play("walking_up");
                    velocity = newvelocity;
                }

                if (directionid == 1)
                {
                    Vector2 newvelocity = new Vector2(0, -m_speed);
                    if (anim.GetCurrentAnimatorStateInfo(0).IsName("eat_crab") || anim.GetCurrentAnimatorStateInfo(0).IsName("growing_up"))
                    {
                        return;
                    }
                    anim.Play("walking_down");
                    velocity = newvelocity;

                }

                if (directionid == 2)
                {
                    Vector2 newvelocity = new Vector2(m_speed, 0);
                    if (anim.GetCurrentAnimatorStateInfo(0).IsName("eat_crab") || anim.GetCurrentAnimatorStateInfo(0).IsName("growing_up"))
                    {
                        return;
                    }
                    anim.Play("walking_right");
                    velocity = newvelocity;

                }

                if (directionid == 3)
                {
                    Vector2 newvelocity = new Vector2(-m_speed, 0);
                    if (anim.GetCurrentAnimatorStateInfo(0).IsName("eat_crab") || anim.GetCurrentAnimatorStateInfo(0).IsName("growing_up"))
                    {
                        return;
                    }
                    anim.Play("walking_left");
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
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("eat_crab") || anim.GetCurrentAnimatorStateInfo(0).IsName("growing_up"))
            {
                return;
            }
            anim.Play("eat_crab");
            AudioManager.instance.PlaySound(eatcrab);
            diseaseProgression crabstatus = other.gameObject.GetComponent<diseaseProgression>();
            if (crabstatus.m_state == 1)
            {
                int fortitudesave = Random.Range(1, 20);
                if (fortitudesave <= 5)
                {
                    m_disease.activate();
                }
            }
            Destroy(other.gameObject);

        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "movingsand")
        {
            m_speed = m_speed*2;

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

