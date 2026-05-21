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
    [SerializeField] private float hardSpeedLimit;
    [Tooltip("The modifier of how fast player loses speed when above limit, base is 100%")]
    [SerializeField] private float loseSpeedRatio;
    [SerializeField] private string tagToCheckObstacle;
    [SerializeField] private bool isImune = false;
    [SerializeField] private float gasDepleteRate;
    [SerializeField] private float baseGas = 100f;
    [SerializeField] private float currentGas;
    
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
        currentGas = baseGas;
    }

    private void Update()
    {
        ChangeLane();
        LoseSpeed();
        GasDeplete();

        print(currentSpeed);
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
        if(currentSpeed < speedLimit)
            currentSpeed += Time.deltaTime;
    }

    private void LoseSpeed()
    {
        if (currentSpeed > hardSpeedLimit)
            currentSpeed = hardSpeedLimit;

        if (currentSpeed > speedLimit)
            currentSpeed -= (Time.deltaTime/200) * loseSpeedRatio;

        if (currentSpeed < startSpeed)
            currentSpeed = startSpeed;
    }

    public void SpeedDown(float mod = 0)
    {
        currentSpeed -= (currentSpeed * mod);
    }

    public void SpeedUp(float mod = 0)
    {
        currentSpeed += (startSpeed * mod);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(tagToCheckObstacle) && isImune == false)
        {
            SpeedDown(0.30f);
            print("Bateu");
            StartCoroutine(Imune());
        }
    }

    private IEnumerator Imune()
    {
        isImune = true;
        yield return new WaitForSeconds(1f);
        isImune = false;
    }

    private void GasDeplete()
    {
        currentGas -= (Time.deltaTime/100) * gasDepleteRate;
        if (currentGas < 0)
            currentGas = 0;
    }

    public float CurrentGas()
    {
        return currentGas;
    }
}