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

namespace AnalizadorLex
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
           

            if (!tbOracion.Text.Equals(""))
            {

                String oracion = tbOracion.Text;
                char delimitador = ' ';
                String[] palabras = oracion.Split(delimitador);
                for (int i = 0; i < palabras.Length; i++)
                {
                    int valorNumerico = 0;
                    double valorDecimal=0.00;
                    if (int.TryParse(palabras[i], out valorNumerico))
                    {
                        MessageBox.Show(palabras[i]+" es numero"); 
                    }
                    else if (Double.TryParse(palabras[i], out valorDecimal))
                    {
                        MessageBox.Show(palabras[i] + " es decimal");  
                    }
                    else
                    {
                        char[] charArr = palabras[i].ToCharArray();
                        if (charArr[0].Equals('Q'))
                        {
                            if (charArr[1].Equals('.'))
                            {
                                MessageBox.Show(palabras[i] + " es dinero");
                            }
                            else
                            {
                                MessageBox.Show(palabras[i] + " es palabra");
                            }
                        }
                        else
                        {
                            MessageBox.Show(palabras[i] + " es palabra");
                        }
                    }
                }
            }
        }
    }
}
