using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMAManager : MonoBehaviour {

    // Use this for initialization
    public static SMAManager instance = null;
    public List<SMAAgent> m_agents;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            m_agents = new List<SMAAgent>();

            SMAAgent[] agents = FindObjectsOfType<SMAAgent>();

            foreach (SMAAgent currentAgent in agents)
            {
                m_agents.Add(currentAgent);
            }
        }
        else
        {
            Destroy(gameObject);
        }

      
    }

    // Update is called once per frame
    void Update()
    {
        m_agents = new List<SMAAgent>();
        SMAAgent[] agents = FindObjectsOfType<SMAAgent>();

        foreach (SMAAgent currentAgent in agents)
        {
            m_agents.Add(currentAgent);
        }

        foreach (SMAAgent currentAgent in m_agents)
        {
            currentAgent.SMAUpdate(Time.deltaTime);
        }
    }
    void FixedUpdate(){
        m_agents = new List<SMAAgent>();
        SMAAgent[] agents = FindObjectsOfType<SMAAgent>();

        foreach (SMAAgent currentAgent in agents)
        {
            m_agents.Add(currentAgent);
        }

        foreach (SMAAgent currentAgent in m_agents)
        {
            currentAgent.SMAFixedUpdate(Time.fixedDeltaTime);
        }
    }

    public void Add(SMAAgent agentToAdd)
    {
        if (agentToAdd == null)
        {
            return;
        }

        m_agents.Add(agentToAdd);
    }
}
