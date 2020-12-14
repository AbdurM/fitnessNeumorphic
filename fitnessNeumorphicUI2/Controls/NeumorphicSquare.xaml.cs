using System;
using Xamarin.Forms;
using Xamarin.Forms.NeoControls;

namespace fitnessNeumorphicUI2.Controls
{
    public partial class NeumorphicSquare : NeoButton
    {
        public static readonly BindableProperty CustomImageSourceProperty =
           BindableProperty.CreateAttached(
               "CustomImageSource",
               typeof(string),
               typeof(NeumorphicSquare),
               string.Empty,
               propertyChanged: CustomImageSourceChanged);

        public static string GetCustomImageSource(BindableObject view)
        {
            return (string)view.GetValue(CustomImageSourceProperty);
        }

        public static void SetCustomImageSource(BindableObject view, string value)
        {
            view.SetValue(CustomImageSourceProperty, value);
        }

        private static void CustomImageSourceChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var targetView = bindable as NeumorphicSquare;
            targetView.InternalImageView.Source = GetCustomImageSource(bindable);
        }

        public NeumorphicSquare()
        {
            InitializeComponent();
        }

        private void NeoButton_Clicked(System.Object sender, System.EventArgs e)
        {
            neo_button.ShadowDrawMode = neo_button.ShadowDrawMode == ShadowDrawMode.All ? ShadowDrawMode.OuterOnly: ShadowDrawMode.All;
        }
    }
}