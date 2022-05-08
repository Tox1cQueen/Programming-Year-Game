using UnityEngine;

[CreateAssetMenu(fileName = "PlayerScriptableObject", menuName = "ScriptableObjects/PlayerScriptableObject", order = 1)]

public class PlayerScriptableObject : ScriptableObject
{
    public float turning = 0.1f;
    public float speed = 15f;
}

