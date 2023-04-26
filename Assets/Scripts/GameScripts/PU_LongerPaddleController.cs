using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PU_LongerPaddleController : MonoBehaviour
{
    public Collider2D ball;
    public GameObject paddle_l;
    public GameObject paddle_r;
    public float length;
    public float duration;
    public PowerUpManager manager;

    private void OnTriggerEnter2D(Collider2D collision) 
    { 
        if (collision == ball) 
        { 
            paddle_l.GetComponent<PaddleControler>().ActivatePULongerPaddle(length, duration);
            paddle_r.GetComponent<PaddleControler>().ActivatePULongerPaddle(length, duration);
            manager.RemovePowerUp(gameObject);
        }     
    } 
}
