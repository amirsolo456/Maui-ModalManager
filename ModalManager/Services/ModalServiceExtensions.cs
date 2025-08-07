using ModalManager.Controls;
using ModalManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModalManager.Services
{
    public static class ModalServiceExtensions
    {
        public static void ShowModalWithContent(this IModalService modalService, View content)
        {
            var modalView = new ModalView(content);
            // اینجا می‌تونیم به OnClosed رویداد وصل کنیم اگر لازم بود
            modalView.OnClosed += () => modalService.CloseCurrent();

            modalService.Show(modalView);
        }

        public static void ShowCenteredLabel(this IModalService modalService, string text)
        {
            var label = new Label
            {
                Text = text,
                FontSize = 18,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            modalService.ShowModalWithContent(label);
        }

        public static void ShowDynamicControlsModal(this IModalService modalService, List<View> controls)
        {
            var stack = new StackLayout
            {
                Spacing = 12,
                Padding = new Thickness(20),
            };

            foreach (var control in controls)
            {
                switch (control)
                {
                    case CustomButton btn:
                        btn.Text = btn.TextEx; // اگر TextEx استفاده می‌کنی
                        btn.Clicked += (s, e) =>
                        {
                            if (btn.Command?.CanExecute(btn.CommandParameter) == true)
                                btn.Command.Execute(btn.CommandParameter);
                        };
                        break;

                    case CustomLabel lbl:
                        var tap = new TapGestureRecognizer();
                        tap.Tapped += (s, e) =>
                        {
                            if (lbl.Command?.CanExecute(lbl.CommandParameter) == true)
                                lbl.Command.Execute(lbl.CommandParameter);
                        };
                        lbl.GestureRecognizers.Add(tap);
                        break;

                    case CustomEntry entry:
                        entry.Completed += (s, e) =>
                        {
                            if (entry.Command?.CanExecute(entry.CommandParameter) == true)
                                entry.Command.Execute(entry.CommandParameter);
                        };
                        break;

                    case CustomPicker picker:
                        picker.SelectedIndexChanged += (s, e) =>
                        {
                            if (picker.Command?.CanExecute(picker.CommandParameter) == true)
                                picker.Command.Execute(picker.CommandParameter);
                        };
                        break;
                }

                stack.Children.Add(control);
            }

            modalService.ShowModalWithContent(stack);
        }

    }
}
