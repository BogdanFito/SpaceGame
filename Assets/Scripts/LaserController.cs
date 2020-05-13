using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    private int laserSpeed = 6;


   
    void Update()
    {
        StartCoroutine("movement");
    }

    private IEnumerator movement()
    {
        transform.Translate(Vector3.up * laserSpeed * Time.deltaTime);

        if (transform.position.y >= 5.7f)
        {
            Destroy(this.gameObject, 1);

            
        }
        yield return null;
    }

}
