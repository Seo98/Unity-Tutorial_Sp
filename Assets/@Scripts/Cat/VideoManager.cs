using UnityEngine;
using UnityEngine.Video;

namespace Cat
{
    public class VideoManager : MonoBehaviour
    {
        public GameObject videoPanel;

        public VideoPlayer vPlayer;
        public VideoClip[] vClip;

        private void Start()
        {
            vPlayer = GetComponent<VideoPlayer>();
        }


        public void VideoPlay(bool isHappy)
        {
            videoPanel.SetActive(true);

            var clip = isHappy ? vClip[0] : vClip[1];
            vPlayer.clip = clip;
            vPlayer.Play();
        }
    }
}