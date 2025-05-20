using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using System.Windows.Media;

namespace MatchingPairsGame
{
    public partial class MainWindow : Window
    {
        private List<int> _cardValues;
        private List<Button> _buttons = new List<Button>();
        private Button? _firstClicked = null;
        private int _moveCount = 0;

        public MainWindow()
        {
            InitializeComponent();
            InitializeGame();
        }

        private void InitializeGame()
        {
            // Определяем пары чисел (вместо изображений)
            _cardValues = new List<int> { 1, 2, 3, 4, 1, 2, 3, 4 }; // Пример: 4 пары
            Random rng = new Random();
            _cardValues = _cardValues.OrderBy(a => rng.Next()).ToList();

            // Создаем кнопки
            CardGrid.ItemsSource = _cardValues;

            // Ожидаем пока ItemsControl закончит генерацию элементов
            CardGrid.Dispatcher.Invoke(() => { }, DispatcherPriority.ContextIdle);

            // Сохраняем ссылки на кнопки
            _buttons = new List<Button>();
            for (int i = 0; i < CardGrid.Items.Count; i++)
            {
                ContentPresenter cp = (ContentPresenter)CardGrid.ItemContainerGenerator.ContainerFromIndex(i);
                if (cp != null)
                {
                    Button button = FindVisualChild<Button>(cp);
                    if (button != null)
                    {
                        _buttons.Add(button);
                    }
                }
            }
        }

        // Вспомогательная функция для поиска дочернего элемента определенного типа в визуальном дереве
        private T? FindVisualChild<T>(DependencyObject obj) where T : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(obj, i);
                if (child != null && child is T)
                {
                    return (T)child;
                }
                else
                {
                    T? childOfChild = FindVisualChild<T>(child);
                    if (childOfChild != null)
                    {
                        return childOfChild;
                    }
                }
            }
            return null;
        }

        private async void Card_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)sender;

            if (clickedButton.Tag == "Flipped" || !clickedButton.IsEnabled) return;

            clickedButton.Tag = "Flipped"; // Помечаем как перевернутую

            if (_firstClicked == null)
            {
                _firstClicked = clickedButton;
                UpdateMoveCount(); // Увеличиваем счетчик ходов только когда переворачиваем вторую карточку.
            }
            else
            {
                UpdateMoveCount();
                // Проверяем совпадение
                if (_firstClicked.Content.Equals(clickedButton.Content))
                {
                    // Совпадение
                    _firstClicked.IsEnabled = false;
                    clickedButton.IsEnabled = false;
                    _firstClicked = null;

                    // Проверяем, все ли пары найдены
                    if (_buttons.All(b => !b.IsEnabled))
                    {
                        MessageBox.Show($"Вы выиграли за {_moveCount} ходов!");
                        InitializeGame(); // Перезапуск игры
                    }
                }
                else
                {
                    // Нет совпадения
                    await Task.Delay(500); // Пауза

                    _firstClicked.Tag = null; // Скрываем первую
                    clickedButton.Tag = null; // Скрываем вторую
                    _firstClicked = null; // Сбрасываем
                }
            }
        }

        private void UpdateMoveCount()
        {
            _moveCount++;
            MoveCountTextBlock.Text = $"Ходов: {_moveCount}";
        }
    }
}