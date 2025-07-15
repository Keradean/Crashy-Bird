using UnityEngine;

public class ScoreTrigger : MonoBehaviour
{
    [SerializeField] private UIManager Score; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Score = GameObject.FindGameObjectWithTag("Score")?.GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            Score.addScore(1);
        }
            
    }
}
