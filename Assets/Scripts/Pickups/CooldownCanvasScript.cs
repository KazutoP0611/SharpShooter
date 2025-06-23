using UnityEngine;

public class CooldownCanvasScript : MonoBehaviour
{
    [SerializeField] Transform playerCameraRoot;

    void Update()
    {
        if (!enabled) return;

        transform.forward = playerCameraRoot.forward;
    }
}
