using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursorMovement : MonoBehaviour
{

    public Command[] movementCommands = new Command[4];
    Command shootingCommand;
    public static cursorMovement instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        movementCommands[0] = new moveUpCommand();
        movementCommands[1] = new moveDownCommand();
        movementCommands[2] = new moveLeftCommand();
        movementCommands[3] = new moveRightCommand();
        shootingCommand = new shootCommand();
    }

    // Update is called once per frame
    void Update()
    {
        List<int> doingActions = new List<int>();
        if (Input.GetKey(KeyCode.W))
        {
            doingActions.Add(0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            doingActions.Add(1);
        }
        if (Input.GetKey(KeyCode.A))
        {
            doingActions.Add(2);
        }
        if (Input.GetKey(KeyCode.D))
        {
            doingActions.Add(3);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            shootingCommand.doAction(gameObject);
        }

        foreach (int i in doingActions)
        {
            movementCommands[i].doAction(gameObject);
        }
    }
}
