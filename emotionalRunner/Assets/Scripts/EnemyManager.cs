using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float speed = 2f;
    public float moveDistance = 3f;
    private Vector3 Startposition;
    private bool movingright = true;

    void Start()
    {
        Startposition = transform.position;    
    }

    // Update is called once per frame
    void Update()
    {
        if (movingright)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            if (transform.position.x > Startposition.x + moveDistance)
            {
                movingright = false;
            }
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            if (transform.position.x < Startposition.x + moveDistance) movingright = true;
        }
        
    }
}
