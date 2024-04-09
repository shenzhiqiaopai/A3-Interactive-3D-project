using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public AudioSource backgroundMusic;

    private bool isPlaying = true;

    public void ToggleMusic()
    {
        if (isPlaying)
        {
            // 如果音乐正在播放，则暂停音乐
            backgroundMusic.Pause();
        }
        else
        {
            // 如果音乐没有播放，则播放音乐
            backgroundMusic.Play();
        }

        // 切换播放状态
        isPlaying = !isPlaying;
    }
}
