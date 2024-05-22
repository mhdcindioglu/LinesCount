using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows;

namespace LinesCount.Models;

public class FrmMainViewModel : INotifyPropertyChanged
{
    private string _dir = "";
    public string Dir
    {
        get => _dir;
        set
        {
            if (_dir != value)
            {
                _dir = value;
                OnPropertyChanged(nameof(Dir));
            }
        }
    }

    private string _ignore = "bin,obj,.vs,.git,.github,.config,packages,imgs,fonts,libs,lib,logs,Sql";
    public string Ignore
    {
        get => _ignore;
        set
        {
            if (_ignore != value)
            {
                _ignore = value;
                OnPropertyChanged(nameof(Ignore));
            }
        }
    }

    private string _startBtnTitle = "Start";
    public string StartBtnTitle
    {
        get => _startBtnTitle;
        set
        {
            if (_startBtnTitle != value)
            {
                _startBtnTitle = value;
                OnPropertyChanged(nameof(StartBtnTitle));
            }
        }
    }

    private string _totla = "Total lines:";
    public string Total
    {
        get => _totla;
        set
        {
            if (_totla != value)
            {
                _totla = value;
                OnPropertyChanged(nameof(Total));
            }
        }
    }

    private string _name;
    public string Name
    {
        get => _name;
        set
        {
            if (_name != value)
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
    }

    private bool _isWorking = false;
    public bool IsNotWorking => !IsWorking;
    public Visibility IsVisible => IsWorking ? Visibility.Visible : Visibility.Hidden;
    public bool IsWorking
    {
        get => _isWorking;
        set
        {
            if (_isWorking != value)
            {
                _isWorking = value;
                OnPropertyChanged(nameof(IsWorking));
            }
        }
    }

    private Color _txtDirBackground = Control.DefaultBackColor;
    public Color TxtDirBackground
    {
        get => _txtDirBackground;
        set
        {
            if (_txtDirBackground != value)
            {
                _txtDirBackground = value;
                OnPropertyChanged(nameof(TxtDirBackground));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
