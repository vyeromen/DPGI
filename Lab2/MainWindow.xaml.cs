using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            CommandBinding saveCommand = new CommandBinding(ApplicationCommands.Save, execute_Save, canExecute_Save);
            CommandBindings.Add(saveCommand);

            CommandBinding openCommand = new CommandBinding(ApplicationCommands.Open, execute_Open);
            CommandBindings.Add(openCommand);

            CommandBinding clearCommand = new CommandBinding(ApplicationCommands.Delete, execute_Clear, canExecute_Clear);
            CommandBindings.Add(clearCommand);

        }

        void canExecute_Save(object sender, CanExecuteRoutedEventArgs e)
        {
            if (InputTextBox.Text.Trim().Length > 0) e.CanExecute = true;
            else e.CanExecute = false;
        }
        void execute_Save(object sender, ExecutedRoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстові файли (*.txt)|*.txt|Всі файли (*.*)|*.*";
            saveFileDialog.Title = "Виберіть файл для збереження";
            saveFileDialog.InitialDirectory = "C:\\Users\\User\\Desktop\\example";

            if (saveFileDialog.ShowDialog() == true)
            {
                string newFilePath = saveFileDialog.FileName;
                System.IO.File.WriteAllText(newFilePath, InputTextBox.Text);
                MessageBox.Show($"Файл збережено!");
            }
        }

        void execute_Open(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Текстові файли (*.txt)|*.txt|Всі файли (*.*)|*.*";
            openFileDialog.Title = "Виберіть файл";
            openFileDialog.InitialDirectory = "C:\\Users\\User\\Desktop\\example";
            if (openFileDialog.ShowDialog() == true)
            {
                InputTextBox.Text = System.IO.File.ReadAllText(openFileDialog.FileName);
            }
        }

        void canExecute_Clear(object sender, CanExecuteRoutedEventArgs e)
        {
            if (InputTextBox.Text.Length > 0) e.CanExecute = true;
            else e.CanExecute = false;
        }
        void execute_Clear(object sender, ExecutedRoutedEventArgs e)
        {
            InputTextBox.Text = "";
        }

    }
}
