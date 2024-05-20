using LinesCount.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LinesCount.Forms;
/// <summary>
/// Interaction logic for FrmMain.xaml
/// </summary>
public partial class FrmMain : Window
{
    FrmMainViewModel vm;
    public FrmMain()
    {
        InitializeComponent();
        vm = new FrmMainViewModel();
        DataContext = vm;
        vm.Dir = "D:\\Users\\mhdci\\source\\repos\\Blazor\\WebIPAS";
    }

    private void btnSelectDir_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            using var dialog = new FolderBrowserDialog();
            dialog.Description = "Select a project directory";
            dialog.ShowNewFolderButton = true;

            DialogResult result = dialog.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK && !string.IsNullOrWhiteSpace(dialog.SelectedPath))
                vm.Dir = dialog.SelectedPath;
        }
        catch (Exception ex)
        {
            System.Windows.MessageBox.Show(ex.Message);
        }
    }

    private void btnStart_Click(object sender, RoutedEventArgs e)
    {
        if (!vm.IsWorking)
        {
            vm.StartBtnTitle = "Stop";
            vm.IsWorking = true;
            vm.TxtDirBackground = System.Drawing.Color.Red;
            System.Windows.Forms.Application.DoEvents();

            DirectoryInfo dirInfo = new(vm.Dir);
            if (dirInfo.Exists)
            {
                tvResult.Items.Clear();
                int allCount = 0;
                foreach (var item in FillContent(dirInfo))
                {
                    if (vm.IsNotWorking) break;
                    tvResult.Items.Add(item);
                    vm.Name = item.Name;
                    System.Windows.Forms.Application.DoEvents();
                    allCount += item.AllLines;
                }
                tvResult.Items.Insert(0, new Models.TreeViewItem { Name = "Total Lines:", Lines = allCount, });
            }
            vm.StartBtnTitle = "Start";
            vm.IsWorking = false;
            vm.TxtDirBackground = System.Windows.Forms.Control.DefaultBackColor;
            System.Windows.MessageBox.Show("Done!");
        }
        else
        {
            vm.StartBtnTitle = "Start";
            vm.IsWorking = false;
            vm.TxtDirBackground = System.Windows.Forms.Control.DefaultBackColor;
        }
    }

    private List<Models.TreeViewItem> FillContent(DirectoryInfo dirInfo)
    {
        var items = new List<Models.TreeViewItem>();

        foreach (var dir in dirInfo.GetDirectories())
        {
            if (vm.Ignore.Contains(dir.Name)) continue;
            if (vm.IsNotWorking) break;
            var item = new Models.TreeViewItem { IsDirectory = true, Name = dir.Name, };
            FillContent(dir).ForEach(x => item.Items.Add(x));
            items.Add(item);
            vm.Name = item.Name;
            System.Windows.Forms.Application.DoEvents();
        }

        foreach (var file in dirInfo.GetFiles())
        {
            if (vm.IsNotWorking) break;
            items.Add(new Models.TreeViewItem { Name = file.Name, Lines = File.ReadAllLines(file.FullName).Length, });
            vm.Name = file.Name;
            System.Windows.Forms.Application.DoEvents();
        }

        return items;
    }
}
