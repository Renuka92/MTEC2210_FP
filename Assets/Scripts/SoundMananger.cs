using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMananger : MonoBehaviour
{
    public GameManager gameManager;

    readonly int maxAudioSources = 30;

    AudioSource[] sources;

    public AudioSource sourcePrefab;

    public AudioClip[] enemyMoveClips;
    int lastEnemy;

    public AudioClip[] UFOMoveClips;
    int lastUFO;

    public AudioClip explosionClip;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        sources = new AudioSource[maxAudioSources];

        for (int i=0; i < maxAudioSources; i++) {
            sources[i] = Instantiate(sourcePrefab, transform);
        }
    }

    public void PlaySoundAtPosition(Vector2 pos, int typeIndex)
    {
        if (!gameManager.enableAudio) return;

        AudioSource source = GetSource();

        if (typeIndex == 1)
        {
            int clipNum = GetClipIndex(enemyMoveClips.Length, lastEnemy);
            lastEnemy = clipNum;
            source.clip = enemyMoveClips[clipNum];
            source.volume = 0.5f;
        }
        else if (typeIndex == 2)
        {
            int clipNum = GetClipIndex(UFOMoveClips.Length, lastUFO);
            lastUFO = clipNum;
            source.clip = UFOMoveClips[clipNum];
        }
        else
        {
            source.clip = explosionClip;
        }

        source.pitch = Random.Range(0.75f, 1.25f);
        source.transform.position = pos;

        source.Play();
    }

    int GetClipIndex(int clipNum, int lastPlayed)
    {
        int num = Random.Range(0, clipNum);
        while (num == lastPlayed)
        {
            num = Random.Range(0, clipNum);
        }
        return num;
    }

    AudioSource GetSource()
    {
        for (int i=0; i < maxAudioSources; i++)
        {
            if (!sources[i].isPlaying)
            {
                return sources[i];
            }
        }

        Debug.Log("NOT ENOUGH SOURCES");
        return sources[0];
    }
}
