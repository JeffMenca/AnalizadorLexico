//Using y librerias
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
    /// Lógica de interacción para MainWindow.xaml
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //Se genera la tabla por medio del metodo
            generarTabla();
            //Analiza si el textbox no esta vacio
            if (!tbOracion.Text.Equals(""))
            {
                //Variable de la oracion
                String oracion = tbOracion.Text;
                char delimitador = ' ';
                String[] palabras = oracion.Split(delimitador);
                for (int i = 0; i < palabras.Length; i++)
                {
                    int valorNumerico = 0;
                    double valorDecimal = 0.00;
                    //Analiza si es numero
                    if (int.TryParse(palabras[i], out valorNumerico))
                        lvResultados.Items.Add(new items { Lexema = palabras[i], Tipo = "Numero" });
                    //Analiza si es decimal
                    else if (Double.TryParse(palabras[i], out valorDecimal))
                        lvResultados.Items.Add(new items { Lexema = palabras[i], Tipo = "Decimal" });
                    else
                    {
                        char[] charArr = palabras[i].ToCharArray();
                        try
                        {
                            //Analiza si es dinero o una palabra
                            if ((charArr[0].Equals('Q')) && (charArr[1].Equals('.')))
                                lvResultados.Items.Add(new items { Lexema = palabras[i], Tipo = "Dinero" });
                            else
                                lvResultados.Items.Add(new items { Lexema = palabras[i], Tipo = "Palabra" });
                        }
                        catch (Exception)
                        {
                            //Analiza si es una palabra
                            lvResultados.Items.Add(new items { Lexema = palabras[i], Tipo = "Palabra" });
                            throw;
                        }
                    }
                }
            }
        }
        //Clase con los objetos de la tabla
        public class items
        {
            //atributos de la tabla
            public string Lexema { get; set; }
            public string Tipo { get; set; }
        }
        public void generarTabla()
        {
            // Agrega las columnas
            var gridView = new GridView();
            lvResultados.View = gridView;
            gridView.Columns.Add(new GridViewColumn
            {
                //Atributos de las columnas
                Header = "Lexema",
                DisplayMemberBinding = new Binding("Lexema"),
                Width = 185

            });
            gridView.Columns.Add(new GridViewColumn
            {
                //Atributos de las columnas
                Header = "Tipo",
                DisplayMemberBinding = new Binding("Tipo"),
                Width = 185
            });
        }

        private void btLimpiar_Click(object sender, RoutedEventArgs e)
        {
            //Limpia y reinicia la tabla
            lvResultados.Items.Clear();
        }
    }
}
