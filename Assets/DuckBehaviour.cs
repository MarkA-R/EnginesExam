using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckBehaviour : MonoBehaviour
{

    float speed = 6;
    // Start is called before the first frame update
    void Start()
    {
        DuckManager.instance.addDuck(this);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.up * Time.deltaTime * speed;
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag.Equals("Respawn"))
        {
            DuckManager.instance.addDuck(this);
            
        }
    }
}
