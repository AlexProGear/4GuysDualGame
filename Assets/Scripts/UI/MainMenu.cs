using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class MainMenu : UIWindow
    {
        [SerializeField] private Button play;
        [SerializeField] private Button settings;
        [SerializeField] private Button exit;
        [SerializeField] private string level1Name;
        [SerializeField] private string settingsSceneName;
        [SerializeField] private GameObject backgroundMusic;

        [SerializeField] private PlayModeMenu playModeMenu;

        private void Start()
        {
            play.onClick.AddListener(() => OpenMenu(playModeMenu, 0.1f));
            settings.onClick.AddListener(OpenSettings);
            exit.onClick.AddListener(Exit);
            DontDestroyOnLoad(backgroundMusic);
            GameObject[] musics = GameObject.FindGameObjectsWithTag("BackgroundMusic");
            if (musics.Length > 1)
            {
                foreach (var music in musics)
                {
                    if (music == backgroundMusic)
                        Destroy(music);
                }
            }
        }

        private void OpenSettings()
        {
            SceneManager.LoadScene(settingsSceneName);
        }

        private void Exit()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}