using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class home : MonoBehaviour
{

    VideoPlayer video;

    void Awake()
    {
        //Starts the Video when the player enters home
        video = GetComponent<VideoPlayer>();
        video.Play();
        //Checks when the video is over
        video.loopPointReached += CheckOver;


    }


    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        //Changes the Scene when the video ends to mainscene
        SceneManager.LoadScene(0);
    }
}