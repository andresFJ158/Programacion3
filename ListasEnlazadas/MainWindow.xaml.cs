using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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


namespace ListasEnlazadas
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Pila pila;
        public Cola cola;
        public bool bandera;

        public MainWindow()
        {
            InitializeComponent();
            pila = new Pila(5);
            cola = new Cola(5);
            bandera = true;
        }
        private bool isInteger(string input)
        {
            return int.TryParse(input, out _);
        }

        private void Cola_Add_Click(object sender, RoutedEventArgs e)
        {
            if(bandera == false)
            {
                if (cola.Currentsize < cola.Maxsize)
                {
                    string t = ColaInput.Text;
                    if (isInteger(t))
                    {
                        int data = Int32.Parse(t);
                        ColaListBox.Items.Add(data);
                        cola.enqueue(data);
                    }
                    else
                    {
                        MessageBox.Show("Ingresa un valor correcto", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    ColaInput.Clear();
                }
                else
                {
                    MessageBox.Show("Cola llena");
                }
            }
            else
            {
                if (pila.Currentsize < pila.Maxsize)
                {
                    string t = ColaInput.Text;
                    if (isInteger(t))
                    {
                        int data = Int32.Parse(t);
                        ColaListBox.Items.Insert(0, data);
                        pila.push(data);
                    }
                    else
                    {
                        MessageBox.Show("Ingresa un valor correcto", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);

                    }
                    ColaInput.Clear();
                }
                else
                {
                    MessageBox.Show("Pila llena");
                }
            }
            VaciaCola();
            FullCola();
            TopCola();
            MaximoCola();
        }
        private void Cola_Delete_Click(object sender, RoutedEventArgs e)
        {
            if(bandera == false)
            {
                if (!cola.isEmpty())
                {
                    cola.dequeue();
                    ColaListBox.Items.RemoveAt(0);
                }
                else
                {
                    MessageBox.Show("Cola vacía");
                }
            }
            else
            {
                pila.Pop();
                ColaListBox.Items.RemoveAt(0);
            }
            VaciaCola();
            FullCola();
            TopCola();
            MaximoCola();
        }
        private void VaciaCola()
        {
            if (bandera == false)
            {
                bool empty = cola.isEmpty();
                if (empty)
                {
                    isEmptyText_Cola.Text = "SI";
                }
                else
                {
                    isEmptyText_Cola.Text = "NO";
                }
            }
            else
            {
                bool empty = pila.IsEmpty();
                if (empty)
                    isEmptyText_Cola.Text = "SI";
                else
                    isEmptyText_Cola.Text = "NO";
            }
        }

        private void FullCola()
        {
            if (bandera == false)
            {
                bool full = cola.isFull();
                if (full)
                    isFullText_Cola.Text = "SI";
                else
                    isFullText_Cola.Text = "NO";
            }
            else
            {
                bool empty = pila.IsFull();
                if (empty)
                    isFullText_Cola.Text = "SI";
                else
                    isFullText_Cola.Text = "NO";
            }
        }
        private void TopCola()
        {
            if (bandera == false)
            {
                string topCola = cola.topElement();
                CimaText_Cola.Text = topCola;
            }
            else
            {
                string topPila = pila.TopElement();
                CimaText_Cola.Text = topPila;
            }
        }

        private void MaximoCola()
        {
            if(bandera == false)
            {
                int m = cola.MaxSize();
                MaxText_Cola.Text = m.ToString();
            }
            else
            {
                int m = pila.MaxSize();
                MaxText_Cola.Text = m.ToString();
            }
        }
        private void LimpiarCola_Click(object sender, RoutedEventArgs e)
        {
            if(bandera == false)
            {
                for (int i = 0; i < ColaListBox.Items.Count - 1; i++)
                {
                    cola.dequeue();
                }
                cola.resetsize();
                cola.Currentsize = 0;
                ColaListBox.Items.Clear();
            }
            else
            {
                pila.clearPila();
                ColaListBox.Items.Clear ();
            }
            VaciaCola();
            FullCola();
            TopCola();
            MaximoCola();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            txtMetodo.Text = "Metodo Colas";
            bandera = false;
            pila.clearPila();
            ColaInput.Text = "";
            ColaListBox.Items.Clear();
            isEmptyText_Cola.Text = "";
            isFullText_Cola.Text = "";
            MaxText_Cola.Text = "";
            CimaText_Cola.Text = "";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            txtMetodo.Text = "Metodo Pilas";
            bandera = true;
            cola.dequeue();
            ColaInput.Text = "";
            ColaListBox.Items.Clear();
            isEmptyText_Cola.Text = "";
            isFullText_Cola.Text = "";
            MaxText_Cola.Text = "";
            CimaText_Cola.Text = "";
        }
    }
}
