using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightTime : MonoBehaviour
{
    public GameObject NightTimeWalls;
    public bool isNight;
    public Light directionalLight;
    public GameObject player;

    public Material matDay;
    public Material matDawn;

    public Transform[] TreeSpawn;
    public GameObject[] TreeType;

    public GameObject[] RockSpawns;
    public GameObject[] RockTypes;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(IsDayTimer());
    }

    // Update is called once per frame
    void Update()
    {
        if (isNight == true)
        {
            RenderSettings.fogDensity = 1f;
            NightTimeWalls.SetActive(true);
        }
        if (isNight == false)
        {
            NightTimeWalls.SetActive(false);
            RenderSettings.fogDensity = 0f;
        }

        if (GetComponent<CrapHotbar>().current_Weapon_Index == 8 && isNight == true)
        {
            RenderSettings.fogDensity = 0.05f;
        } else if (GetComponent<CrapHotbar>().current_Weapon_Index != 8 && isNight == true)
        {
            RenderSettings.fogDensity = 0.1f;
        } else if (isNight == false)
        {
            RenderSettings.fogDensity = 0f;
        }
    }

    public IEnumerator IsDayTimer()
    {
        isNight = false;
        directionalLight.intensity = 1f;
        RenderSettings.skybox = matDay;
        yield return new WaitForSeconds(60f);
        StartCoroutine(IsDuskTimer());
    }

    public IEnumerator IsDuskTimer()
    {
        isNight = false;
        RenderSettings.skybox = matDawn;
        directionalLight.intensity = 0.5f;
        yield return new WaitForSeconds(20f);
        StartCoroutine(IsNightTimer());
    }

    public IEnumerator IsNightTimer()
    {
        isNight = true;
        directionalLight.intensity = 0.03f;
        yield return new WaitForSeconds(60f);
        StartCoroutine(IsDawnTimer());
        player.GetComponent<UIandBuilding>().days += 1;
        SpawnRocksAndTrees();
    }

    public IEnumerator IsDawnTimer()
    {
        isNight = false;
        directionalLight.intensity = 0.5f;
        yield return new WaitForSeconds(20f);
        StartCoroutine(IsDayTimer());
    }

    public void SpawnRocksAndTrees()
    {
        // Spawning Trees
        Instantiate(TreeType[0], new Vector3(TreeSpawn[0].position.x, TreeSpawn[0].position.y, TreeSpawn[0].position.z), TreeSpawn[0].rotation);
        Instantiate(TreeType[1], new Vector3(TreeSpawn[1].position.x, TreeSpawn[1].position.y, TreeSpawn[1].position.z), TreeSpawn[1].rotation);
        Instantiate(TreeType[2], new Vector3(TreeSpawn[2].position.x, TreeSpawn[2].position.y, TreeSpawn[2].position.z), TreeSpawn[2].rotation);
        Instantiate(TreeType[3], new Vector3(TreeSpawn[3].position.x, TreeSpawn[3].position.y, TreeSpawn[3].position.z), TreeSpawn[3].rotation);
        Instantiate(TreeType[4], new Vector3(TreeSpawn[4].position.x, TreeSpawn[4].position.y, TreeSpawn[4].position.z), TreeSpawn[4].rotation);
        Instantiate(TreeType[0], new Vector3(TreeSpawn[5].position.x, TreeSpawn[5].position.y, TreeSpawn[5].position.z), TreeSpawn[5].rotation);
        Instantiate(TreeType[1], new Vector3(TreeSpawn[6].position.x, TreeSpawn[6].position.y, TreeSpawn[6].position.z), TreeSpawn[6].rotation);
        Instantiate(TreeType[2], new Vector3(TreeSpawn[7].position.x, TreeSpawn[7].position.y, TreeSpawn[7].position.z), TreeSpawn[7].rotation);
        Instantiate(TreeType[3], new Vector3(TreeSpawn[8].position.x, TreeSpawn[8].position.y, TreeSpawn[8].position.z), TreeSpawn[8].rotation);
        Instantiate(TreeType[4], new Vector3(TreeSpawn[9].position.x, TreeSpawn[9].position.y, TreeSpawn[9].position.z), TreeSpawn[9].rotation);

        //Spawning Rocks
        Instantiate(RockTypes[0], new Vector3(RockSpawns[0].transform.position.x, RockSpawns[0].transform.position.y, RockSpawns[0].transform.position.z), RockSpawns[0].transform.rotation);
        Instantiate(RockTypes[1], new Vector3(RockSpawns[1].transform.position.x, RockSpawns[1].transform.position.y, RockSpawns[1].transform.position.z), RockSpawns[1].transform.rotation);
        Instantiate(RockTypes[2], new Vector3(RockSpawns[2].transform.position.x, RockSpawns[2].transform.position.y, RockSpawns[2].transform.position.z), RockSpawns[2].transform.rotation);
        Instantiate(RockTypes[3], new Vector3(RockSpawns[3].transform.position.x, RockSpawns[3].transform.position.y, RockSpawns[3].transform.position.z), RockSpawns[3].transform.rotation);
        Instantiate(RockTypes[4], new Vector3(RockSpawns[4].transform.position.x, RockSpawns[4].transform.position.y, RockSpawns[4].transform.position.z), RockSpawns[4].transform.rotation);
        Instantiate(RockTypes[0], new Vector3(RockSpawns[5].transform.position.x, RockSpawns[5].transform.position.y, RockSpawns[5].transform.position.z), RockSpawns[5].transform.rotation);
        Instantiate(RockTypes[1], new Vector3(RockSpawns[6].transform.position.x, RockSpawns[6].transform.position.y, RockSpawns[6].transform.position.z), RockSpawns[6].transform.rotation);
        Instantiate(RockTypes[2], new Vector3(RockSpawns[7].transform.position.x, RockSpawns[7].transform.position.y, RockSpawns[7].transform.position.z), RockSpawns[7].transform.rotation);
        Instantiate(RockTypes[3], new Vector3(RockSpawns[8].transform.position.x, RockSpawns[8].transform.position.y, RockSpawns[8].transform.position.z), RockSpawns[8].transform.rotation);
        Instantiate(RockTypes[4], new Vector3(RockSpawns[9].transform.position.x, RockSpawns[9].transform.position.y, RockSpawns[9].transform.position.z), RockSpawns[9].transform.rotation);
    }


}
