using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public interface ITask
{
    void BeginTask();
    void EndTask();
}
