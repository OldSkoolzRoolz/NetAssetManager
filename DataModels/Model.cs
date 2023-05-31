// ScraperOne 2023
// All Rights Reserved
// Kyle Crowder
// Lawrence Enterprises 2023
// 
// Model.csModel.cs032320233:29 AM

#pragma warning disable IDE1006


using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ScraperOne.DataModels;

public interface IModel
{
    event PropertyChangedEventHandler PropertyChanged;
}

/// <summary>
///     Defines the base class for a model.
/// </summary>
[Serializable]
public abstract class Model : INotifyPropertyChanged, IModel
{
    /// <summary>
    ///     Occurs when a property value changes.
    /// </summary>
    [field: NonSerialized]
    public event PropertyChangedEventHandler PropertyChanged;


    /// <summary>
    ///     Raises the <see cref="E:PropertyChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="System.ComponentModel.PropertyChangedEventArgs" /> instance containing the event data.</param>
    protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
    {
        PropertyChanged?.Invoke(this, e);
    }


    /// <summary>
    ///     Raises the <see cref="E:PropertyChanged" /> event.
    /// </summary>
    /// <param name="propertyName">
    ///     The property name of the property that has changed.
    ///     This optional parameter can be skipped because the compiler is able to create it automatically.
    /// </param>
    protected void RaisePropertyChanged([CallerMemberName] string propertyName = null)
    {
        OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
    }


    /// <summary>
    ///     Set the property with the specified value. If the value is not equal with the field then the field is
    ///     set, a PropertyChanged event is raised and it returns true.
    /// </summary>
    /// <typeparam name="T">Type of the property.</typeparam>
    /// <param name="field">Reference to the backing field of the property.</param>
    /// <param name="value">The new value for the property.</param>
    /// <param name="propertyName">
    ///     The property name. This optional parameter can be skipped
    ///     because the compiler is able to create it automatically.
    /// </param>
    /// <returns>True if the value has changed, false if the old and new value were equal.</returns>
    protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
    {
        if (Equals(field, value)) return false;
        field = value;
        RaisePropertyChanged(propertyName);
        return true;
    }
}