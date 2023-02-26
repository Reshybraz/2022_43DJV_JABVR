using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Party : MonoBehaviour
{

    public float time;
    public float finalTime;
    public int nbDestroy;
    public GameObject UI;
    public GameObject finalUI;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI finalTimeText;
    public GameObject rayLC, rayRC, directLC, directRC;
    private bool finish;

    // Start is called before the first frame update
    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (finish)
        {
            finalTimeText.text = "temps final : " + finalTime;
        }
        else
        {
            timeText.text = "temps : " + time;
            if (nbDestroy >= 5)
            {
                finish = true;
                finalTime = time;
                UI.SetActive(false);
                finalUI.SetActive(true);
                rayLC.SetActive(true);
                rayRC.SetActive(true);
                directLC.SetActive(false);
                directRC.SetActive(false);
            }
        }
    }

    public void reload()
    {
        SceneManager.LoadScene(0);
    }
}
