using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
namespace PZ_6
{
    public partial class MainWindow : Window
    {
        private CancellationTokenSource _cancellationTokenSource;
        public string Status { get; set; }
        public int Progress { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }
        private async void StartCalculations_Click(object sender, RoutedEventArgs e)
        {
            _cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = _cancellationTokenSource.Token;
            try
            {
                await Task.Run(() => DoLongCalculations(cancellationToken), cancellationToken);
            }
            catch (OperationCanceledException)
            {
                Status = "Calculations cancelled";
            }
            finally
            {
                if (_cancellationTokenSource!=null)
                {
                    _cancellationTokenSource.Dispose();
                    _cancellationTokenSource = null;
                }
                
            }
        }
        private void DoLongCalculations(CancellationToken cancellationToken)
        {
            const int iterationsCount = 10;
            const int delayMilliseconds = 500;
            for (var i = 0; i < iterationsCount; i++)
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    cancellationToken.ThrowIfCancellationRequested();
                }
                Thread.Sleep(delayMilliseconds);
                var progress = (i + 1) * 100 / iterationsCount;
                Dispatcher.Invoke(() => PR1.Value = progress);
            }
            Dispatcher.Invoke(() => Status = "Готово");
            MessageBox.Show("Асинхронный подход позволяет улучшить пользовательский опыт и повысить отзывчивость приложения.\r\nПользователь может продолжать работу с формой во время выполнения длительных вычислений,\r\nи он видит прогресс выполнения вычислений в реальном времени. Кроме того, асинхронный подход\r\nпозволяет более эффективно использовать ресурсы компьютера, так как приложение не блокирует\r\nосновной поток выполнения. Однако при использовании асинхронного подхода необходимо учитывать\r\nпотенциальные проблемы, такие как гонки данных и блокировка ресурсов.");
        }
        private void CancelCalculations_Click(object sender, RoutedEventArgs e)
        {
            _cancellationTokenSource?.Cancel();
        }
    }
}

/*Асинхронный подход позволяет улучшить пользовательский опыт и повысить отзывчивость приложения.
Мы можем продолжать работу с формой во время выполнения длительных вычислений,
и мы видим прогресс выполнения вычислений в реальном времени. Кроме того, асинхронный подход
позволяет более эффективно использовать ресурсы компьютера, так как приложение не блокирует
основной поток выполнения. Однако при использовании асинхронного подхода необходимо учитывать
потенциальные проблемы.
*/