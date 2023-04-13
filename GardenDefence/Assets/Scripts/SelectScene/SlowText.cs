using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlowText : MonoBehaviour
{
    public Text display;
    public string text;
    private string currentText = "";
    public float waitTime;

    public GameObject button;
    public GameObject skipButton;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Count());
        skipButton.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SkipText()
    {
        skipButton.SetActive(false);
        waitTime = 0f;
    }

    private IEnumerator Count()
    {
        for (int i = 0; i < text.Length; i++)
        {
            currentText = text.Substring(0, i);
            display.text = currentText;
            if (i == text.Length - 1)
            {
                button.SetActive(true);
            }
            yield return new WaitForSeconds(waitTime);
        }
    }
}
