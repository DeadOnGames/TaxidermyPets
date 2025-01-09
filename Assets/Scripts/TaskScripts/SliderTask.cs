using UnityEngine;
using UnityEngine.UI;

public class SliderTask : BaseTask
{
    private Slider slider;

    public SliderTask(Slider slider, GameObject canvas) : base(canvas)
    {
        this.slider = slider;
    }

    public override void BeginTask()
    {
        base.BeginTask();
        slider.value = 0; 
        slider.onValueChanged.AddListener(OnSliderValueChanged);
    }

    public override void EndTask()
    {
        slider.onValueChanged.RemoveListener(OnSliderValueChanged); 
        base.EndTask();
    }

    private void OnSliderValueChanged(float value)
    {
        if (value >= slider.maxValue) EndTask();
    }
}
