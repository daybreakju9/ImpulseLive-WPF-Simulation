using System.ComponentModel;
using System.Windows.Input;
using System.Windows.Threading;
using ImpulseLive.WPF.Models;
using ImpulseLive.WPF.Services;

namespace ImpulseLive.WPF.ViewModels
{
    public class GameViewModel : INotifyPropertyChanged
    {
        private GameState _currentState;
        private int _remainingTime;
        private int _round;
        private DispatcherTimer _timer;
        private bool _canHesitateInCurrentRound = true;
        
        // 用于直接绑定到按钮IsEnabled属性的属性
        public bool CanUseHesitate
        {
            get => _canHesitateInCurrentRound;
            set
            {
                if (_canHesitateInCurrentRound != value)
                {
                    _canHesitateInCurrentRound = value;
                    OnPropertyChanged(nameof(CanUseHesitate));
                }
            }
        }

        public GameState CurrentState
        {
            get => _currentState;
            set
            {
                if (_currentState != value)
                {
                    _currentState = value;
                    // 触发PropertyChanged事件，通知UI更新
                    OnPropertyChanged(nameof(CurrentState));
                }
            }
        }

        private Player _player;
        public Player Player
        {
            get => _player;
            set
            {
                if (_player != value)
                {
                    _player = value;
                    OnPropertyChanged(nameof(Player));
                }
            }
        }

        private Product _currentProduct;
        public Product CurrentProduct
        {
            get => _currentProduct;
            set
            {
                if (_currentProduct != value)
                {
                    _currentProduct = value;
                    OnPropertyChanged(nameof(CurrentProduct));
                }
            }
        }

        private BehaviorStats _stats;
        public BehaviorStats Stats
        {
            get => _stats;
            set
            {
                if (_stats != value)
                {
                    _stats = value;
                    OnPropertyChanged(nameof(Stats));
                }
            }
        }

        public int RemainingTime
        {
            get => _remainingTime;
            set
            {
                if (_remainingTime != value)
                {
                    _remainingTime = value;
                    OnPropertyChanged(nameof(RemainingTime));
                }
            }
        }

        public int Round
        {
            get => _round;
            set
            {
                if (_round != value)
                {
                    _round = value;
                    OnPropertyChanged(nameof(Round));
                }
            }
        }

        public ICommand BuyCommand { get; }
        public ICommand HesitateCommand { get; }
        public ICommand RefuseCommand { get; }
        public ICommand StartGameCommand { get; }
        public ICommand ReturnToMenuCommand { get; }

        private readonly ProductFactory _productFactory;
        private readonly DecisionService _decisionService;
        private readonly ResultAnalyzer _resultAnalyzer;

        public event PropertyChangedEventHandler? PropertyChanged;

        public GameViewModel()
        {
            _productFactory = new ProductFactory();
            _decisionService = new DecisionService();
            _resultAnalyzer = new ResultAnalyzer();

            // 直接初始化字段，避免警告
            _player = new Player();
            _stats = new BehaviorStats();
            _analysisResults = new List<string>();
            // 初始化CurrentProduct，避免绑定错误
            _currentProduct = _productFactory.Generate(1);
            // 设置默认状态
            _currentState = GameState.Menu;
            // 初始化其他字段
            _remainingTime = _currentProduct.TimeLimit;
            _round = 1;
            _canHesitateInCurrentRound = true;

            BuyCommand = new RelayCommand(Buy);
            HesitateCommand = new RelayCommand(Hesitate, CanHesitate);
            RefuseCommand = new RelayCommand(Refuse);
            StartGameCommand = new RelayCommand(StartGame);
            ReturnToMenuCommand = new RelayCommand(ReturnToMenu);

            _timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1)
            };
            _timer.Tick += (sender, e) => Tick();
        }

        public void StartGame()
        {
            // 重置玩家数据
            Player = new Player();
            Stats = new BehaviorStats();
            _analysisResults = new List<string>();
            Round = 1;
            
            // 生成第一个商品
            CurrentProduct = _productFactory.Generate(Round);
            RemainingTime = CurrentProduct.TimeLimit;
            
            // 切换到游戏状态
            CurrentState = GameState.Playing;
            
            // 重置犹豫标志
            CanUseHesitate = true; // 使用属性，自动触发PropertyChanged
            
            // 开始倒计时
            _timer.Start();
        }

        public void NextProduct()
        {
            CurrentProduct = _productFactory.Generate(Round);
            RemainingTime = CurrentProduct.TimeLimit;
            OnPropertyChanged(nameof(CurrentProduct));
            
            // 强制重置按钮状态，确保UI正确刷新颜色
            CanUseHesitate = false;
            OnPropertyChanged(nameof(CanUseHesitate)); // 触发第一次更新
            CanUseHesitate = true; // 恢复为可用状态
            OnPropertyChanged(nameof(CanUseHesitate)); // 触发第二次更新
            
            _timer.Start();
        }

        public void Tick()
        {
            RemainingTime--;

            if (RemainingTime <= 0)
            {
                _timer.Stop();
                Round++;
                CheckGameOver();
            }
        }

        private void Buy()
        {
            _timer.Stop();
            _decisionService.Buy(Player, CurrentProduct, Stats, RemainingTime);
            Round++;
            CheckGameOver();
        }

        private bool CanHesitate()
        {
            return _canHesitateInCurrentRound;
        }

        private void Hesitate()
        {
            _decisionService.Hesitate(Player);
            CanUseHesitate = false; // 标记当前回合已使用犹豫，自动触发PropertyChanged
            // 犹豫不结束当前回合，所以不调用CheckGameOver()
        }

        private void Refuse()
        {
            _timer.Stop();
            _decisionService.Refuse(Player, CurrentProduct);
            Round++;
            CheckGameOver();
        }

        private List<string> _analysisResults;
        public List<string> AnalysisResults
        {
            get => _analysisResults;
            set
            {
                if (_analysisResults != value)
                {
                    _analysisResults = value;
                    OnPropertyChanged(nameof(AnalysisResults));
                }
            }
        }

        private void CheckGameOver()
        {
            OnPropertyChanged(nameof(Player));
            OnPropertyChanged(nameof(Stats));

            if (Player.Rationality <= 0 || Player.Money <= 0 || Round > 100)
            {
                AnalysisResults = _resultAnalyzer.Analyze(Player, Stats);
                CurrentState = GameState.Result;
            }
            else
            {
                NextProduct();
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
        // 返回菜单方法
        public void ReturnToMenu()
        {
            // 停止计时器
            _timer.Stop();
            
            // 切换到菜单状态
            CurrentState = GameState.Menu;
        }
    }

    public class RelayCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool>? _canExecute;

        public event EventHandler? CanExecuteChanged;

        public RelayCommand(Action execute, Func<bool>? canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
            
            // 订阅CommandManager.RequerySuggested事件，确保WPF自动重新检查命令状态
            if (canExecute != null)
            {
                System.Windows.Input.CommandManager.RequerySuggested += OnCommandManagerRequerySuggested;
            }
        }

        public bool CanExecute(object? parameter)
        {
            return _canExecute == null || _canExecute();
        }

        public void Execute(object? parameter)
        {
            _execute();
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
        
        private void OnCommandManagerRequerySuggested(object? sender, EventArgs e)
        {
            RaiseCanExecuteChanged();
        }
    }
}