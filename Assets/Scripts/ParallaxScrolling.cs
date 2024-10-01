using UnityEngine;

public class ParallaxScrolling : MonoBehaviour
{
    [SerializeField] private float parallaxSpeed;


    private float spriteHeight;
    Vector2 startPos;
    void Start()
    {
        spriteHeight = GetComponent<SpriteRenderer>().bounds.size.y;
        startPos = transform.position;
    }

    void Update()
    {
        transform.Translate(parallaxSpeed * Time.deltaTime * Vector2.down);
        if(transform.position.y < startPos.y-spriteHeight)
        {
            transform.position=startPos;    
        }
    }
}
