using UnityEngine;

public class Pipes : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] float moveSpeed = 5f; 
    [SerializeField] float deadZone = -13; 
     
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.left * moveSpeed * Time.deltaTime);
        if (transform.position.x < deadZone)
        {
            Destroy(gameObject);
        }
    }
}
