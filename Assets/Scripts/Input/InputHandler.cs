using UnityEngine;              // Importiert Unity�s Grundfunktionen(Monobavior, GameObjects,etc.)
using UnityEngine.InputSystem;  // Importiert das neue Unity InputSystem f�r morderne Eingabebehandlung

public class InputHandler : MonoBehaviour
{
    [Header("Input Action Asset")] // Erstelle im Unity Inspector eine �berschrift
    [SerializeField] private InputActionAsset playerControls; 

    [Header("Config")] 
    [SerializeField] private string actionMapName = "Player"; // private Variable f�r den Namen der Action Map

    [Header("Config")]
    [SerializeField] private string jump = "Jump"; // Private Variable f�r den Namen der Jump-Action || Standart
 
    private InputAction jumpAction; // Referenz zur Jump Action 
    private InputActionMap actionMap; // Cache f�r bessere Performance...

    public bool JumpTriggered { get; private set; } // �ffentlich lesbare, aber privat setzbare Eigenschaft | Wurde Jump gerade gedr�ckt? 

    private void Awake()
    {
        actionMap = playerControls.FindActionMap(actionMapName);

        jumpAction = actionMap.FindAction(jump);

        SetupInputEvents(); 
    }

    private void SetupInputEvents()
    {
        jumpAction.performed += ctx => JumpTriggered = true;
        jumpAction.canceled += ctx => JumpTriggered = false;
    }

    private void OnEnable()
    {
        actionMap?.Enable(); //playerControls.FindActionMap(actionMapName).Enable(); 
    }

    private void OnDisable()
    {
        actionMap?.Disable(); //playerControls.FindActionMap(actionMapName).Disable();
    }
}
