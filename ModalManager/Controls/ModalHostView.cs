using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModalManager.Controls
{
    public class ModalHostView :ContentView
    {
        private readonly Stack<ModalView> _modalStack = new();

        public ModalHostView()
        {
            // حالت اولیه بدون هیچ مودالی
            IsVisible = false;
            BackgroundColor = Colors.Transparent;
        }

        public void ShowModal(ModalView modal)
        {
            _modalStack.Push(modal);
            UpdateUI();
        }

        public void CloseCurrentModal()
        {
            if (_modalStack.Count > 0)
            {
                var top = _modalStack.Pop();
                top.RaiseClosed(); // فراخوانی متد بسته شدن
            }

            UpdateUI();
        }

        private void UpdateUI()
        {
            if (_modalStack.Count > 0)
            {
                Content = _modalStack.Peek();
                IsVisible = true;
            }
            else
            {
                Content = null;
                IsVisible = false;
            }
        }

        public void CloseAllModals()
        {
            _modalStack.Clear();
            UpdateUI();
        }
    }
}
