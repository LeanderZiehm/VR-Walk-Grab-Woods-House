using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    [SerializeField] AudioClip[] audioClips;
    private Stack<AudioSource> stack = new Stack<AudioSource>();
    private float globalVolume = 1;


    private void Awake()
    {
        instance = this;
    }

public void SetVolume(float volume){
    globalVolume = volume;
}

    public void PlaySound(Sound index,float volume = 1,float pitch = 1)
    {
        PlaySound((int)index,volume,pitch);
    }


    public void PlaySound(int index,float volume = 1,float pitch = -1)
    {
        AudioClip clip = audioClips[index];
        GameObject g;
        AudioSource aud;
        
        if (stack.Count == 0)
        {
            g = new GameObject();
            aud = g.AddComponent(typeof(AudioSource)) as AudioSource;
        }
        else
        {
            aud = stack.Pop();
            aud.gameObject.SetActive(true);
            g = aud.gameObject;
        }
        
        g.name = "[Sound:" + clip.name + "(" + index + ")]";
        float dRand = Random.Range(-0.10f,0.10f);
        g.transform.parent = transform;
        g.transform.position =  Camera.main.transform.position;
        aud.volume = globalVolume*(volume*0.2f+dRand*0.1f);
        if (pitch == -1)
        {
            aud.pitch += dRand;
        }
        else
        {
            aud.pitch = pitch;
        }
        
        aud.clip = clip;
        aud.Play();
        StartCoroutine(DisableSoundAfterPlayed(aud));
    }

    public IEnumerator DisableSoundAfterPlayed(AudioSource aud)
    {
        yield return new WaitForSeconds(aud.clip.length);
        aud.gameObject.SetActive(false);
        stack.Push(aud);
    }

}


public enum Sound
{
    key,door,grab,drop
}
