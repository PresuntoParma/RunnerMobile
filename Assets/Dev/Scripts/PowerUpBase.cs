using UnityEngine;

public class PowerUpBase : MonoBehaviour
{
    [SerializeField] protected GameObject visualObject;
    [SerializeField] protected string tagToCheckPlayer;
    protected GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(tagToCheckPlayer))
        {
            player = other.gameObject;
            Collect();
        }
    }

    virtual protected void Collect()
    {
        Destroy(visualObject);
        Destroy(this.gameObject, 3f);
    }

}
