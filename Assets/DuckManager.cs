using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckManager : MonoBehaviour
{
    public static DuckManager instance;
    Stack<DuckBehaviour> pool = new Stack<DuckBehaviour>();
    float secondsPerDuck = 0.5f;
    float secondsSinceLastDuck = 0f;


    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        secondsSinceLastDuck += Time.deltaTime;
        if (secondsSinceLastDuck >= secondsPerDuck)
        {
            releaseDuck();
            secondsSinceLastDuck = 0;
        }
    }

    public void addDuck(DuckBehaviour d)
    {
        if (pool.Contains(d))
        {
            return;
        }
        pool.Push(d);
        d.gameObject.SetActive(false);
        d.gameObject.transform.position = transform.position;
        d.gameObject.transform.SetParent(transform);
    }

    public void releaseDuck()
    {
        if(pool.Count == 0)
        {
            Debug.Log("A");
            return;
        }
        Debug.Log("B");
        DuckBehaviour d = pool.Pop();
        Debug.Log(d);
        d.gameObject.SetActive(true);
    }
}
