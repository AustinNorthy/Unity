using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSnapLock : MonoBehaviour
{
    public Transform player;
    public Transform fakeWall;

    public float setYRotation = 90;
    public float setXRotation;
    public float y;
    public float distance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        Vector3 pos = player.position + player.forward * distance;
        pos.x = Mathf.RoundToInt(pos.x);
        pos.z = Mathf.RoundToInt(pos.z);
        pos.y = Mathf.RoundToInt(pos.y + y);
        fakeWall.position = pos;

        fakeWall.rotation = Quaternion.Euler(setXRotation, setYRotation, 0);

        if (Input.GetKeyDown(KeyCode.Q))
        {
            setYRotation += 45;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            setYRotation -= 45;
        }
        
    }
}
