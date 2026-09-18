using UnityEngine;

public class SwipeControls : MonoBehaviour
{
    [Header("Swipe Settings")]
    [SerializeField] private float minSwipeDistance = 50f;

    private Vector2 startPosition;
    private Vector2 endPosition;

    private void Update()
    {
        // Detecta o início do toque
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    startPosition = touch.position;
                    break;

                case TouchPhase.Ended:
                    endPosition = touch.position;
                    DetectSwipe();
                    break;
            }
        }
    }

    private void DetectSwipe()
    {
        float swipeDistance = endPosition.x - startPosition.x;

        // Ignora swipes muito pequenos
        if (Mathf.Abs(swipeDistance) < minSwipeDistance)
            return;

        if (swipeDistance > 0)
        {
            SwipeRight();
        }
        else
        {
            SwipeLeft();
        }
    }

    private void SwipeRight()
    {
        Debug.Log("Swipe para Direita");
    }

    private void SwipeLeft()
    {
        Debug.Log("Swipe para Esquerda");
    }
}
