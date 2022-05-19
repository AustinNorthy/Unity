using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public GameObject OpenedDoor;
    public GameObject ClosedDoor;
    public bool isOpened;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //OpenedDoor = GameObject.FindGameObjectWithTag("OpenedDoor");
        //ClosedDoor = GameObject.FindGameObjectWithTag("ClosedDoor");
        ClosedDoor = this.gameObject.transform.GetChild(5).gameObject;
        OpenedDoor = this.gameObject.transform.GetChild(6).gameObject;
        if (isOpened == true)
        {
            ClosedDoor.GetComponent<MeshRenderer>().enabled = false;
            ClosedDoor.GetComponent<BoxCollider>().enabled = false;
            OpenedDoor.GetComponent<MeshRenderer>().enabled = true;
            OpenedDoor.GetComponent<BoxCollider>().enabled = true;
        }
        if(isOpened == false)
        {
            OpenedDoor.GetComponent<MeshRenderer>().enabled = false;
            OpenedDoor.GetComponent<BoxCollider>().enabled = false;
            ClosedDoor.GetComponent<MeshRenderer>().enabled = true;
            ClosedDoor.GetComponent<BoxCollider>().enabled = true;
        }
    }

}
