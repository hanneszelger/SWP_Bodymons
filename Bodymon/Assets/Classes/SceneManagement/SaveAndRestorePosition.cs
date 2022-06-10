using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveAndRestorePosition : MonoBehaviour
{
    private bool Maintracks = Menu.MainTracks;
    public AudioSource soundSource;
    public AudioClip[] audioClipArray;
    private bool resume = false;
    AudioClip lastClip;
    Vector3 lastpo = LookForESC.Vector3;
    public static int lastSceneForMenu;
    
    void Start() // Check if we've saved a position for this scene; if so, go there.
    {
        if (Maintracks)
        {
            if (SceneManager.GetActiveScene().buildIndex == 0)
            {
                soundSource.PlayOneShot(RandomClip());
            }
            soundSource.Play();
        }
        else
        {
            soundSource.Stop();
        }

        if (SavedPositionManager.lastScene != 5 && SavedPositionManager.lastScene != 0)
        {
            transform.position = SavedPositionManager.savedPositions[SavedPositionManager.lastScene];
        }
        else if (SavedPositionManager.lastScene == 5 && LookForESC.menuopened)
        {
            transform.position = lastpo;
        }
    }

    void OnDestroy() // Unloading scene, so save position.
    {
        
        SavedPositionManager.lastScene = SceneManager.GetActiveScene().buildIndex;
        lastSceneForMenu = SceneManager.GetActiveScene().buildIndex;
        //soundSource.Stop();
    }
    AudioClip RandomClip()
    {
        resume = true;
        int attempts = 3;
        AudioClip newClip = audioClipArray[Random.Range(0, audioClipArray.Length)];
        while (newClip == lastClip && attempts > 0)
        {
            newClip = audioClipArray[Random.Range(0, audioClipArray.Length)];
            attempts--;
        }
        lastClip = newClip;
        return newClip;
    }
}