using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class ButtonsController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    PlayerController playerController;
    EnemyController enemyController;

    



    public void Start()
    {     
         playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        enemyController = GameObject.Find("Enemy").GetComponent<EnemyController>();
    }

    

    public void OnPointerDown(PointerEventData eventData)
    {
        if (gameObject.name == "Left") playerController.rotation = -1;
        else if (gameObject.name == "Right") playerController.rotation = 1;
        
    }

   

    public void OnPointerUp(PointerEventData eventData)
    {
        playerController.rotation = 0;
    }

    public void maxspeed()
    {
        EnemyController.speed = 7;
    }
    public void midspeed()
    {
        EnemyController.speed = 5;
    }
    public void minspeed()
    {
        EnemyController.speed = 3;
    }


}
