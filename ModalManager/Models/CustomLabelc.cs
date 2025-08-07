using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ModalManager.Models
{
    public class CustomLabel : Label
    {
        public static readonly BindableProperty CommandProperty =
      BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(CustomLabel));

        public static readonly BindableProperty CommandParameterProperty =
            BindableProperty.Create(nameof(CommandParameter), typeof(object), typeof(CustomLabel));

        public static readonly BindableProperty IDProperty =
            BindableProperty.Create(nameof(ID), typeof(int), typeof(CustomLabel));

        public ICommand Command
        {
            get => (ICommand)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        public object CommandParameter
        {
            get => GetValue(CommandParameterProperty);
            set => SetValue(CommandParameterProperty, value);
        }

        public int ID
        {
            get => (int)GetValue(IDProperty);
            set => SetValue(IDProperty, value);
        }
    }
}
