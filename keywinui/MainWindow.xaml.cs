using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Windows.UI.Core; // Sử dụng Windows.UI.Core cho CoreWindow
using Microsoft.UI.Xaml.Input;
using Windows.System;


// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace keywinui
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        private GlobalKeyListener _keyListener;

        public MainWindow()
        {
            this.InitializeComponent();
            _keyListener = new GlobalKeyListener(OnKeyPressed, OnMouseAction);
        }

        private void OnKeyPressed(int vkCode)
        {
           VirtualKey key = (VirtualKey)vkCode;
            string keyString = key.ToString();

            UpdateLabel($"Key Pressed: {keyString} (Code: {vkCode})");
        }

        private void OnMouseAction(string action)
        {
            UpdateLabel(action);
        }

        private void UpdateLabel(string text)
        {
            KeyPressLabel.Text += $"{text}\n";
        }

        ~MainWindow()
        {
            _keyListener.Unhook();
        }
    }
}