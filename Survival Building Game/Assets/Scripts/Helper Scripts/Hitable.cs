using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitable : MonoBehaviour
{
    public float health;
    public GameObject player;
    public bool isTree;
    public bool isStone;
    public bool isBuild;
    public bool isAnimal;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            Destroy(this.gameObject, 1);
        }
    }

    public void TakeDamage()
    {
        health -= 10;
        if(health <= 0)
        {
            this.gameObject.transform.position = new Vector3(1, -20, 1);
            Destroy(this.gameObject, 1);
            if (isTree == true)
            {
                player.GetComponent<UIandBuilding>().wood += 150;
            }
            if (isStone == true)
            {
                player.GetComponent<UIandBuilding>().stone += 100;
            }
            if(isBuild == true)
            {
                player.GetComponent<UIandBuilding>().stone += 25;
                player.GetComponent<UIandBuilding>().wood += 50;
            }
            if(isAnimal == true)
            {
                player.GetComponent<UIandBuilding>().rawMeat += 3;
            }
        }
    }
}
