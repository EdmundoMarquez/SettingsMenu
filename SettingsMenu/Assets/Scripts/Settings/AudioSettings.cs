using UnityEngine;
using UnityEngine.Audio;

namespace Fragsoft.Settings
{
    public class AudioSettings : MonoBehaviour
    {
        [SerializeField] private AudioMixer _audioMixer = null;

        public void SetMasterVol(float volume)
        {
            _audioMixer.SetFloat("master_vol", volume);
            Debug.Log("Changed value");
        }

        public void SetMusicVol(float volume)
        {
            _audioMixer.SetFloat("music_vol", volume);
        }

        public void SetSfxVol(float volume)
        {
            _audioMixer.SetFloat("sfx_vol", volume);
        }

        public void SetAmbientVol(float volume)
        {
            _audioMixer.SetFloat("ambient_vol", volume);
        }
    }    
}