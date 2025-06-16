using UnityEngine;

public class AmmoPickup : Pickup
{
    [SerializeField] int ammoAmount = 50;

    const string PLAYER_STRING = "Player";

    protected override void OnPickup(ActiveWeapon activeWeapon)
    {
        activeWeapon.UpdateAmmo(ammoAmount);
    }
}
