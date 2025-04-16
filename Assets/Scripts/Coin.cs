using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private ParticleSystem _coinCollectedEffect;

    private void OnTriggerEnter(Collider other)
    {
        Ball ball = other.GetComponent<Ball>();

        if (ball != null)
        {
            ball.AddCoin();

            _coinCollectedEffect.transform.position = transform.position;
            _coinCollectedEffect.Play();

            gameObject.SetActive(false);
        }
    }
}
