using UnityEngine;

[CreateAssetMenu()]
public class AudioControler : ScriptableObject
{
    private bool isActiv = true;

    public bool isActive => isActiv;

    private void OnEnable()
    {
        isActiv = false;
    }

    public string SetStateAudio(bool isActive, string str)
    {
        isActiv = isActive;
        AudioListener.pause = isActive;
        return str;
    }
}