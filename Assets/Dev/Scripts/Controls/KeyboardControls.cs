using UnityEngine;
using UnityEngine.InputSystem;

public class KeyboardControls : MonoBehaviour
{
    [SerializeField] private InputActionReference changeLaneAction;
    private float a;

    private void OnEnable()
    {
        changeLaneAction.action.Enable();
    }

    private void Update()
    {
        a = changeLaneAction.action.ReadValue<float>();

        print(a);
    }
}
