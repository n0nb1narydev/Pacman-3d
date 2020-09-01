using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{  
    [SerializeField]
    private Text _readyText;
    [SerializeField]
    private Text _scoreText;
    [SerializeField]
    public int currentScore;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ReadyTextOff());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator ReadyTextOff()
    {
        yield return new WaitForSeconds(4.2f);
        _readyText.gameObject.SetActive(false);
    }
    public void UpdateScore(int currentScore)
    {
        _scoreText.text = "Score: " + currentScore;
    }
}
