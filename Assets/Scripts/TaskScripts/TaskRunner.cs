using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class TaskRunner : MonoBehaviour
{
    public Slider slider;
    public GameObject canvas;
    private ITask currentTask;

    public enum TaskType { ScalpelTask, SewTask }
    public TaskType taskType;
    public UnityEvent onStartTask;
    public UnityEvent onEndTask;

    private void OnEnable()
    {
        switch (taskType)
        {
            case TaskType.ScalpelTask:
                currentTask = new SliderTask(slider, canvas, onStartTask, onEndTask);
                break;
            case TaskType.SewTask:
                currentTask = new SewTask(canvas, onStartTask, onEndTask);
                break;
        }
    }
    
    public void StartTask()
    {
        currentTask?.BeginTask();
    }

    public void EndTask()
    {
        currentTask?.EndTask();
    }
}
