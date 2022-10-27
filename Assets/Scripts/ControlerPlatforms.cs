using UnityEngine;

[CreateAssetMenu()]
public class ControlerPlatforms : ScriptableObject
{
    [SerializeField] public GameObject[] platforms;
    [SerializeField] public GameObject platformFinish;
    [SerializeField] public int maxPlatform;

    private int id;

    private void OnEnable()
    {
        id = 0;
    }

    public void Creat(Transform pos)
    {
        id++;

        if (id <= maxPlatform)
        {
            Instantiate(platforms[Random.Range(0, platforms.Length)], pos.position, Quaternion.identity);
        }
        else if (id > maxPlatform)
        {
            Instantiate(platformFinish, pos.position, Quaternion.identity);
        }
    }
}