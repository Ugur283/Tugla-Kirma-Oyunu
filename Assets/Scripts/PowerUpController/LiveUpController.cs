using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiveUpController : MonoBehaviour
{
    public float speed;
   
    void Update()
    {
        transform.Translate(Vector2.down * Time.deltaTime * speed);
    }
}
