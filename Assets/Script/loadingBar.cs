using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class loadingBar : MonoBehaviour
{

    public GameObject loadBar;
    public GameObject gin;
    public Text loadText;

    private Vector3 macaPos;
    private float macaMove;

    // Start is called before the first frame update
    void Start()
    {
        macaPos= new Vector3(225, 320, 20);
        macaMove = 102f;
        loadBar.transform.localScale = new Vector3(1, 1, 1);
        loadBar.GetComponent<RectTransform>().sizeDelta=new Vector2(99 ,22f);
        StartCoroutine(DisplayLoadingScreen(3));
    }

    private IEnumerator DisplayLoadingScreen(int screenNum){
        int progress = 0;
        int displayProgress = 0;

        AsyncOperation async = SceneManager.LoadSceneAsync(screenNum);
        async.allowSceneActivation = false;
        while(async.progress < 0.9f){
            progress = (int)async.progress * 100;
            while(displayProgress < progress){
                displayProgress++;
                setLoading(displayProgress);
                yield return new WaitForEndOfFrame();
            }
        }
        progress = 100;
        while(displayProgress < progress){
            displayProgress++;
            setLoading(displayProgress);
            yield return new WaitForEndOfFrame();
        }
        async.allowSceneActivation = true;
    }

    private void setLoading(float precent){
        loadBar.transform.localScale = new Vector3((precent * 0.0531f), 1, 1);
        loadText.text = precent.ToString() + "%";
        //gin.transform.position = new Vector3(macaPos.x, macaPos.y, macaPos.z);
        gin.transform.position = new Vector3((macaPos.x + (macaMove * precent * 0.0531f)), macaPos.y, macaPos.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
