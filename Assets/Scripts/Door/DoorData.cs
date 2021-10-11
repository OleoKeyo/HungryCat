using System;
using UnityEngine;

[Serializable]
public class DoorData
{
    public ElementType rightElementForOpen;
    public Sprite sprite;
    public AudioClip successSound;
    public AudioClip failSound;
}
