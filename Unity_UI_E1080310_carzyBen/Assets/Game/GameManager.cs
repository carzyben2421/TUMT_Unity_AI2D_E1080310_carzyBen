using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
   public AudioMixer mixer;

    public Text loadingText;
    public Slider loading;

    public void SetVBGM(float value)
    {
        mixer.SetFloat("VBGM", value);
    }
    public void SetVSFX(float value)
    {
        mixer.SetFloat("VSFX", value);
    }
    public void Play()
    {
      //eneManager.LoadScene("AK47");
        StartCoroutine(Loading());
    }

    private IEnumerator Loading()
    {
        //print("測試1");
        //yield return new WaitForSeconds(1);
        //print("測試2");

        AsyncOperation ao = SceneManager.LoadSceneAsync("遊戲場景");
        ao.allowSceneActivation = false;

        while (ao.isDone == false)
        {
            loadingText.text = ((ao.progress / 0.9f) * 100).ToString();
            loading.value = ao.progress / 0.9f;
            yield return new WaitForSeconds(0.0001f);

            if (ao.progress == 0.9f && Input.anyKey)
            {
                ao.allowSceneActivation = true;
            }

        }

    }

    public void Replay()
    {
        SceneManager.LoadScene("0209");
     }

    public void Quit()
    {
        Application.Quit();
    }
}
