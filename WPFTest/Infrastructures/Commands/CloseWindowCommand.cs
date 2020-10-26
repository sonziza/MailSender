using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using WPFTest.Infrastructures.Commands.Base;

namespace WPFTest.Infrastructures.Commands
{
    class CloseWindowCommand : Command
    {
        protected override void Execute(object p)
        {
            var window = p as Window;
            if (window is null)
                window = Application.Current.Windows
                    .Cast<Window>()
                    .FirstOrDefault(w => w.IsFocused);
            if (window is null)
                window = Application.Current.Windows
                .Cast<Window>()
                .FirstOrDefault(w => w.IsActive);
            window?.Close();
        }
    }
}
