using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CustomisedCharacter : ScriptableObject
{
    [field: SerializeField]
    public List<CustomisationData> CustomisationData {  get; private set; }
}
