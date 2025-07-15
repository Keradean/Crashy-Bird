using UnityEngine;              // Importiert Unity´s Grundfunktionen(Monobavior, GameObjects,etc.)
using UnityEngine.InputSystem;  // Importiert das neue Unity InputSystem für morderne Eingabebehandlung

public class InputHandler : MonoBehaviour
{
    [Header("Input Action Asset")] // Erstelle im Unity Inspector eine Überschrift
    [SerializeField] private InputActionAsset playerControls; 

    [Header("Config")] 
    [SerializeField] private string actionMapName = "Player"; // private Variable für den Namen der Action Map

    [Header("Config")]
    [SerializeField] private string jump = "Jump"; // Private Variable für den Namen der Jump-Action || Standart
 
    private InputAction jumpAction; // Referenz zur Jump Action 
    private InputActionMap actionMap; // Cache für bessere Performance...

    public bool JumpTriggered { get; private set; } // öffentlich lesbare, aber privat setzbare Eigenschaft | Wurde Jump gerade gedrückt? 

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
