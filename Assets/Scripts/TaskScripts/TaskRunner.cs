using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TaskRunner : MonoBehaviour
{
    public Slider slider;
    public GameObject canvas;
    private ITask currentTask;

    public enum TaskType { ScalpelTask, SimpleTask }
    public TaskType taskType;

    private void OnEnable()
    {
        switch (taskType)
        {
            case TaskType.ScalpelTask:
                currentTask = new SliderTask(slider, canvas);
                break;
        }
    }

    public void StartTask()
    {
        currentTask?.BeginTask();
    }

    private void OnDisable()
    {
        currentTask?.EndTask();
    }
}
