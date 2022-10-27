using UnityEngine;
using System.Collections;

public class PlayerTriggerControler : MonoBehaviour
{
    [SerializeField] private GameObject PanelFinish;
    [SerializeField] private GameObject PanelGameOver;
    [SerializeField] private float upForseJump;

    [SerializeField] private Vector2 spawnPoint;

    [SerializeField] private int limitLive = 5;
    private int idLive = 0;

    private Rigidbody2D rd;
    private MenuControler menu;
    private Animator anim;

    private void Start()
    {
        rd = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        menu = FindObjectOfType<MenuControler>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("MoveUp"))
        {
            anim.SetTrigger("IsJump");
            rd.AddForce(Vector2.up * upForseJump, ForceMode2D.Impulse);
        }

        if (other.CompareTag("Kill"))
        {
            idLive++;
            rd.velocity = Vector2.zero;
            transform.position = spawnPoint;

            if (idLive >= limitLive)
            {
                StartCoroutine(SceneFinish(PanelGameOver));
            }
        }

        if (other.CompareTag("SpawnPoint"))
        {
            spawnPoint = transform.position;
        }

        if (other.CompareTag("Finish"))
        {
            StartCoroutine(SceneFinish(PanelFinish));
        }
    }

    private IEnumerator SceneFinish(GameObject obj)
    {
        obj.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        menu.SetScene(0);
    }
}