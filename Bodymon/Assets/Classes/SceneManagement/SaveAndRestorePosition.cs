using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveAndRestorePosition : MonoBehaviour
{
    private bool Maintracks = Menu.MainTracks;
    public AudioSource soundSource;
    void Start() // Check if we've saved a position for this scene; if so, go there.
    {
        if (Maintracks)
        {
            soundSource.Play();
        }
        else
        {
            soundSource.Stop();
        }

        if (SavedPositionManager.lastScene != 0)
        {
            transform.position = SavedPositionManager.savedPositions[SavedPositionManager.lastScene];
        }
    }

    void OnDestroy() // Unloading scene, so save position.
    {
        SavedPositionManager.lastScene = SceneManager.GetActiveScene().buildIndex;
        DontDestroyOnLoad(soundSource);
    }
}