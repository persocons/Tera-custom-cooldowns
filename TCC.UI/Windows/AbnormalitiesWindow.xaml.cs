﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TCC.Windows
{
    /// <summary>
    /// Logica di interazione per AbnormalitiesWindow.xaml
    /// </summary>
    public partial class AbnormalitiesWindow : Window
    {
        public AbnormalitiesWindow()
        {
            InitializeComponent();

            buffs.ItemsSource = SessionManager.CurrentPlayer.Buffs;
            buffs.DataContext = SessionManager.CurrentPlayer.Buffs;
            debuffs.ItemsSource = SessionManager.CurrentPlayer.Debuffs;
            debuffs.DataContext = SessionManager.CurrentPlayer.Debuffs;
            infBuffs.ItemsSource = SessionManager.CurrentPlayer.InfBuffs;
            infBuffs.DataContext = SessionManager.CurrentPlayer.InfBuffs;

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            IntPtr hwnd = new WindowInteropHelper(this).Handle;
            FocusManager.MakeUnfocusable(hwnd);
            FocusManager.HideFromToolBar(hwnd);
            Opacity = 0;
            Topmost = true;

            ContextMenu = new ContextMenu();
            var HideButton = new MenuItem() { Header = "Hide" };
            HideButton.Click += (s, ev) =>
            {
                this.Visibility = Visibility.Collapsed;
            };
            ContextMenu.Items.Add(HideButton);

        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Window_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            ContextMenu.IsOpen = true;
        }
    }
}
