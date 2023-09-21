using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusic : MonoBehaviour
{
    public void Play(string name) => AudioManager.instance.Play(name);
}
