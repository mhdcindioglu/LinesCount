using LinesCount.Forms;
using System.Configuration;
using System.Data;
using System.Windows;

namespace LinesCount;
/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : System.Windows.Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        var frmMain = new FrmMain();
        frmMain.ShowDialog();
    }
}

