using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Next : MonoBehaviour
{
    [SerializeField] private GameObject Tomato;
    [SerializeField] private GameObject Cheese;
    [SerializeField] private GameObject Niku;
    [SerializeField] private GameObject Kyabetu;
    [SerializeField] private GameObject Buns1;
    [SerializeField] private GameObject Buns2;
    [SerializeField] private GameObject cloud;
    [SerializeField] private TextMeshProUGUI textMeshProUGUI;
    private int Syokuzai = 0;
    private float X = 0;

    private bool Go = false;
    private bool Went = false;
    private int Count = 0;
    private bool Lock = false;
    private bool Result = false;
    private bool Out = false;

    public bool GO
    {
        get { return Go; }
        set { Go = value; }
    }

    public bool WENT
    {
        get { return Went; }
        set { Went = value; }
    }

    public bool OUT
    {
        get { return Out; }
        set { Out = value; }
    }
    public bool RESULT
    {
        get { return Result; }
        set { Result = value; }
    }

    public int COUNT
    {
        get { return Count; }
        set { Count = value; }
    }
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(Buns1, transform.position = new Vector3(0, 7, 0), Quaternion.identity);
        StartCoroutine("Cloudy");
    }

    // Update is called once per frame
    void Update()
    {
        if (Go)
        {
            Syokuzai = Random.Range(1, 5);
            X = Random.Range(-4.0f, 4.001f);
            switch(Syokuzai)
            {
                case 1:
                    Instantiate(Tomato, transform.position = new Vector3(X, 7, 0), Quaternion.identity);
                    break;

                case 2:
                    Instantiate(Cheese, transform.position = new Vector3(X, 7, 0), Quaternion.identity);
                    break;

                case 3:
                    Instantiate(Niku, transform.position = new Vector3(X, 7, 0), Quaternion.identity);
                    break;

                case 4:
                    Instantiate(Kyabetu, transform.position = new Vector3(X, 7, 0), Quaternion.identity);
                    break;

                default:
                    break;
            }
            Go = false;
        }

        if (Went && !Lock)
        {
            Instantiate(Buns2, transform.position = new Vector3(X, 7, 0), Quaternion.identity);
            Lock = true;
        }
        if (Out)
        {
            Invoke("Kekka", 0.01f);
        }

        if (Result)
        {
            Invoke("Kekka", 1);
        }
    }

    void Kekka()
    {

        if (Out)
        {
            textMeshProUGUI.text = "GAME OVER";
        }
        else
        {
        if (Count == 0)
        {
            textMeshProUGUI.text = "バンズだけじゃねーか！";
        }

        if (Count > 0 && Count <= 2)
        {
            textMeshProUGUI.text = "もっと乗せよう";
        }

        if (Count > 2 && Count <= 5)
        {
            textMeshProUGUI.text = "ちょっぴり乗せられてる";
        }

        if (Count > 5 && Count <= 8)
        {
            textMeshProUGUI.text = "そこそこいい感じ";
        }

        if (Count > 8 && Count <= 11)
        {
            textMeshProUGUI.text = "かなりでかくなったなー！";
        }

        if (Count > 11)
        {
            textMeshProUGUI.text = "完璧だ";
        }
        }

    }
    IEnumerator Cloudy()
    {
        for(int i = 0; i <= 5; i++)
        {
            Instantiate(cloud);
            yield return new WaitForSeconds(1);            
        }

    }
}
