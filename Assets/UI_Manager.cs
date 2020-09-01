using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{  
    [SerializeField]
        private Text _readyText;

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
}
