using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrapHotbar : MonoBehaviour
{

    [SerializeField]
    private GameObject[] weapons;

    public GameObject Wall;
    public GameObject Door;
    public GameObject Floor;
    public GameObject Roof;
    public GameObject Stairs;
    public GameObject Window;
    public GameObject Axe;
    public GameObject Torch;

    public int current_Weapon_Index;

    // Start is called before the first frame update
    void Start()
    {
        current_Weapon_Index = 0;
        weapons[current_Weapon_Index].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            TurnOnSelectedWeapon(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            TurnOnSelectedWeapon(1);
            Axe.GetComponent<AxeSwing>().canShoot = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            TurnOnSelectedWeapon(2);
            Floor.GetComponent<PlaceScript>().canBuild = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            TurnOnSelectedWeapon(3);
            Wall.GetComponent<PlaceScript>().canBuild = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            TurnOnSelectedWeapon(4);
            Door.GetComponent<PlaceScript>().canBuild = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            TurnOnSelectedWeapon(5);
            Window.GetComponent<PlaceScript>().canBuild = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            TurnOnSelectedWeapon(6);
            Stairs.GetComponent<PlaceScript>().canBuild = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            TurnOnSelectedWeapon(7);
            Roof.GetComponent<PlaceScript>().canBuild = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            TurnOnSelectedWeapon(8);
            Torch.GetComponent<PlaceScript>().canBuild = true;
        }
    }
    
    void TurnOnSelectedWeapon(int weaponIndex)
    {
        if (current_Weapon_Index == weaponIndex)
            return;

        weapons[current_Weapon_Index].SetActive(false);

        weapons[weaponIndex].SetActive(true);

        current_Weapon_Index = weaponIndex;
    }

}
