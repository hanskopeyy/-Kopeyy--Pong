using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    // Powerups
    public int MaxPowerUpAmount;
    public List<GameObject> powerUpTemplates;
    private List<GameObject> powerUpList;

    // Powerups Area
    public Transform spawnArea;
    public Vector2 powerUpAreaMin;
    public Vector2 powerUpAreaMax;

    // Timer
    public int spawnInterval;
    private float timer;

    void Start()
    {
        powerUpList = new List<GameObject>();
        timer = 0;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if(timer>spawnInterval)
        {
            GenerateRandomPowerUp();
            timer -= spawnInterval;
        }
    }

    public void GenerateRandomPowerUp()
    {
        GenerateRandomPowerUp(new Vector2(Random.Range(powerUpAreaMin.x, powerUpAreaMax.x), Random.Range(powerUpAreaMin.y, powerUpAreaMax.y))); 
    }

    private void GenerateRandomPowerUp(Vector2 position)
    {
        if(powerUpList.Count >= MaxPowerUpAmount)
        {
            RemovePowerUp(powerUpList[0]);
        }
        if(position.x < powerUpAreaMin.x || position.x > powerUpAreaMax.x ||
            position.y < powerUpAreaMin.y || position.y > powerUpAreaMax.y)
            {
                return;
            }
        
        int randomIndex = Random.Range(0, powerUpTemplates.Count);

        GameObject powerUp = Instantiate(powerUpTemplates[randomIndex], new Vector3(position.x, position.y, powerUpTemplates[randomIndex].transform.position.z), Quaternion.identity, spawnArea); 
        powerUp.SetActive(true);

        powerUpList.Add(powerUp);
    }

    public void RemovePowerUp(GameObject powerUp)
    {
        Debug.Log("Remove PowerUp");
        powerUpList.Remove(powerUp);
        Destroy(powerUp);
    }

    public void RemoveAllPowerUp() 
    { 
        while (powerUpList.Count > 0) 
        { 
            RemovePowerUp(powerUpList[0]); 
        } 
    } 
}
