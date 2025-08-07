using ModalManager.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModalManager.Services
{
    public interface IModalService
    {
        void Show(View content);
        void CloseCurrent();
        void CloseAll();
    }
    public class ModalService : IModalService
    {
        private ModalHostView? _host;

        public void RegisterHost(ModalHostView host)
        {
            _host = host;
        }

        public void Show(View content)
        {
            if (_host is null) return;

            var modal = new ModalView(content);
            modal.OnClosed += () => _host.CloseCurrentModal();

            _host.ShowModal(modal);
        }

        public void CloseCurrent()
        {
            _host?.CloseCurrentModal();
        }

        public void CloseAll()
        {
            _host?.CloseAllModals();
        }
    }
}
