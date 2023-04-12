using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleControler : MonoBehaviour
{
    public Vector2 speed;
    public KeyCode upKey;
    public KeyCode downKey;

    private Rigidbody2D rig;


    // Start is called before the first frame update
    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        // get input 
        Vector3 movement = GetInput();

        // Move Object
        moveObject(movement);
    }

    private Vector3 GetInput()
    {
        if (Input.GetKey(upKey))
        { 
            return Vector3.up * speed;
        } 
        else if (Input.GetKey(downKey))
        { 
            return Vector3.down * speed;
        }
        else {
            return Vector3.zero;
        }

    }

    private void moveObject(Vector3 movement){
        Debug.Log("TEST: " + movement);
        rig.velocity = movement;
    }
}
