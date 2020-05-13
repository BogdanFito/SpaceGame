using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LaserShot : MonoBehaviour, IPointerDownHandler


{
    private AudioSource laserShot;
    GameObject player;

    [SerializeField]
    private GameObject laserPrefab;

    void Start()
    {
        laserShot = GameObject.Find("Player").GetComponent<AudioSource>();
        player = GameObject.Find("Player");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (gameObject.name == "Shot")
        {
            laserShot.Play();
            Instantiate(laserPrefab, new Vector3(player.transform.position.x, player.transform.position.y + 1.5f, 0), Quaternion.identity);
            
        }
    }

    

    

    
}
