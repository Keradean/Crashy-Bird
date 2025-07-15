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

    public bool JumpTriggered { get; private set; } // �ffentlich lesbare, aber privat setzbare Eigenschaft | Wurde Jump gerade gedr�ckt? 

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
