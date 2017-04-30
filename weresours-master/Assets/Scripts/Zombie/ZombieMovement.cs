﻿using UnityEngine;
using System.Collections;

public class ZombieMovement : MonoBehaviour
{
    public AudioClip[] audioClips;
    public float timeBetweenSounds = 7f;

    Transform player;
    GameObject[] players;
    PlayerHealth playerHealth;
    ZombieHealth zombieHealth;
    UnityEngine.AI.NavMeshAgent nav;
    AudioSource audioSource;
    Animator animator;
    float timer;

    void Awake()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        zombieHealth = GetComponent<ZombieHealth>();
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();

        audioSource = GetComponent<AudioSource>();

        animator = GetComponentInChildren<Animator>();
        animator.SetFloat("Speed", 1f);

        timer = (float) 0.8 * timeBetweenSounds;
    }

    void Update()
    {
        GameObject closest;

        if (players.Length == 0 || zombieHealth.currentHealth <= 0)
        {
            nav.enabled = false;
        }
        else
        {
            closest = GetClosestPlayer();
            
            if (closest) nav.SetDestination(closest.transform.position);
            
            ZombieAudio();
        }
    }

    private void ZombieAudio()
    {
        timer += Time.deltaTime;
        if (timer >= timeBetweenSounds && Random.Range(0f, 1f) > 0.7)
        {
            timer = 0f;
            audioSource.clip = audioClips[Random.Range(0, audioClips.Length)];
            audioSource.Play();
        }
    }

    private GameObject GetClosestPlayer()
    {
        GameObject closest = null;
        float minDistance = Mathf.Infinity;
        Vector3 currentPosition = transform.position;

        foreach (GameObject player in players)
        {
            float distance = Vector3.Distance(player.transform.position, currentPosition);
            if (distance < minDistance && player.GetComponent<PlayerHealth>().currentHealth > 0)
            {
                closest = player;
                minDistance = distance;
            }
        }
        return closest;
    }
}

