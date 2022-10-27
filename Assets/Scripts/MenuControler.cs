using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuControler : MonoBehaviour
{
    [SerializeField] AudioControler audio;

    [SerializeField] private Text source;

    private void Start()
    {
        if (source != null)
        {
            if (!audio.isActive)
                source.text = audio.SetStateAudio(false, "Audion off");
            else
                source.text = audio.SetStateAudio(true, "Audion on");
        }
    }

    public void SetAudioState()
    {
        if (audio.isActive)
            source.text = audio.SetStateAudio(false, "Audion off");
        else
            source.text = audio.SetStateAudio(true, "Audion on");
    }
    public void SetScene(int id)
    {
        SceneManager.LoadScene(id);
    }
    public void Esit()
    {
        Application.Quit();
    }
}
