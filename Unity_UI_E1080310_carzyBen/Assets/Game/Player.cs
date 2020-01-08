using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int hp = 100;
    public Slider hpslider;

    public Text textCOIN;
    public int COINCount;
    public int COINTotal;

    public Text textTime;
    public float gameTime;

    public GameObject final;
    public Text textBest;
    public Text textCurrent;

    private void OnTriggerEnter(Collider other)
    {
       if (other.tag == "陷阱")
        {
            int d = other.GetComponent<Trap>().damage;
            hp -= d;
            hpslider.value = hp;
            if (hp <= 0) Dead();
        }

        if (other.tag == "COIN")
        {
            COINCount++;
            textCOIN.text = "COIN : " + COINCount + " / " + COINTotal;
            Destroy(other.gameObject);
        }

        if (other.name =="終點" && COINCount == COINTotal)
        {
           GameOver();
        }
    }
    private void OnParticleCollision(GameObject other)
    {
        if (other.tag == "陷阱")
        {
            int d = other.GetComponent<Trap>().damage;
            hp -= d;
            hpslider.value = hp;
            if (hp <= 0) Dead();

        }
    }

    private void Start()
    {
        if (PlayerPrefs.GetFloat("最佳紀錄") == 0)
        {
            PlayerPrefs.SetFloat("最佳紀錄", 99999);
        }
        COINTotal = GameObject.FindGameObjectsWithTag("COIN").Length;
        textCOIN.text = "COIN : 0/" + COINTotal;
    }

    private void Update()
    {
        UpdateTime();
    }

    private void UpdateTime()
    {
        gameTime += Time.deltaTime;
        textTime.text = gameTime.ToString("F2");
    }

    private void Dead()
    {
        final.SetActive(true);
        textCurrent.text = "TIME : " + gameTime.ToString("F2");
        textBest.text = "BEST : " + PlayerPrefs.GetFloat("最佳紀錄").ToString("F2");
        Cursor.lockState = CursorLockMode.None;

        //<FPSControllerLPFP.FpsControllerLPFP>().enabled = false;
        enabled = false;
    }

    private void GameOver()
    {
        final.SetActive(true);
        textCurrent.text = "TIME : " + gameTime.ToString("F2");

        if(gameTime < PlayerPrefs.GetFloat("最佳紀錄"))
        {
            PlayerPrefs.SetFloat("最佳紀錄", gameTime);
        }

        textBest.text = "BEST : " + PlayerPrefs.GetFloat("最佳紀錄").ToString("F2");

        Cursor.lockState = CursorLockMode.None;

    }
}
