using UnityEngine;
using UnityEngine.InputSystem;
public class Player : MonoBehaviour
{
    [SerializeField] InputActionReference _moveInput;
    [SerializeField] InputActionReference _sprintInput;
    [SerializeField] InputActionReference _jumpInput;


    private void Start()
    {
        _moveInput.action.started += Move;

        _moveInput.action.started += MovePerformed;

        _moveInput.action.started += MoveCanceled;
    }

    private void OnDestroy()
    {
        _moveInput.action.started += Move;

        _moveInput.action.started += MovePerformed;

        _moveInput.action.started += MoveCanceled;
    }

    private void Update()
    {
        var dir = _moveInput.action.ReadValue<Vector2>();
    }

    private void MoveCanceled(InputAction.CallbackContext obj)
    {
        Debug.Log("cancel");
    }
    private void MovePerformed(InputAction.CallbackContext obj)
    {
        Debug.Log("performed");
        var dir = obj.ReadValue<Vector2>();

        dir = _sprintInput.action.IsPressed() ? dir * 2 : dir;
        Debug.Log(obj.ReadValue<Vector2>());
    }
    private void Move(InputAction.CallbackContext obj)
    {
        Debug.Log("started");
    }


}
