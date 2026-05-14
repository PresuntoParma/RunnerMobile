using UnityEngine;
using UnityEngine.InputSystem;
using DG.Tweening;
using System.Collections;

public class KeyboardControls : MonoBehaviour
{
    [SerializeField] private InputActionReference changeLaneAction;

    [SerializeField] private GameObject movePoint;
    [SerializeField] private float moveTime = 0.2f;
    private float dir;

    private bool isMoving;
    private float startPosX;
    private float laneWidth = 10f;

    private void OnEnable()
    {
        changeLaneAction.action.Enable();
    }

    private void OnDisable()
    {
        changeLaneAction.action.Disable();
    }

    private void Update()
    {
        ChangeLane();
    }

    private void ChangeLane()
    {
        Tween moveTween;
        dir = changeLaneAction.action.ReadValue<float>();
        print(dir);

        Vector3 changeLane = transform.position;

        if (dir != 0 && !isMoving)
        {
            //Retorna se tentar mover para fora da pista
            if (dir > 0 && transform.position.x > 5) return;
            if (dir < 0 && transform.position.x < -5) return;

            changeLane.x += laneWidth * dir;
            
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
}
