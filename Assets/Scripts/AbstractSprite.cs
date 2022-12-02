using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractSprite : MonoBehaviour
{
    protected float MovingSpeed = 1f;
    protected SpriteRenderer SpriteRenderer;

    public void Awake()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Start()
    {
        
    }
    
    public void Update()
    {
        
    }
    
    public virtual void Move(Vector3 directionVector)
    {
        SpriteRenderer.flipX = directionVector.x < 0;

        transform.position += Time.deltaTime * MovingSpeed * directionVector;
    }
}
