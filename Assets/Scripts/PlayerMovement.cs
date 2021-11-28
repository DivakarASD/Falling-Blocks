using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 7f;
    public event Action OnPlayerDeath;
    public float screenHalfWidthInWorldUnits;
    void Start()
    {
        float playerHalfSize = transform.localScale.x / 2;
        screenHalfWidthInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize + playerHalfSize;
        Console.WriteLine("hi");
        //Debug.Log(Camera.main.aspect+","+screenHalfWidthInWorldUnits+","+Camera.main.orthographicSize);
    }


    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float velocity = inputX * speed;
        float moveAmount = velocity * Time.deltaTime;
        transform.Translate(Vector2.right * moveAmount);
        /*Vector3 movement = new Vector3(Input.GetAxisRaw("Horizontal"),0,0); Usual method for movement in 3d.
        Vector3 direction = movement.normalized;
        Vector3 velocity = speed * direction;
        Vector3 moveAmount = velocity * Time.deltaTime;
        Debug.Log(moveAmount);
        transform.Translate(moveAmount);*/
        if (transform.position.x<-screenHalfWidthInWorldUnits)
        {
            transform.position = new Vector2(screenHalfWidthInWorldUnits, transform.position.y);
        }
        if(transform.position.x>screenHalfWidthInWorldUnits)
        {
            transform.position = new Vector2(-screenHalfWidthInWorldUnits,transform.position.y);
        }

    }
    void OnTriggerEnter2D(Collider2D block)//This method will be called automatically by the physics engine.
    {
        if (block.gameObject.tag == "Block")
        {
            if (OnPlayerDeath!=null)
            {
                OnPlayerDeath();
            }
            Destroy(gameObject);
        }
    }
}