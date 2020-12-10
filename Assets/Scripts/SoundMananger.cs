using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMananger : MonoBehaviour
{
    public GameManager gameManager;

    readonly int maxAudioSources = 30;

    AudioSource[] sources;

    public AudioSource sourcePrefab;

    //public AudioClip[] enemyMoveClips;
    //int lastEnemy;

    //public AudioClip[] UFOMoveClips;
    //int lastUFO;

    public AudioClip UFOMoveLowClip;
    public AudioClip UFOMoveHighClip;
    public AudioClip explosionClip;
    public AudioClip shootClip;
    public AudioClip invaderKilledClip;
    public AudioClip enemyMove1;
    public AudioClip enemyMove2;
    public AudioClip enemyMove3;
    public AudioClip enemyMove4;

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
            //int clipNum = GetClipIndex(enemyMoveClips.Length, lastEnemy);
            //lastEnemy = clipNum;
            //source.clip = enemyMoveClips[clipNum];
            //source.volume = 0.5f;
            source.clip = UFOMoveLowClip;
        }
        else if (typeIndex == 2)
        {
            //int clipNum = GetClipIndex(UFOMoveClips.Length, lastUFO);
            //lastUFO = clipNum;
            source.clip = UFOMoveHighClip;
        }
        else if (typeIndex == 3)
        {
            source.clip = explosionClip;
        }
        else if (typeIndex == 4)
        {
            source.clip = shootClip;
        }
        else if (typeIndex == 5)
        {
            source.clip = invaderKilledClip;
        }
        else if (typeIndex == 6)
        {
            source.clip = enemyMove1;
        }
        else if (typeIndex == 7)
        {
            source.clip = enemyMove2;
        }
        else if (typeIndex == 8)
        {
            source.clip = enemyMove3;
        }
        else if (typeIndex == 9)
        {
            source.clip = enemyMove4;
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
