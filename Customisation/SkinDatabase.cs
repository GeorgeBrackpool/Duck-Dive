using System.Collections;
using System.Collections.Generic;
using System.IO.Enumeration;
using UnityEngine;

[CreateAssetMenu(fileName = "Skins", menuName = "ScriptableObjects/SkinSelector")]
public class SkinDatabase : ScriptableObject
{
    public string NameOfSkin;
    public Sprite PlayerSkin;
    
}
