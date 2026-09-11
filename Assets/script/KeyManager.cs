using UnityEngine;

public class KeyManager : MonoBehaviour
{
    public static KeyManager Instance;

    public int keysCollected = 0;

    void Awake()
    {
        Instance = this;
    }

    public void AddKey()
    {
        keysCollected++;

        Debug.Log("Key collected! Total: " + keysCollected);
    }
}