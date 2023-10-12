using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject notInplementedText;
    private float currentTime = 0;

    void Start()
    {
        if (notInplementedText != null)
            notInplementedText.SetActive(false);
    }

    void Update()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            if (currentTime < 0)
            {
                notInplementedText.SetActive(false);
            }
        }
    }

    public void ShowNotInplementedText()
    {
        notInplementedText.SetActive(true);
        currentTime = 3;
    }

    public void LoadScene(int index)
    {
        SceneManager.Instance.LoadScene(index);
    }
}
