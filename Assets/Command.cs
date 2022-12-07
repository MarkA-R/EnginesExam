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

