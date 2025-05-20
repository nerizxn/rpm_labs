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
            _cardValues = new List<int> { 1, 2, 3, 4, 1, 2, 3, 4 };
            Random rng = new Random();
            _cardValues = _cardValues.OrderBy(a => rng.Next()).ToList();
            CardGrid.ItemsSource = _cardValues;
            CardGrid.Dispatcher.Invoke(() => { }, DispatcherPriority.ContextIdle);
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

            clickedButton.Tag = "Flipped";

            if (_firstClicked == null)
            {
                _firstClicked = clickedButton;
                UpdateMoveCount();
            }
            else
            {
                UpdateMoveCount();
                if (_firstClicked.Content.Equals(clickedButton.Content))
                {
                    _firstClicked.IsEnabled = false;
                    clickedButton.IsEnabled = false;
                    _firstClicked = null;

                    if (_buttons.All(b => !b.IsEnabled))
                    {
                        MessageBox.Show($"Вы выиграли за {_moveCount} ходов!");
                        InitializeGame();
                    }
                }
                else
                {
                    await Task.Delay(500);

                    _firstClicked.Tag = null;
                    clickedButton.Tag = null;
                    _firstClicked = null;
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
