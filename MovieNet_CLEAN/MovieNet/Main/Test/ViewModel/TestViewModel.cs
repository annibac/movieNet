using MovieNet.Main.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using MovieNet.Main.Views;


namespace MovieNet.Main
{
    public class TestViewModel
    {
        public ICommand TestCommand { get; set; }
        public UserControl View { get; set; }

        public TestViewModel()
        {
            TestCommand = new TestCommand();
            this.View = new Test();
        }
    }
}
