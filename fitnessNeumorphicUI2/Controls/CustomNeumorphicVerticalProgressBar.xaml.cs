using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace fitnessNeumorphicUI2.Controls
{
    public partial class CustomNeumorphicVerticalProgressBar : ContentView
    {
        #region fields
        public static readonly BindableProperty ProgressTypeLabelProperty =
              BindableProperty.CreateAttached(
              "ProgressTypeLabel",
              typeof(string),
              typeof(NeumorphicSquare),
              string.Empty,
              propertyChanged: ProgressTypeLabelChanged);

        public static readonly BindableProperty ProgressPercentageProperty =
               BindableProperty.CreateAttached(
              "ProgressPercentage",
              typeof(string),
              typeof(NeumorphicSquare),
              string.Empty,
              propertyChanged: ProgressPercentageChanged);

        public static readonly BindableProperty ProgressBarColorProperty =
             BindableProperty.CreateAttached(
            "ProgressBarColor",
            typeof(Color),
            typeof(NeumorphicSquare),
            Color.CornflowerBlue,
            propertyChanged: ProgressBarColorChanged);

        private static int _fullProgressBarHeight = 250;
        #endregion

        #region Properties
        public static string GetProgressTypeLabel(BindableObject view)
        {
            return (string)view.GetValue(ProgressTypeLabelProperty);
        }

        public static void SetProgressTypeLabel(BindableObject view, string value)
        {
            view.SetValue(ProgressTypeLabelProperty, value);
        }

        public static string GetProgressPercentage(BindableObject view)
        {
            return (string)view.GetValue(ProgressPercentageProperty);
        }

        public static void SetProgressPercentage(BindableObject view, string value)
        {
            view.SetValue(ProgressPercentageProperty, value);
        }

        public static Color GetProgressBarColor(BindableObject view)
        {
            return (Color)view.GetValue(ProgressBarColorProperty);
        }

        public static void SetProgressBarColor(BindableObject view, string value)
        {
            view.SetValue(ProgressBarColorProperty, value);
        }
        #endregion
        #region constructor
        public CustomNeumorphicVerticalProgressBar()
        {
            InitializeComponent();
        }
        #endregion

        #region Methods

        private static void ProgressTypeLabelChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var targetType = bindable as CustomNeumorphicVerticalProgressBar;

            if(targetType != null)
            {
                targetType.TypeLabel.Text = GetProgressTypeLabel(bindable);
            }
        }

        private static void ProgressPercentageChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var targetType = bindable as CustomNeumorphicVerticalProgressBar;
            var progressPercentage = GetProgressPercentage(bindable);
            
            if (targetType != null)
            {
                int progressBarInt = 0;

                targetType.ProgressPercentage.Text = $"{progressPercentage}%";

                Int32.TryParse(progressPercentage, out progressBarInt);

                progressBarInt = decimal.ToInt32((((decimal)progressBarInt / 100) * _fullProgressBarHeight));

                targetType.ProgressColorBar.HeightRequest = progressBarInt;
            }
        }


        private static void ProgressBarColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var targetType = bindable as CustomNeumorphicVerticalProgressBar;

            if (targetType != null)
            {
                targetType.ProgressColorBar.BackgroundColor = GetProgressBarColor(bindable);
            }
        }

        #endregion
    }
}
