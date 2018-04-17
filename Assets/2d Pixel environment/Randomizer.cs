using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Randomizer : MonoBehaviour {

    public SpriteRenderer SpriteToRandom;
    public Sprite[] _SpriteImage;

    void Start()
    {
        SpriteToRandom = GetComponent<SpriteRenderer>();
        Randomize();
    }

    public void Randomize()
    {
        SpriteToRandom.sprite = _SpriteImage[Random.Range(0, _SpriteImage.Length)];
    }
}