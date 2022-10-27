using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform[] posMovePoint;

    private int id = 0;

    private Transform pos;

    private Vector3 newPos => posMovePoint[id].position;

    private void Start()
    {
        id = 0;
        pos = GetComponent<Transform>();
    }

    private void Update()
    {
        if (pos.position == newPos)
        {
            id++;
            if (id >= posMovePoint.Length) { id = 0; }
        }

        pos.position = Vector2.MoveTowards(pos.position, newPos, speed * Time.deltaTime);
    }
}