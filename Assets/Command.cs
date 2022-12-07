using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command
{
    protected int speed = 5;
    public abstract void doAction(GameObject g);
    
}

public class shootCommand : Command
{
    public override void doAction(GameObject g)
    {
        //raycast forward
        RaycastHit hit;
        Physics.Raycast(g.transform.position, g.transform.forward, out hit);
        if(hit.collider == null)
        {
            //Debug.Log("FAILED SHOT");
            DuckManager.instance.setFailedShots(DuckManager.instance.getFailedShots() +1);
            return;
        }
        if (hit.collider.gameObject.tag.Equals("Duck"))
        {
            DuckManager.instance.setFailedShots(0);
            DuckManager.instance.addDuck(hit.collider.gameObject.GetComponent<DuckBehaviour>());
        }
    }
}

public class moveUpCommand : Command
{
    public override void doAction(GameObject g)
    {
        g.transform.position += Vector3.up * Time.deltaTime * speed;
    }
}

public class moveDownCommand : Command
{
    public override void doAction(GameObject g)
    {
        g.transform.position -= Vector3.up * Time.deltaTime * speed;
    }
}
public class moveRightCommand : Command
{
    public override void doAction(GameObject g)
    {
        g.transform.position += Vector3.right * Time.deltaTime * speed;
    }
}
public class moveLeftCommand : Command
{
    public override void doAction(GameObject g)
    {
        g.transform.position -= Vector3.right * Time.deltaTime * speed;
    }
}

