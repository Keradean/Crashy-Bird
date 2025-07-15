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

    public bool JumpTriggered { get; private set; } // öffentlich lesbare, aber privat setzbare Eigenschaft | Wurde Jump gerade gedrückt? 

    private void Awake()
    {
        InputActionMap mapReference = playerControls.FindActionMap(actionMapName);

        jumpAction = mapReference.FindAction(jump);

        InputEvents(); 
    }

    private void InputEvents()
    {
        jumpAction.performed += inputInfo => JumpTriggered = true;
        jumpAction.canceled += inputInfo => JumpTriggered = false;
    }

    private void OnEnable()
    {
        playerControls.FindActionMap(actionMapName).Enable(); 
    }

    private void OnDisable()
    {
        playerControls.FindActionMap(actionMapName).Disable();
    }
}
