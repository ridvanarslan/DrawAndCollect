using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXManager : MonoBehaviour
{
    [SerializeField] private ParticleSystem scoreParticle;
    [SerializeField] private ParticleSystem bestScoreParticle;

    public ParticleSystem ScoreParticle => scoreParticle;
    public ParticleSystem BestScoreParticle => bestScoreParticle;
}
