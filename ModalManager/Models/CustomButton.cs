using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModalManager.Models
{
    public class CustomButton :Button
    {
        public static readonly BindableProperty CommandParameterProperty =
       BindableProperty.Create(nameof(CommandParameter), typeof(object), typeof(CustomButton));

        public static readonly BindableProperty IDProperty =
            BindableProperty.Create(nameof(ID), typeof(int), typeof(CustomButton));

        public static readonly BindableProperty TextExProperty =
            BindableProperty.Create(nameof(TextEx), typeof(string), typeof(CustomButton), default(string));

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

        public string TextEx
        {
            get => (string)GetValue(TextExProperty);
            set => SetValue(TextExProperty, value);
        }
    }
}
