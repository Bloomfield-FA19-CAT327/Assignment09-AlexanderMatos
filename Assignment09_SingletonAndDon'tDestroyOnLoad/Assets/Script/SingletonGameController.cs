using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SingletonGameController : MonoBehaviour
{
    Text hudText;

    public int score;
    public float timeInGame;
    public int currentLevel;

    private static SingletonGameController instance = null;
    public static SingletonGameController Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<SingletonGameController>();
                if(instance == null)
                {
                    GameObject go = new GameObject();
                    go.name = "SimpleSingleton";
                    instance = go.AddComponent<SingletonGameController>();
                    DontDestroyOnLoad(go);
                }
            }
            return instance;
        }
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        hudText = GameObject.Find("HUDText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        string hudInfo = "";

        timeInGame += Time.deltaTime;

        hudInfo += "Level: " + (currentLevel + 1) + "\n";
        hudInfo += "Score: " + score + "\n";
        hudInfo += "Time: " + timeInGame.ToString("F2");

        hudText.text = hudInfo;
    }

    public void NextLevel()
    {
        currentLevel = SceneManager.GetActiveScene().buildIndex + 1;
        LoadLevel();
    }

    public void PreviousLevel()
    {
        currentLevel = SceneManager.GetActiveScene().buildIndex - 1;
        LoadLevel();
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(currentLevel);
    }
}
