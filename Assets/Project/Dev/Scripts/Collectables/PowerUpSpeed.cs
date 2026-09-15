using UnityEngine;

public class PowerUpSpeed : PowerUpBase
{
    protected override void Collect()
    {
        base.Collect();
        player.GetComponent<KeyboardControls>()?.SpeedUp(1.2f);
    }
}
