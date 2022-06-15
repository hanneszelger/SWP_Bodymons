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
        try
        {
            if (Maintracks)
            {
                //If Maintracks is enabled in the Options play the Tracks
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
                //if the last scene was not the menu and not the Mainscene it loads the positions from an List
                transform.position = SavedPositionManager.savedPositions[SavedPositionManager.lastScene];
            }
            else if (SavedPositionManager.lastScene == 5 && LookForESC.menuopened)
            {
                //Uses the last position to avoid spawning always at home
                transform.position = lastpo;
            }
        }
        catch (System.Exception ex)
        {
            Debug.Log(ex);
        }
    }

    void OnDestroy() // Unloading scene, so save position.
    {
        //Gets the last position and saves it to avoid always spawning at home
        SavedPositionManager.lastScene = SceneManager.GetActiveScene().buildIndex;
        lastSceneForMenu = SceneManager.GetActiveScene().buildIndex;
        //soundSource.Stop();
    }
    AudioClip RandomClip()
    {
        //Chooses a random audioclip of an array
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