using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckManager : MonoBehaviour
{
    public static DuckManager instance;
    Stack<DuckBehaviour> pool = new Stack<DuckBehaviour>();
    float secondsPerDuck = 0.5f;
    float secondsSinceLastDuck = 0f;
    int failedShotsInARow = 0;

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

    public int getFailedShots()
    {
        return failedShotsInARow;
    }

    public void setFailedShots(int i)
    {
        failedShotsInARow = i;
        //Debug.Log(failedShotsInARow);
        if(failedShotsInARow >= 2)
        {
            cursorMovement.instance.movementCommands[0] = new moveDownCommand();
            cursorMovement.instance.movementCommands[1] = new moveUpCommand();
        }
        else
        {
            cursorMovement.instance.movementCommands[1] = new moveDownCommand();
            cursorMovement.instance.movementCommands[0] = new moveUpCommand();
        }
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
            //Debug.Log("A");
            return;
        }
       // Debug.Log("B");
        DuckBehaviour d = pool.Pop();
        //Debug.Log(d);
        d.gameObject.SetActive(true);
        d.transform.position += new Vector3(Random.Range(-2f, 2f), 0, 0);
    }
}
