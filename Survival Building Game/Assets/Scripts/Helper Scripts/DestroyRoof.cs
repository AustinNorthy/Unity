using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyRoof : MonoBehaviour
{
    public Vector3 CheckBox;

    public LayerMask wallLayer;

    public bool CheckWallBool;

    public float y;

    // Start is called before the first frame update
    void Awake()
    {
        CheckWallBool = true;  
    }

    // Update is called once per frame
    void Update()
    {
        if(CheckWallBool == true)
        {
            StartCoroutine(checkForWalls());
        }
    }

    public IEnumerator checkForWalls()
    {
        CheckWallBool = false;
        if (Physics.CheckBox(new Vector3(this.transform.position.x, this.transform.position.y - y, this.transform.position.z), CheckBox, this.transform.rotation, wallLayer))
        {
            this.gameObject.SetActive(true);
        } else
        {
            this.gameObject.SetActive(false);
        }
        yield return new WaitForSeconds(2f);
        CheckWallBool = true;
    }

}
