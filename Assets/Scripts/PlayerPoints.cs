using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerPoints : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    AudioSource _audio;

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
        _text.text = "Skor: " + score.totalScore.ToString();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("elmas"))
        {
            _audio.Play();
            Destroy(collision.gameObject);
            score.totalScore++;
            _text.text = "Skor: "+score.totalScore.ToString();
        }
    }
}
