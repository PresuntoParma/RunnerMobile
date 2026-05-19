using UnityEngine;
using UnityEngine.InputSystem;
using DG.Tweening;
using System.Collections;

public class KeyboardControls : MonoBehaviour
{
    [SerializeField] private InputActionReference changeLaneAction;

    [SerializeField] private float moveTime = 0.2f;
    [SerializeField] private float startSpeed = 5f;
    [SerializeField] private float speedLimit;
    [Tooltip("The modifier of how fast player loses speed, base is 100%")]
    [SerializeField] private float loseSpeedRatio;
    private float currentSpeed;
    private float dir;

    private bool isMoving;
    private float laneWidth = 10f;
    private Rigidbody rb;

    private void OnEnable()
    {
        changeLaneAction.action.Enable();
    }

    private void OnDisable()
    {
        changeLaneAction.action.Disable();
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        currentSpeed = startSpeed;
    }

    private void Update()
    {
        ChangeLane();
        LoseSpeed();
    }

    private void FixedUpdate()
    {
        Accelerate();
    }

    private void ChangeLane()
    {
        Tween moveTween;
        dir = changeLaneAction.action.ReadValue<float>();
        print(dir);


        if (dir != 0 && !isMoving)
        {
            //Retorna se tentar mover para fora da pista
            if (dir > 0 && transform.position.x > 5) return;
            if (dir < 0 && transform.position.x < -5) return;

            
            moveTween = transform.DOMoveX(laneWidth * dir, moveTime).SetRelative();
            StartCoroutine(IsMoving());
        }
    }

    private IEnumerator IsMoving()
    {
        isMoving = true;
        yield return new WaitForSeconds(moveTime);
        isMoving = false;
    }

    private void Accelerate()
    {
        rb.linearVelocity = Vector3.forward * currentSpeed;
    }

    private void LoseSpeed()
    {
        if (currentSpeed > startSpeed)
            currentSpeed -= (Time.deltaTime/200) * loseSpeedRatio;

        if (currentSpeed < startSpeed)
            currentSpeed = startSpeed;
    }

    public void SpeedUp(float mod = 0)
    {
        currentSpeed += (startSpeed * mod);
    }
}
