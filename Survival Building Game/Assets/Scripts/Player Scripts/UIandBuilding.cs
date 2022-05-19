using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIandBuilding : MonoBehaviour
{
    public float wood;
    public float stone;
    public float days = 1;

    public float Health;
    public float Hunger;
    public float rawMeat;
    public float cookedMeat;

    public Text woodUI;
    public Text stoneUI;
    public Text daysUI;
    public Text rawMeatUI;
    public Text cookedMeatUI;

    public Image healthUI;
    public Image hungerUI;

    public bool isHungry;
    public bool noHunger;
    public bool takeHungerDamage;
    public bool canGainHealthfromHunger;
    public bool muchHunger;

    // Start is called before the first frame update
    void Start()
    {
        Health = 100;
        Hunger = 100;
        isHungry = true;
        takeHungerDamage = true;
        canGainHealthfromHunger = true;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTextandImages();
        HealthandHunger();
    }

    public void UpdateTextandImages()
    {
        woodUI.text = "Wood: " + wood;
        stoneUI.text = "Stone: " + stone;
        daysUI.text = "Day: " + days;
        rawMeatUI.text = "Raw Meat: " + rawMeat;
        cookedMeatUI.text = "Cooked Meat: " + cookedMeat;
    }

    public IEnumerator HungerDown()
    {
        isHungry = false;
        Hunger -= 1;
        yield return new WaitForSeconds(3f);
        isHungry = true;
    }

    public IEnumerator NoHunger()
    {
        takeHungerDamage = false;
        Health -= 2;
        yield return new WaitForSeconds(5f);
        takeHungerDamage = true;
    }

    public IEnumerator GainHealthFromHunger()
    {
        canGainHealthfromHunger = false;
        Health += 5;
        yield return new WaitForSeconds(5f);
        canGainHealthfromHunger = true;
    }

    public void HealthandHunger()
    {
        if (isHungry == true)
        {
            StartCoroutine(HungerDown());
        }
        if (Hunger <= 0)
        {
            noHunger = true;
            Hunger = 0;
            if (noHunger == true && takeHungerDamage == true)
            {
                StartCoroutine(NoHunger());
            }
        }
        if (Hunger >= 1)
        {
            noHunger = false;
        }

        if (Health > 100)
        {
            Health = 100;
        }
        if (Hunger >= 75)
        {
            muchHunger = true;
            if (canGainHealthfromHunger == true && muchHunger == true)
            {
                StartCoroutine(GainHealthFromHunger());
            }
        }
        else
        {
            muchHunger = false;
        }
        if(Health <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }
}
