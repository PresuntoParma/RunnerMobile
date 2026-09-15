using MoreMountains.Feedbacks;
using UnityEngine;

public class MenuChangeWindow : MonoBehaviour
{
    public MMSpringRectTransformPosition mmSpring;

    public void ChangeWindow(float x)
    {
        Vector3 targetPos = Vector3.zero;
        targetPos.x = x;

        mmSpring.MoveTo(targetPos);
    }
}
