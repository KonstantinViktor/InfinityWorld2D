using UnityEngine;

public class GeneratorWorld : MonoBehaviour
{
    [SerializeField] private ControlerPlatforms platforms;

    private void Start()
    {
        platforms.Creat(transform);
    }
}
