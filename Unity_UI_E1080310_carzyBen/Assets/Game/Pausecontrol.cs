using UnityEngine;
using UnityEngine.UI;

public class Pausecontrol : MonoBehaviour
{
    [Header("暫停介面")]
    public Image imagePause;
    public Sprite spritPause, spritePlay;
    [Header("暫停")]
    public bool pause;

    private void Pause()
    {
        if (Input.GetKeyDown(KeyCode.CapsLock))
        { 
            print("暫停");
            pause = !pause;

            imagePause.sprite = pause ? spritePlay : spritPause;
            Time.timeScale = pause ? 0 : 1;
        }
    }

    private void Update()
    {
        Pause();
    }
}


