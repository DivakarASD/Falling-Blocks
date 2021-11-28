using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBlocksMovement : MonoBehaviour
{
    float speed = 7f;
    public Vector2 speedMinMax;
    float visibleHeightThreshold;
    void Start()
    {
        speed = Mathf.Lerp(speedMinMax.x, speedMinMax.y, Difficulty.GetDifficulty());        
        visibleHeightThreshold = -Camera.main.orthographicSize - transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        if(transform.position.y < visibleHeightThreshold)
        {
            Destroy(gameObject);
        }
    }
}
