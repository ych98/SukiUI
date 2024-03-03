﻿using System;
using System.Collections.ObjectModel;
using System.Globalization;
using Avalonia.Controls;
using Avalonia.Data.Converters;
using Avalonia.Markup.Xaml;
using Material.Icons;
using SukiUI.Demo.Utilities;

namespace SukiUI.Demo.Features.Playground
{
    internal class PlaygroundViewModel() : DemoPageBase("Playground", MaterialIconKind.Pencil, -150)
    {
        public ObservableCollection<string> ButtonsElements { get; init; } =
        [
            XamlData.Buttons["ButtonFlat"],
            XamlData.Buttons["ButtonFlatRounded"],
            XamlData.Buttons["ButtonFlatLarge"],
            XamlData.Buttons["ButtonBasic"],
            XamlData.Buttons["ButtonBasicAccent"],
            XamlData.Buttons["ButtonNeutral"],
            XamlData.Buttons["ButtonOutlined"]
        ];

        public ObservableCollection<string> InputsElements { get; init; } =
        [
            XamlData.Inputs["TextBox"],
            XamlData.Inputs["ToggleSwitch"],
            XamlData.Inputs["ToggleButton"],
            XamlData.Inputs["Slider"],
            XamlData.Inputs["ComboBox"],
            XamlData.Inputs["CheckBox"],
            XamlData.Inputs["RadioButton"],
            XamlData.Inputs["NumericUpDown"],
            XamlData.Inputs["DatePicker"]
        ];

        public ObservableCollection<string> ProgressElements { get; init; } =
        [
            XamlData.Progress["WaveProgress"],
            XamlData.Progress["Stepper"],
            XamlData.Progress["CircleProgressBar"],
            XamlData.Progress["StepperAlternativeStyle"],
            XamlData.Progress["CircleProgressBarIndeterminate"],
            XamlData.Progress["Loading"],
            XamlData.Progress["ProgressBar60"],
            XamlData.Progress["ProgressBar50WithProgressText"],
            XamlData.Progress["ProgressBarIndeterminate"]
        ];

        public ObservableCollection<string> ListsElements { get; init; } =
        [
            XamlData.Lists["ListBox"],
            XamlData.Lists["TreeView"]
        ];

        public ObservableCollection<string> LayoutElements { get; init; } =
        [
            XamlData.Layout["GlassCard"],
            XamlData.Layout["GroupBox"],
            XamlData.Layout["Expander"],
            XamlData.Layout["TabControl"]
        ];
    }

    public sealed class StringToControlConverter : IValueConverter
    {
        public static readonly StringToControlConverter Instance = new();

        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is not string xamlCode) return null;
            if (string.IsNullOrWhiteSpace(xamlCode)) return null;

            var previewCode = XamlData.InsertIntoGridControl(xamlCode);
            return AvaloniaRuntimeXamlLoader.Parse<Grid>(previewCode);
        }

        public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}