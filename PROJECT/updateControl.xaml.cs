using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for updateControl.xaml
    /// </summary>
    public partial class updateControl : UserControl
    {
        public updateControl()
        {
            InitializeComponent();
        }
         public static readonly RoutedEvent UpdatedEvent = EventManager.RegisterRoutedEvent(
            "Updated", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(addPatient));

        public event RoutedEventHandler Updated
        {
            add { AddHandler(UpdatedEvent, value); }
            remove { RemoveHandler(UpdatedEvent, value); }
        }


        void RaiseEvent()
        {
            RoutedEventArgs myArgs = new RoutedEventArgs(UpdatedEvent);
            RaiseEvent(myArgs);
        }

        private void update_btn_Click(object sender, RoutedEventArgs e)
        {
            if(radioButton1.IsChecked==true || radioButton2.IsChecked==true)
            {
                update_btn.IsEnabled=true;
            }
            RaiseEvent();
        }

        
        
        }

    }

