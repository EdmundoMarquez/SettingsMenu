using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace Fragsoft.Settings
{
    public class SoundSettings : MonoBehaviour
    {
        [SerializeField] private AudioMixer _audioMixer = null;
        [SerializeField] private Slider[] _sliders;
        private float[] _volumes = new float[4];
        public int MasterVol => (int)_volumes[0];
        public int MusicVol => (int)_volumes[1];
        public int SfxVol => (int)_volumes[2];
        public int AmbientVol => (int)_volumes[3];

        public void Init(float masterVol, float musicVol, float sfxVol, float ambientVol)
        {
            _volumes[0] = masterVol;
            _volumes[1] = musicVol;
            _volumes[2] = sfxVol;
            _volumes[3] = ambientVol;

            SetMasterVol(_volumes[0]);
            SetMusicVol(_volumes[1]);
            SetSfxVol(_volumes[2]);
            SetAmbientVol(_volumes[3]);

            SetSoundSliders();
        }

        public void SetMasterVol(float volume)
        {
            _volumes[0] = volume;
            _audioMixer.SetFloat("master_vol", volume);
        }

        public void SetMusicVol(float volume)
        {
            _volumes[1] = volume;
            _audioMixer.SetFloat("music_vol", volume);
        }

        public void SetSfxVol(float volume)
        {
            _volumes[2] = volume;
            _audioMixer.SetFloat("sfx_vol", volume);
        }

        public void SetAmbientVol(float volume)
        {
            _volumes[3] = volume;
            _audioMixer.SetFloat("ambient_vol", volume);
        }

        private void SetSoundSliders()
        {
            for (int i = 0; i < _sliders.Length; i++)
            {
                _sliders[i].SetValueWithoutNotify(_volumes[i]);
            }
        }
    }    
}