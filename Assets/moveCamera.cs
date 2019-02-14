using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCamera : MonoBehaviour
{
    public float m_speed = 125f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            gameObject.transform.Translate(new Vector3(0, m_speed * Time.deltaTime, 0));
        }

                if (Input.GetKey(KeyCode.DownArrow))
                {
                    gameObject.transform.Translate(new Vector3(0, -m_speed * Time.deltaTime, 0));
                }

                if (Input.GetKey(KeyCode.RightArrow))
                {
                    gameObject.transform.Translate(new Vector3(m_speed * Time.deltaTime, 0, 0));

               }

    if (Input.GetKey(KeyCode.LeftArrow))
               {
                    gameObject.transform.Translate(new Vector3(-m_speed * Time.deltaTime, 0, 0));

                }
    }
}
