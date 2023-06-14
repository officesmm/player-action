using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public List<Action> actionList = new List<Action>();
    public List<Item> inventory = new List<Item>(); // Player's inventory

    public Animator anim;
    private bool isActionCooldown = false; // Flag indicating if an action is on cooldown


    private void Update() {
        // Check if any action key is pressed
        for (int i = 0; i < actionList.Count; i++) {
            if (Input.GetKeyDown(actionList[i].actionKey)) {
                // Trigger the action if it's not on cooldown
                if (!isActionCooldown) {
                    TriggerAction(actionList[i]);
                }
                break; // Exit the loop after the first key press
            }
        }
    }

    private void TriggerAction(Action action) {
        Debug.Log("Performing action: " + action.actionName);
        // Play animation and perform action logic here

        // Start cooldown
        StartCoroutine(ActionCooldown(action.cooldownDuration));
    }

    private System.Collections.IEnumerator ActionCooldown(float cooldownDuration) {
        isActionCooldown = true;
        anim.SetTrigger("Attack");
        yield return new WaitForSeconds(cooldownDuration);
        isActionCooldown = false;
    }

    public void SortInventory() {
        // Sort items based on the associated action's cooldown duration
        inventory.Sort((a, b) => a.associatedAction.cooldownDuration.CompareTo(b.associatedAction.cooldownDuration));
    }

    public void ChangeActionKey(Action action, KeyCode newKey) {
        action.actionKey = newKey;
    }
}
