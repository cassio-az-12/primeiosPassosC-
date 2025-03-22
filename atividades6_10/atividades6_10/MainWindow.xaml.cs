using System;
using System.Windows;
using System.Windows.Controls;

namespace Aplicacao
{
    //exercicio 6
    public partial class MainWindow : Window
    {
        private int contador = 0;
        private bool estadoLigado = false; 
        private Random random = new Random(); 

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnContador_Click(object sender, RoutedEventArgs e)
        {
            contador++;
            MessageBox.Show($"Número de cliques: {contador}", "Contador");
        }

        // exercicio 7
        private void BtnCalcularParcelas_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(txtValorTotal.Text, out double valorTotal) && cbParcelas.SelectedItem is ComboBoxItem selectedItem)
            {
                int numParcelas = int.Parse(selectedItem.Content.ToString());
                double valorParcela = valorTotal / numParcelas;
                MessageBox.Show($"Valor de cada parcela: R$ {valorParcela:F2}", "Resultado");
            }
            else
            {
                MessageBox.Show("Por favor, insira um valor válido e selecione o número de parcelas.", "Erro");
            }
        }

        // exercicio 8
        public enum DiasDaSemana
        {
            Domingo, Segunda, Terça, Quarta, Quinta, Sexta, Sábado
        }

        private void BtnVerificarDia_Click(object sender, RoutedEventArgs e)
        {
            if (dpData.SelectedDate.HasValue)
            {
                DateTime dataSelecionada = dpData.SelectedDate.Value;
                DiasDaSemana diaSemana = (DiasDaSemana)dataSelecionada.DayOfWeek;
                MessageBox.Show($"O dia da semana é: {diaSemana}", "Resultado");
            }
            else
            {
                MessageBox.Show("Por favor, selecione uma data!", "Erro");
            }
        }

        // exercico 9
        private void BtnInterruptor_Click(object sender, RoutedEventArgs e)
        {
            estadoLigado = !estadoLigado;
            string estado = estadoLigado ? "Ligado" : "Desligado";
            btnInterruptor.Content = estado;
            MessageBox.Show($"O interruptor está {estado}", "Estado Atual");
        }

        // exercicio 10
        public enum NumerosSorteio
        {
            Um = 1, Dois = 2, Três = 3, Quatro = 4, Cinco = 5, Seis = 6
        }

        private void BtnSortear_Click(object sender, RoutedEventArgs e)
        {
            int numeroSorteado = random.Next(1, 7);
            NumerosSorteio resultado = (NumerosSorteio)numeroSorteado;

            if (resultado == NumerosSorteio.Seis)
                MessageBox.Show($"Número sorteado: {resultado} \nVocê ganhou!", "Resultado");
            else
                MessageBox.Show($"Número sorteado: {resultado} \nTente novamente!", "Resultado");
        }
    }
}
