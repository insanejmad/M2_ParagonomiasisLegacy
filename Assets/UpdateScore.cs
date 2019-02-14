using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UpdateScore : MonoBehaviour {
    public PlayerXP Score;
    public Text Info;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Info.text = "Score : " + Score.m_score;
    }
}
