using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Transform target;
    public float smoothSpeed = 0.3f;
    public float Yoffset = 1f;
    public float Xoffset = 1f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newpos = new Vector3(target.position.x+Xoffset, target.position.y+Yoffset, -10f);
        transform.position = Vector3.Slerp(transform.position, newpos, smoothSpeed * Time.deltaTime);   
    }
}
