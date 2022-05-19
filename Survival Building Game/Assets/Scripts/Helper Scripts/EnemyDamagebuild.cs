using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamagebuild : MonoBehaviour
{
    public bool canBeHit;

    // Start is called before the first frame update
    void Start()
    {
        canBeHit = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider collision)
    {
        if(collision.gameObject.tag == "Enemy" && canBeHit == true)
        {
            StartCoroutine(HitBuild());            
        }
    }

    public IEnumerator HitBuild()
    {
        canBeHit = false;
        GetComponent<Hitable>().health -= 10;
        yield return new WaitForSeconds(2f);
        canBeHit = true;
    }
}
