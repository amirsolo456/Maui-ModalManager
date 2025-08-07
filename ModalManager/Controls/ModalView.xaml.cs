namespace ModalManager.Controls;

public partial class ModalView : ContentView
{
    public event Action? OnClosed;
 

    public void RaiseClosed()
    {
        OnClosed?.Invoke();
    }
    public ModalView(View content)
    {
        BackgroundColor = Color.FromRgba(0, 0, 0, 0.5); // پس‌زمینه نیمه‌شفاف

        var frame = new Frame
        {
            Content = content,
            BackgroundColor = Colors.White,
            Padding = 10,
            HasShadow = false,
            VerticalOptions = LayoutOptions.Fill,
            HorizontalOptions = LayoutOptions.Fill
        };

        // تنظیم محتوا
        Content = new Grid
        {
            Children = { frame }
        };

        // بستن با کلیک روی بک‌گراند (اختیاری)
        var tapGesture = new TapGestureRecognizer();
        tapGesture.Tapped += (s, e) => OnClosed?.Invoke();
        this.GestureRecognizers.Add(tapGesture);
    }

    public void Close()
    {
        OnClosed?.Invoke();
    }
}