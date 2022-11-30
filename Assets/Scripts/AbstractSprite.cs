using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractSprite : MonoBehaviour
{
    protected float MovingSpeed = 1f;

    public void Awake()
    {
    }

    public void Start()
    {
        
    }
    
    public void Update()
    {
        
    }
    
    public void Move(Vector3 directionVector)
    {
        transform.position += Time.deltaTime * MovingSpeed * directionVector;
    }
}
