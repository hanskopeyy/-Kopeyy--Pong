using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PU_SpeedUpPaddle : MonoBehaviour
{
    public Collider2D ball;
    public GameObject paddle_l;
    public GameObject paddle_r;
    public float magnitude;
    public float duration;
    public PowerUpManager manager;

    private void OnTriggerEnter2D(Collider2D collision) 
    { 
        if (collision == ball) 
        { 
            paddle_l.GetComponent<PaddleControler>().ActivatePUSpeedUpPaddle(magnitude, duration);
            paddle_r.GetComponent<PaddleControler>().ActivatePUSpeedUpPaddle(magnitude, duration);
            manager.RemovePowerUp(gameObject);
        }     
    } 

}
