using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeSwing : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public Camera fpsCam;
    public bool canShoot;
   // public IEnumerator Shoot;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
           StartCoroutine(Shoot());
        }
    }

    public IEnumerator wait()
    {
        canShoot = false;
        yield return new WaitForSeconds(1f);
        canShoot = true;
    }

    public IEnumerator Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            

            Hitable enemy = hit.transform.GetComponent<Hitable>();
            if (enemy != null && canShoot == true)
            {
                canShoot = false;
                enemy.TakeDamage();
                Debug.Log(hit.transform.name);
                yield return new WaitForSeconds(1f);
                canShoot = true;
            }
        }
        else
        {
            canShoot = true;
        }
    }
}
