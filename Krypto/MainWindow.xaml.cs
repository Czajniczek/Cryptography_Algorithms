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

namespace Krypto
{
    public partial class MainWindow : Window
    {
        private KryptographyService kryptographyService = new KryptographyService();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Encode_RailFance(object sender, RoutedEventArgs e)
        {
            string input = RailFence_Input.Text.ToString();
            int key = int.Parse(RailFence_Key.Text);

            RailFence_Output.Text = kryptographyService.EncodeRail(input, key);
        }

        private void Decode_RailFance(object sender, RoutedEventArgs e)
        {
            string input = RailFence_Input.Text.ToString();
            int key = int.Parse(RailFence_Key.Text);

            RailFence_Output.Text = kryptographyService.DecodeRail(input, key);
        }

        private void Encode_A2(object sender, RoutedEventArgs e)
        {
            string input = A2_Input.Text.ToString();

            A2_Output.Text = kryptographyService.EncodeMatrixShift(input);
        }

        private void Decode_A2(object sender, RoutedEventArgs e)
        {
            string input = A2_Input.Text.ToString();

            A2_Output.Text = kryptographyService.DecodeMatrixShift(input);
        }

        private void Encode_B2(object sender, RoutedEventArgs e)
        {
            string input = B2_Input.Text.ToString();
            string key = B2_Key.Text.ToString();

            B2_Output.Text = kryptographyService.Encode2b(input, key);
        }

        private void Decode_B2(object sender, RoutedEventArgs e)
        {
            string input = B2_Input.Text.ToString();
            string key = B2_Key.Text.ToString();

            B2_Output.Text = kryptographyService.Decode2b(input, key);
        }

        private void Encode_C2(object sender, RoutedEventArgs e)
        {
            string input = C2_Input.Text.ToString();
            string key = C2_Key.Text.ToString();

            C2_Output.Text = kryptographyService.Encode2c(input, key);
        }

        private void Decode_C2(object sender, RoutedEventArgs e)
        {
            string input = C2_Input.Text.ToString();
            string key = C2_Key.Text.ToString();

            C2_Output.Text = kryptographyService.Decode2c(input, key);
        }

        private void Encode_B3(object sender, RoutedEventArgs e)
        {
            string input = B3_Input.Text.ToString();
            int K1 = int.Parse(B3_A.Text);
            int K0 = int.Parse(B3_B.Text);

            B3_Output.Text = kryptographyService.EncodeCaesar(input, K1, K0);
        }

        private void Decode_B3(object sender, RoutedEventArgs e)
        {
            string input = B3_Input.Text.ToString();
            int K1 = int.Parse(B3_A.Text);
            int K0 = int.Parse(B3_B.Text);

            B3_Output.Text = kryptographyService.DecodeCaesar(input, K1, K0);
        }

        private void Encode_Vigenere(object sender, RoutedEventArgs e)
        {
            string input = Vigenere_Input.Text.ToString();
            string key = Vigenere_Key.Text.ToString();

            Vigenere_Output.Text = kryptographyService.EncodeVigenere(input, key);
        }

        private void Decode_Vigenere(object sender, RoutedEventArgs e)
        {
            string input = Vigenere_Input.Text.ToString();
            string key = Vigenere_Key.Text.ToString();

            Vigenere_Output.Text = kryptographyService.DecodeVigenere(input, key);
        }
    }
}
