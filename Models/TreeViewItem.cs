using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinesCount.Models;
public class TreeViewItem
{
    public bool IsDirectory { get; set; }
    public string? Name { get; set; }
    public int Lines { get; set; }
    public int AllLines => Lines + Items.Sum(x => x.AllLines + x.Lines);
    public string Title => $"{Name}:{AllLines + Lines}";

    public ObservableCollection<TreeViewItem> Items { get; set; } = [];
}

