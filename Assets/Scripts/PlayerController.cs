using System.Collections;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private GameObject playerExplosionPrefab;

    [SerializeField]
    private int PlayerLives = 5;

    [SerializeField]
    private int speed = 6;

    private float moveRight;

    

    

    public int rotation;
    

    
    void Start()
    {
        transform.position = new Vector3(0, -3.9f, 0);
        


    }

    
    void Update()
    {
        StartCoroutine("SpaceMovement");

    }

    public void lifeSubstraction()
    {
        PlayerLives--;
        if (PlayerLives == 0)
        {
            Instantiate(playerExplosionPrefab, transform.position, Quaternion.identity);

            Destroy(this.gameObject);

            SceneManager.LoadScene("GameOver");

            AndroidJavaClass javaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject javaObject = javaClass.GetStatic<AndroidJavaObject>("currentActivity");
            javaObject.Call("transition");
        }
        
    }



    private IEnumerator SpaceMovement()
    {
        if (rotation == 0) yield return null;

        transform.Translate(Vector3.right * rotation * Time.deltaTime * speed);
        
        if (transform.position.x > 8)
           transform.position = new Vector3(8, transform.position.y, 0);
       else if (transform.position.x < -8)
           transform.position = new Vector3(-8, transform.position.y, 0);
        
    }

    
}
