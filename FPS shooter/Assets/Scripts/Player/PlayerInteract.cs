using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private Camera cam;
    [SerializeField] private float distance = 2f;
    [SerializeField] private LayerMask mask;
    private PlayerUI playerUI;

    void Start()
    {
        cam = GetComponent<PlayerLook>().cam;
        playerUI = GetComponent<PlayerUI>();
    }

    void Update()
    {
        playerUI.UpdateText(string.Empty);
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, distance, mask))
        {
            Interactable interactable = hitInfo.collider.GetComponent<Interactable>();

            if (interactable != null)
            {
                playerUI.UpdateText(interactable.prompt);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    InteractWithObject(interactable);
                }
            }
        }
    }

    void InteractWithObject(Interactable interactable)
    {
        interactable.BaseInteract();

        if (interactable is GunPickup)
        {
            PickUpGun((GunPickup)interactable);
        }
    }

    void PickUpGun(GunPickup gunPickup)
    {
        gunPickup.gameObject.SetActive(false);
    }
}

public class GunPickup : Interactable
{
}