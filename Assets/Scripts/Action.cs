using UnityEngine;

public class Action {
    public string actionName; // Name of the action, e.g., "Knife", "Sword", etc.
    public KeyCode actionKey; // Keycode used to trigger the action
    public float cooldownDuration; // Cooldown duration in seconds
    public bool isOnCooldown; // Flag indicating if the action is on cooldown

    public Action(string name, KeyCode key, float cooldown) {
        actionName = name;
        actionKey = key;
        cooldownDuration = cooldown;
        isOnCooldown = false;
    }
}

