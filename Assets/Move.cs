using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Move : MonoBehaviour
{
    public float m_speed = 100.0f;
    private Animator anim;
    public SpriteRenderer m_renderer;
    public Rigidbody2D m_rigidbody;
    public Vector2 velocity;
    public npcdiseaseProgression m_disease;
    public float xvalue;
    public float yvalue;
    public AudioClip eatcrab;

    // Use this for initialization
    void Start()
    {
        velocity = new Vector2(0, 0);
        m_disease = GetComponent<npcdiseaseProgression>();

        anim = GetComponent<Animator>();
        xvalue = 0f;
        yvalue = 0f;
        
    }

    // Update is called once per frame
    void Update()
    {


    }

    private void FixedUpdate()
    {
        xvalue = Input.GetAxis("Horizontal");
        yvalue = Input.GetAxis("Vertical");
        
        velocity = new Vector2(xvalue * m_speed, yvalue * m_speed);


        m_rigidbody.MovePosition(m_rigidbody.position + velocity * Time.fixedDeltaTime);

        if (Mathf.Abs(xvalue) > Mathf.Abs(yvalue))
        {
            if (xvalue > 0.001)
            {

                if (anim.GetCurrentAnimatorStateInfo(0).IsName("eat_crab") || anim.GetCurrentAnimatorStateInfo(0).IsName("growing_up"))
                {
                    return;
                }
                anim.Play("walking_right");


            }
            else
            {

                if (anim.GetCurrentAnimatorStateInfo(0).IsName("eat_crab") || anim.GetCurrentAnimatorStateInfo(0).IsName("growing_up"))
                {
                    return;
                }
                anim.Play("walking_left");

            }
        }
        else if (Mathf.Abs(xvalue) < Mathf.Abs(yvalue))
        {
            if (yvalue > 0.001)
            {

                if (anim.GetCurrentAnimatorStateInfo(0).IsName("eat_crab") || anim.GetCurrentAnimatorStateInfo(0).IsName("growing_up"))
                {
                    return;
                }

                anim.Play("walking_up");

            }
            else
            {

                if (anim.GetCurrentAnimatorStateInfo(0).IsName("eat_crab") || anim.GetCurrentAnimatorStateInfo(0).IsName("growing_up"))
                {
                    return;
                }
                anim.Play("walking_down");


            }
        }



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
            
            diseaseProgression crabstatus = other.gameObject.GetComponent<diseaseProgression>();
            if (crabstatus.m_state == 1)
            {
                int roll = Random.Range(1, 100);
                if (roll >= 85)
                {
                    m_disease.activate();
                }  
            }
            AudioManager.instance.PlaySound(eatcrab);

            Destroy(other.gameObject);

        }

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "movingsand")
        {
            m_speed = m_speed * 2;

        }
    }


}

