using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{
    public Button button;
    public string sceneName;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(LoadThisScene);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadThisScene()
    {
        SceneManager.LoadScene(sceneName);
    }
    
}
