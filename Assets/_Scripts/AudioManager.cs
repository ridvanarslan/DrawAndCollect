using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource scoreSound;
    [SerializeField] private AudioSource gameOverSound;
    [SerializeField] private AudioSource gameSound;
    public AudioSource ScoreSound => scoreSound;
    public AudioSource GameOverSound => gameOverSound;
    public AudioSource GameSound => gameSound;
}
