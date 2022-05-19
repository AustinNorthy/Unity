using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceScript : MonoBehaviour
{
    public Transform fakeWall;

    public GameObject Wall;
    public GameObject FakeWall;
    public GameObject player;

    public Material RedWall;
    public Material GreyWall;
        
    public Vector3 CheckBox;

    private IEnumerator coroutine;

    public float y;
    public float wood;
    public float stone;

    public bool canBuild = true;
    public bool spaceToBuild = true;
    public bool isTorch;

    public string RequiredCollision;

    public LayerMask badLayers;
    public LayerMask goodLayers;

    public IEnumerator AbleToBuild(float waitTime)
    {
        canBuild = false;
        Instantiate(Wall, new Vector3(fakeWall.position.x, fakeWall.position.y - y, fakeWall.position.z), fakeWall.rotation);
        yield return new WaitForSeconds(1f);
        canBuild = true;
        player.GetComponent<UIandBuilding>().wood -= 75;
        player.GetComponent<UIandBuilding>().stone -= 50;
    }
    public IEnumerator AbleToBuildTorch(float waitTime)
    {
        canBuild = false;
        Instantiate(Wall, new Vector3(fakeWall.position.x, fakeWall.position.y - y, fakeWall.position.z), fakeWall.rotation);
        yield return new WaitForSeconds(1f);
        canBuild = true;
        player.GetComponent<UIandBuilding>().wood -= 20;
        player.GetComponent<UIandBuilding>().stone -= 5;
    }

    void Place()
    {
        if (isTorch == false)
        {
            if (canBuild == true && spaceToBuild == true && wood >= 75 && stone >= 50)
            {
                if (Input.GetKeyDown(KeyCode.Mouse1))
                {
                    StartCoroutine(AbleToBuild(1f));
                }

            }
        } else if (isTorch == true)
        {
            if (canBuild == true && spaceToBuild == true && wood >= 20 && stone >= 5)
            {
                if (Input.GetKeyDown(KeyCode.Mouse1))
                {
                    StartCoroutine(AbleToBuildTorch(1f));
                }

            }
        }
    }

    private void Update()
    {
        wood = player.GetComponent<UIandBuilding>().wood;
        stone = player.GetComponent<UIandBuilding>().stone;
        if (Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log("");
        }
        if (Physics.CheckBox(fakeWall.position, CheckBox, fakeWall.rotation, badLayers))
        {
            spaceToBuild = false;
            FakeWall.GetComponent<MeshRenderer>().material = RedWall;
        }
        else if (Physics.CheckBox(fakeWall.position, CheckBox, fakeWall.rotation, goodLayers) && wood >= 75 && stone >= 50 && isTorch == false)
        {           
            spaceToBuild = true;
            FakeWall.GetComponent<MeshRenderer>().material = GreyWall;
            Place();
        } else if(wood < 75 && isTorch == false || stone < 50 && isTorch == false)
        {
            spaceToBuild = false;
            FakeWall.GetComponent<MeshRenderer>().material = RedWall;
        }
        else if (Physics.CheckBox(fakeWall.position, CheckBox, fakeWall.rotation, goodLayers) && wood >= 20 && stone >= 5 && isTorch == true)
        {
            spaceToBuild = true;
            FakeWall.GetComponent<MeshRenderer>().material = GreyWall;
            Place();
        }
        else if (wood < 20 && isTorch == true|| stone < 5 && isTorch == true)
        {
            spaceToBuild = false;
            FakeWall.GetComponent<MeshRenderer>().material = RedWall;
        }
        else
        {
            spaceToBuild = false;
            FakeWall.GetComponent<MeshRenderer>().material = RedWall;
        }

    }

    /*
    void OnCollisionStay(Collision collision)
    {
        if (canBuild == true)
        {

            if (collision.gameObject.tag != RequiredCollision)
            {
                spaceToBuild = false;
                FakeWall.GetComponent<MeshRenderer>().material = RedWall;
            }            
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                StartCoroutine(AbleToBuild(1f));
            }

        }
        
        /*if (collision.gameObject.tag != RequiredCollision)
        {
            spaceToBuild = false;
        }
        else if(collision.gameObject.tag == RequiredCollision)
        {
            spaceToBuild = true;            
            Place();

        }
        
    }

    void OnCollisionExit(Collision collision)
    {        
        spaceToBuild = true;
        FakeWall.GetComponent<MeshRenderer>().material = GreyWall;
    }

*/


}
