using UnityEngine;

[CreateAssetMenu(fileName = "WeaponSO", menuName = "Scriptable Object/WeaponSO")]
public class WeaponSO : ScriptableObject
{
    public int Damage = 10;
    public float FireRate = 0.5f;
}
