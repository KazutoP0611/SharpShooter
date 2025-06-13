using UnityEngine;

[CreateAssetMenu(fileName = "WeaponSO", menuName = "Scriptable Object/WeaponSO")]
public class WeaponSO : ScriptableObject
{
    public GameObject WeaponPrefab;
    public int Damage = 10;
    public float FireRate = 0.5f;
    public GameObject HitVFX;
    public bool IsAutomatic = false;
    public bool CanZoom = false;
}
