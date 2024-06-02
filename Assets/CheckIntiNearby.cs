using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckIntiNearby : MonoBehaviour
{
    public GameObject uiGo;
    private readonly Collider[] colliders = new Collider[3];
    [SerializeField] private LayerMask interactableMask;
    [SerializeField] private int objectFound;

    ItemPickupinti interactable;

    void Update()
    {
        if (uiGo.activeSelf == true)
        {
            IntiNearby();
        }
    }

    public void IntiNearby()
    {
        // use spherecast to check if there is any jamur nearby, get ItemPickup component from the jamur

        objectFound = Physics.OverlapSphereNonAlloc(transform.position, 1f,
                        colliders, interactableMask);

        if (objectFound > 0) {
                // gue ambil IInteractablenya, supaya bisa pake fungsi yang ada di IInteractable, yaitu InteractionPrompt, sama Interact
                interactable = colliders[0].GetComponent<ItemPickupinti>();

                
                if (interactable != null) // kalo ada komponent IInteractable di gameobject yang overlap
                {
                    // // gue pasttin dulu, promptnya udah muncul apa belom, kalo belom ya munculin
                    // // tapih, kalo Dumpsternya juga belum kebuka, karna kalo kebuka gabole dimunculin
                    // if (!_interactionPromptUI.IsDisplayed && isDumpsterOpen == false) {
                    //     // nah jadi ini gue munculin
                    //     // karna dumpster belum kebuka, sama promptnya juga belom ada
                    //     _interactionPromptUI.SetUp(interactable.InteractionPrompt);
                    // }

                    // if (uiGo.GetComponent<Button>().clicked == true) {
                    //     interactable.Pickup();
                    // }
                    uiGo.GetComponent<Button>().onClick.RemoveAllListeners();
                    uiGo.GetComponent<Button>().onClick.AddListener(InteractClick);
                }
            }
    }

    private void InteractClick()
    {
        interactable.Pickup();
        uiGo.GetComponent<Button>().onClick.RemoveListener(InteractClick);
    }
}
