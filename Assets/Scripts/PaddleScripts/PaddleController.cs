using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{

    [SerializeField]
    float speed;

    [SerializeField]
    float leftTarget,rightTarget;


    GameManager gameManager;

    private void Awake()
    {
        gameManager = Object.FindObjectOfType<GameManager>();
    }

    void Update()
    {

        if(gameManager.gameOver)
        {
            return;
        }



        //hareket ettirme.
        float h = Input.GetAxis("Horizontal");

        transform.Translate(Vector2.right * h * Time.deltaTime * speed);
        /*
        if (transform.position.x < leftTarget)
        {
            transform.position = new Vector2(leftTarget, transform.position.y);
        }

        if (transform.position.x > rightTarget)
        {
            transform.position = new Vector2(rightTarget, transform.position.y);
        }
        */

        //Sýnýrlandýrma yapýldý.
        Vector2 temp = transform.position;

        temp.x = Mathf.Clamp(temp.x, leftTarget, rightTarget);

        transform.position = temp;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "LiveUpBall")
        {
            gameManager.UpdateLives(1);
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "skorUpBall")
        {
            gameManager.UpdateScore(10);
            Destroy(other.gameObject);
        }
    }

}
