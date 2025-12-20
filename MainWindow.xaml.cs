using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ImpulseLive.WPF.ViewModels;
using ImpulseLive.WPF.Models;

namespace ImpulseLive.WPF;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private GameViewModel? _viewModel;

    public MainWindow()
    {
        InitializeComponent();
        Loaded += MainWindow_Loaded;
    }

    private void MainWindow_Loaded(object sender, RoutedEventArgs e)
    {
        // 获取数据上下文
        _viewModel = (GameViewModel)DataContext;
        // 订阅PropertyChanged事件
        if (_viewModel != null)
        {
            _viewModel.PropertyChanged += ViewModel_PropertyChanged;
        }
        // 初始显示菜单
        MenuGrid.Visibility = Visibility.Visible;
        GameGrid.Visibility = Visibility.Collapsed;
        ResultGrid.Visibility = Visibility.Collapsed;
    }

    private void ViewModel_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(GameViewModel.CurrentState))
        {
            UpdateViewVisibility();
        }
    }

    private void UpdateViewVisibility()
    {
        // 直接根据CurrentState属性的值切换视图
        if (_viewModel != null)
        {
            MenuGrid.Visibility = _viewModel.CurrentState == GameState.Menu ? Visibility.Visible : Visibility.Collapsed;
            GameGrid.Visibility = _viewModel.CurrentState == GameState.Playing ? Visibility.Visible : Visibility.Collapsed;
            ResultGrid.Visibility = _viewModel.CurrentState == GameState.Result ? Visibility.Visible : Visibility.Collapsed;
        }
    }
    
    // 按钮点击事件处理程序
    private void StartGameButton_Click(object sender, RoutedEventArgs e)
    {
        // 调用GameViewModel的StartGame方法开始游戏
        if (_viewModel != null)
        {
            _viewModel.StartGame();
        }
    }
}