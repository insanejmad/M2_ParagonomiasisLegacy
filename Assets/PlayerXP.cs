using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerXP : MonoBehaviour {
    public int m_score;
    public AudioClip crab_crunch;
    public npcdiseaseProgression m_disease;

    // Use this for initialization
    void Start () {
        m_disease = GetComponent<npcdiseaseProgression>();


    }

    // Update is called once per frame
    void Update () {
       
    }

    private void scoreUp(Collision2D other)
    {
        if (other.gameObject.tag == "Crab")
        {
            m_score += 1;
            AudioManager.instance.PlaySound(crab_crunch);
        }
        
    }


}
