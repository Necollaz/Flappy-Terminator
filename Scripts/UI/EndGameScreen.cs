using System;

public class EndGameScreen : Window
{
    public event Action RestartButtonClicked;

    public void OnRestartButtonClicked()
    {
        OnButtonClick();
    }

    public override void Open()
    {
        WindowGroup.alpha = 1f;
        ActionButton.interactable = true;
    }

    public override void Close()
    {
        WindowGroup.alpha = 0f;
        ActionButton.interactable = false;
    }

    protected override void OnButtonClick()
    {
        RestartButtonClicked?.Invoke();
    }
}
