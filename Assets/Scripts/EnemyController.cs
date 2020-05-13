using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public static int speed = 3;

    [SerializeField]
    private GameObject enemyExplosionPrefab;

    [SerializeField]
    private AudioClip Explosion;

    private int killed=0;


    void Update()
    {
        StartCoroutine("movement");
       
    }
    
    private IEnumerator movement()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (transform.position.y < -6.7f)
        {
            transform.position = new Vector3(Random.Range(-7.5f, 7.5f), 6.7f, 0);
            
            

        }

        if (killed == 10) { Instantiate(this.gameObject, new Vector3(Random.Range(-7.5f, 7.5f), 6.7f, 0), Quaternion.identity); killed = 0; }
        yield return null;
    }
    
    private IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Laser")
        {
            
            Destroy(collision.gameObject);
            Instantiate(enemyExplosionPrefab, transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(Explosion, Camera.main.transform.position, 1.0f);
            transform.position = new Vector3(Random.Range(-7.5f, 7.5f), 6.7f, 0);
            killed++;

        }

        else if (collision.tag == "Player")
        {
            
            PlayerController playerController = collision.GetComponent < PlayerController>();
            if (playerController != null) playerController.lifeSubstraction();
            Instantiate(enemyExplosionPrefab, transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(Explosion, Camera.main.transform.position, 1.0f);
            transform.position = new Vector3(Random.Range(-7.5f, 7.5f), 6.7f, 0);
            killed++;
        }

        yield return null;
    }

   
}
