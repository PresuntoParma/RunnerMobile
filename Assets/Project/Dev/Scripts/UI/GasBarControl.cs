using UnityEngine;
using UnityEngine.UI;

public class GasBarControl : MonoBehaviour
{
    [SerializeField] private KeyboardControls player;
    [SerializeField] private Image gasBarFill;
    [SerializeField] private float gasBarMaxWidth;
    [SerializeField] private float gasBarWidth;

    private void Start()
    {
        gasBarMaxWidth = gasBarFill.rectTransform.rect.width;
    }

    private void Update()
    {
        gasBarWidth = (gasBarMaxWidth / 100) * player.CurrentGas();

        gasBarFill.rectTransform.sizeDelta = new Vector2(gasBarWidth, gasBarFill.rectTransform.rect.height);
    }
}
