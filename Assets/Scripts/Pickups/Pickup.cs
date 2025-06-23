using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public abstract class Pickup : MonoBehaviour
{
    [SerializeField] GameObject model;
    [SerializeField] GameObject cooldownCanvas;
    [SerializeField] Image cooldownImg;
    [SerializeField] float cooldownTime;
    [SerializeField] float rotationSpeed = 100.0f;

    bool cooldowning = false;
    float time = 0;
    Coroutine cooldownCoroutine;

    const string PLAYER_STRING = "Player";

    void Update()
    {
        if (!cooldowning)
            model.transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);

        if (cooldowning)
        {
            time += Time.deltaTime;
            cooldownImg.fillAmount = time / cooldownTime;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(PLAYER_STRING) && !cooldowning)
        {
            ActiveWeapon activeWeapon = other.GetComponentInChildren<ActiveWeapon>();
            OnPickup(activeWeapon);
            //Destroy(gameObject);
            ToggleModelAndCooldownIndicator();

            cooldownCoroutine = StartCoroutine(StartCooldown());
        }
    }

    void ToggleModelAndCooldownIndicator()
    {
        cooldowning = !cooldowning;
        model.SetActive(!cooldowning);
        cooldownCanvas.SetActive(cooldowning);
    }

    IEnumerator StartCooldown()
    {
        yield return new WaitForSeconds(cooldownTime);
        time = 0;

        ToggleModelAndCooldownIndicator();
    }

    protected abstract void OnPickup(ActiveWeapon activeWeapon);
}
