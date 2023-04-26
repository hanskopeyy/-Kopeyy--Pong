using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleControler : MonoBehaviour
{
    public Vector2 speed;
    public KeyCode upKey;
    public KeyCode downKey;

    private Rigidbody2D rig;

    // Power Up
    private bool isLonger;
    private float LongerTimer;
    private float LongerDuration;
    private Vector3 defaultSize;
    
    private bool isSpeed;
    private float SpeedTimer;
    private float SpeedDuration;
    private Vector2 defaultSpeed;

    // Start is called before the first frame update
    private void Start()
    {
        defaultSize = gameObject.transform.localScale;
        defaultSpeed = speed;
        rig = GetComponent<Rigidbody2D>();
        isLonger = false;
    }

    // Update is called once per frame
    private void Update()
    {
        // get input 
        Vector3 movement = GetInput();

        // Move Object
        moveObject(movement);

        if(isLonger){
            LongerTimer += Time.deltaTime;
            if(LongerTimer > LongerDuration){
                DeActivatePULongerPaddle();
            }
        }
        if(isSpeed){
            SpeedTimer += Time.deltaTime;
            if(SpeedTimer > SpeedDuration){
                DeActivatePUSpeedUpPaddle();
            }
        }
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

    public void ActivatePULongerPaddle(float length, float PUduration)
    {
        if(!isLonger)
        {
            gameObject.transform.localScale += new Vector3(0,length,0);
            isLonger = true;
        }
        LongerDuration = PUduration;
        LongerTimer = 0;
    }
    public void DeActivatePULongerPaddle()
    {
        gameObject.transform.localScale = defaultSize;
        isLonger = false;
    }

    public void ActivatePUSpeedUpPaddle(float magnitude, float PUDuration)
    {
        if(!isSpeed)
        {
            speed *= magnitude;
            isSpeed = true;
        }
        SpeedDuration = PUDuration;
        SpeedTimer = 0;
    }
    public void DeActivatePUSpeedUpPaddle()
    {
        speed = defaultSpeed;
        isSpeed = false;
    }

    private void moveObject(Vector3 movement){
        rig.velocity = movement;
    }
}
