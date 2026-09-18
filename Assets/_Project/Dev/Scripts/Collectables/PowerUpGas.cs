using UnityEngine;

public class PowerUpGas : PowerUpBase
{
    protected override void Collect()
    {
        base.Collect();

        player.GetComponent<KeyboardControls>().GetGas(30);
    }
}
