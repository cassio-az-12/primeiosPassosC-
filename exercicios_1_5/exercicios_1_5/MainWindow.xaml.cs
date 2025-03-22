using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;

namespace Exercicios
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Preencher o ComboBox com os tipos de usuário (Enum)
            cmbTipoUsuario.ItemsSource = Enum.GetValues(typeof(TipoUsuario)).Cast<TipoUsuario>();
        }

        // Exercício 1: Soma de Dois Números
        private void BtnSomar_Click(object sender, RoutedEventArgs e)
        {
            // Verificando se os campos estão preenchidos
            if (string.IsNullOrEmpty(txtNumero1.Text) || string.IsNullOrEmpty(txtNumero2.Text))
            {
                MessageBox.Show("Por favor, insira ambos os números.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                int numero1 = int.Parse(txtNumero1.Text);
                int numero2 = int.Parse(txtNumero2.Text);

                int soma = numero1 + numero2;
                MessageBox.Show($"A soma dos números é: {soma}", "Resultado", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor, insira números válidos.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Exercício 2: Conversor de Temperatura
        private void btnConverter_Click(object sender, RoutedEventArgs e)
        {
            // Verificando se o campo está preenchido
            if (string.IsNullOrEmpty(txtCelsius.Text))
            {
                MessageBox.Show("Por favor, insira a temperatura em Celsius.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                float celsius = float.Parse(txtCelsius.Text);
                float fahrenheit = (celsius * 9 / 5) + 32;
                MessageBox.Show($"Temperatura em Fahrenheit: {fahrenheit} °F", "Conversão Concluída", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor, insira um número válido.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Exercício 3: Dias Até o Novo Aniversário
        private void CalcularDias_Click(object sender, RoutedEventArgs e)
        {
            // Verificando se a data foi selecionada
            if (BirthDatePicker.SelectedDate.HasValue)
            {
                DateTime birthDate = BirthDatePicker.SelectedDate.Value;
                DateTime todayDate = DateTime.Today;

                DateTime nextBirthday = new DateTime(todayDate.Year, birthDate.Month, birthDate.Day);

                if (nextBirthday < todayDate)
                {
                    nextBirthday = nextBirthday.AddYears(1);
                }

                int daysRemaining = (nextBirthday - todayDate).Days;

                MessageBox.Show($"Faltam {daysRemaining} dias para o seu próximo aniversário!", "Contagem Regressiva", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Por favor, selecione uma data de nascimento.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Exercício 4: Verificador de Maioridade
        private void VerificarMaioridade_Click(object sender, RoutedEventArgs e)
        {
            // Verificando se a idade foi digitada corretamente
            if (int.TryParse(IdadeTextBox.Text, out int idade))
            {
                if (idade >= 18)
                {
                    MessageBox.Show("Você é maior de idade.", "Maioridade", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Você é menor de idade.", "Maioridade", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("Por favor, insira apenas números de uma idade válida.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Exercício 5: Enum Description
        private void BtnMostrarDescricao_Click(object sender, RoutedEventArgs e)
        {
            // Verificando se um tipo de usuário foi selecionado
            if (cmbTipoUsuario.SelectedItem is TipoUsuario tipo)
            {
                string descricao = ObterDescricao(tipo);
                MessageBox.Show(descricao, "Descrição do Tipo de Usuário");
            }
            else
            {
                MessageBox.Show("Selecione um tipo de usuário.", "Atenção");
            }
        }

        private string ObterDescricao(Enum valor)
        {
            // Obtendo o atributo de descrição associado ao valor do enum
            FieldInfo field = valor.GetType().GetField(valor.ToString());
            DescriptionAttribute atributo = field.GetCustomAttribute<DescriptionAttribute>();

            return atributo != null ? atributo.Description : valor.ToString();
        }

        // Enum para Tipos de Usuário com suas descrições
        public enum TipoUsuario
        {
            [Description("Administrador do sistema, com acesso total.")]
            Administrador,

            [Description("Usuário comum, com acesso limitado.")]
            UsuarioComum,

            [Description("Visitante, com acesso restrito.")]
            Visitante
        }
    }
}

