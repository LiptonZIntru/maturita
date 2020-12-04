using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfPrevodnikSoustav
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void calculateButton_Click(object sender, RoutedEventArgs e)
        {
            if(toBinaryCheckbox.IsChecked == true)
            {
                // Pokud je check box zaskrtnuty, prevedeme do dvojkove
                int decimalNumber = int.Parse(inputTextBox.Text);
                int binaryNumber = 0;
                int counter = 1;

                while(decimalNumber > 0)
                {
                    // Ziskame zbytek po celociselnem deleni
                    binaryNumber += decimalNumber % 2 * counter;

                    // Provedeme celociselne deleni
                    decimalNumber /= 2;

                    // Zvysime counter desetkrat, aby se dalsi cislo zapisovalo na prvni misto
                    counter *= 10;
                }

                // Vypiseme vysledek
                resultTextBlock.Text = binaryNumber.ToString();
            }
            else
            {
                // Pokud neni check box zaskrtnuty, prevedeme do desitkove
                int binaryNumber = int.Parse(inputTextBox.Text);
                int decimalNumber = 0;
                int counter = 1;

                while (binaryNumber > 0)
                {
                    // Ziskame posledni cislici v binaryNumber
                    decimalNumber += binaryNumber % 2 * counter;

                    // Provedeme celociselne deleni
                    binaryNumber /= 10;

                    // Zvysime counter dvakrat, viz.
                    // 2 ^ 0 = 1
                    // 2 ^ 1 = 2
                    // 2 ^ 2 = 4
                    // Atd.
                    counter *= 2;
                }

                // Vypiseme vysledek
                resultTextBlock.Text = decimalNumber.ToString();
            }
        }
    }
}
