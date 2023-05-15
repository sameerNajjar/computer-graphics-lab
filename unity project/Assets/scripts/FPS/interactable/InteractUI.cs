using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using TMPro;
public class InteractUI : MonoBehaviour
{
    [SerializeField] private GameObject uiContaiter;
    [SerializeField] protected PlayerInteract playerinteract;
    [SerializeField] protected TextMeshProUGUI interactText;

    private void Update() {
        if (playerinteract.getInteractObj() != null) {
            show(playerinteract.getInteractObj());
        }
        else {
            hide();
        }
    }
    private void show(Interact interactabale) {
         uiContaiter.SetActive(true);
        interactText.SetText(interactabale.getinteractText());
    }
    private void hide() {
        uiContaiter.SetActive(false);

    }
}
