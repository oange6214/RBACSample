using System.Windows;
using System.Windows.Controls;

namespace RBACSample.Helper;

public class PasswordBoxBindingHelper : DependencyObject
{
    public static readonly DependencyProperty PasswordProperty =
        DependencyProperty.RegisterAttached(
            "Password",
            typeof(string),
            typeof(PasswordBoxBindingHelper),
            new PropertyMetadata(null, OnPropertyChanged));

    public static string GetPassword(DependencyObject obj)
    {
        return (string)obj.GetValue(PasswordProperty);
    }

    public static void SetPassword(DependencyObject obj, string value)
    {
        obj.SetValue(PasswordProperty, value);
    }

    private static void OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var passwordBox = (PasswordBox)d;
        passwordBox.PasswordChanged -= PasswordChanged;
        passwordBox.Password = (string)e.NewValue;
        passwordBox.PasswordChanged += PasswordChanged;
    }

    private static void PasswordChanged(object sender, RoutedEventArgs e)
    {
        var passwordBox = (PasswordBox)sender;
        SetPassword(passwordBox, passwordBox.Password);
    }
}