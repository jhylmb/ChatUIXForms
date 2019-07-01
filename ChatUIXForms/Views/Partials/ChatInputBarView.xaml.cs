using System;
using System.Collections.Generic;
using System.Diagnostics;
using ChatUIXForms.ViewModels;
using Xamarin.Forms;

namespace ChatUIXForms.Views.Partials
{
    public partial class ChatInputBarView : ContentView
    {
        public ChatInputBarView()
        {
            InitializeComponent();

            if (Device.RuntimePlatform == Device.iOS)
            {
                this.SetBinding(HeightRequestProperty, new Binding("Height", BindingMode.OneWay, null, null, null, chatTextInput));
            }
        }
        public void Handle_Completed(object sender, EventArgs e)
        {
            chatTextInput.Focus();
            (this.Parent.Parent.BindingContext as ChatPageViewModel).OnSendCommand.Execute(null);
            
        }

        public void UnFocusEntry(){
            chatTextInput?.Unfocus();
        }

        void Handle_Focused(object sender, FocusEventArgs e)
        {
            //chatTextInput.Focus();
            Handle_Completed(sender, e);
        }
    }
}
