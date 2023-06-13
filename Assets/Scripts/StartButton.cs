using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class StartButton : MonoBehaviour
{
    [SerializeField]
    private GameObject startButton;

    private void Start()
{
    startButton.GetComponent<Button>().onClick.AddListener(loadGameScene); 
}

public void loadGameScene()
{
     SceneManager.LoadScene("GameScene");
    
}

}
