using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Knight", menuName = "Knight")]
public class Knight : ScriptableObject {

    public new string name;
    public string description;
    public int armorIndex;

    public GameObject knight;

    public int healt;
	
}
