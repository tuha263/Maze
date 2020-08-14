using Controllers;
using strange.extensions.mediation.impl;
using UnityEngine.Events;

namespace UI
{
    public class MainUIMediator : EventMediator
    {
        [Inject] public MainUIView view { get; set; }
        [Inject] public CreateMazeSignal createMazeSignal { get; set; }

        public override void OnRegister()
        {
            SetSizeText(view.mazeSizeSlider.value);
            view.generateMazeButton.onClick.AddListener(
                () => createMazeSignal.Dispatch((int) view.mazeSizeSlider.value));
            view.mazeSizeSlider.onValueChanged.AddListener(SetSizeText);
        }

        private void SetSizeText(float arg0)
        {
            view.sizeText.text = ((int) arg0).ToString();
        }

    }
}