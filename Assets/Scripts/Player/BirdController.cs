using UnityEngine;

public class BirdController : MonoBehaviour
{
    [SerializeField] private InputHandler inputHandler;

    [Header("Jump Parameters")]
    [SerializeField] private  float flapStrength = 5f;
    [SerializeField] private  float gravityMultiplier = 1.0f;
    [SerializeField] private UIManager Score; 

    private Rigidbody2D rb2D;
    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        rb2D .gravityScale = gravityMultiplier;

        Score = GameObject.FindGameObjectWithTag("Score")?.GetComponent<UIManager>();
    }
    private void Update()
    {
        HandlerInput();
    }

    private void HandlerInput() 
    {
        if (inputHandler.JumpTriggered)
        {
            Jump();
        }
    }

    private void Jump() 
    {
        rb2D.linearVelocity = Vector2.up * flapStrength;
        // Vector2.up = (0,1) -> nur nach oben
        //flapStrength = 5f -> 5 Einheiten/Sekunde nach oben
        // Resultat: (0,5)
    }

    private void OnCollisionEnter2D(Collision2D collision
        )
    { 
        Score.gameOver();
    }
}
