using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace Praktos1
{
    public partial class MainWindow : Window
    {
        int randomnum;
        string NameButton;
        int GetNum;
        char GetChar;
        Random random = new Random();
        string[] AvailableButtons = new string[9] { "B1", "B2", "B3", "B4", "B5", "B6", "B7", "B8", "B9" };
        int countDisabled;
        int CoutBotWins = 0;
        int CoutUserWins = 0;
        int CoutDraws = 0;
        bool flag;

        public MainWindow()
        {
            InitializeComponent();
        }

        public void Botik()
        {
            if (flag == false)
            {
                randomnum = random.Next(0, 8);

                while (AvailableButtons[randomnum] == "disabled")
                {
                    randomnum = random.Next(0, 8);
                }

                switch (randomnum)
                {
                    case 0:
                        B1.Content = "0"; B1.IsEnabled = false; AvailableButtons[0] = "disabled";
                        break;
                    case 1:
                        B2.Content = "0"; B2.IsEnabled = false; AvailableButtons[1] = "disabled";
                        break;
                    case 2:
                        B3.Content = "0"; B3.IsEnabled = false; AvailableButtons[2] = "disabled";
                        break;
                    case 3:
                        B4.Content = "0"; B4.IsEnabled = false; AvailableButtons[3] = "disabled";
                        break;
                    case 4:
                        B5.Content = "0"; B5.IsEnabled = false; AvailableButtons[4] = "disabled";
                        break;
                    case 5:
                        B6.Content = "0"; B6.IsEnabled = false; AvailableButtons[5] = "disabled";
                        break;
                    case 6:
                        B7.Content = "0"; B7.IsEnabled = false; AvailableButtons[6] = "disabled";
                        break;
                    case 7:
                        B8.Content = "0"; B8.IsEnabled = false; AvailableButtons[7] = "disabled";
                        break;
                    case 8:
                        B9.Content = "0"; B9.IsEnabled = false; AvailableButtons[8] = "disabled";
                        break;
                }
            }
            CheckBotWin();
        }
        public void ResetGame()
        {
            for (int i = 0; i < AvailableButtons.Length; i++)
            {
                AvailableButtons[i] = "B" + (i+1).ToString();
            }
            B1.Content = ""; B1.IsEnabled = true; B2.Content = ""; B2.IsEnabled = true; 
            B3.Content = ""; B3.IsEnabled = true; B4.Content = ""; B4.IsEnabled = true; 
            B5.Content = ""; B5.IsEnabled = true; B6.Content = ""; B6.IsEnabled = true;
            B7.Content = ""; B7.IsEnabled = true; B8.Content = ""; B8.IsEnabled = true;
            B9.Content = ""; B9.IsEnabled = true;
        }
        public void CheckUserWin()
        {
            if (B1.Content == "X" && B2.Content == "X" && B3.Content == "X" ||
                B4.Content == "X" && B5.Content == "X" && B6.Content == "X" ||
                B7.Content == "X" && B8.Content == "X" && B9.Content == "X" ||
                B1.Content == "X" && B5.Content == "X" && B9.Content == "X" ||
                B3.Content == "X" && B5.Content == "X" && B7.Content == "X" ||
                B1.Content == "X" && B4.Content == "X" && B7.Content == "X" ||
                B2.Content == "X" && B5.Content == "X" && B8.Content == "X" ||
                B3.Content == "X" && B6.Content == "X" && B9.Content == "X")
            {
                CoutUserWins += 1;
                UserWins.Text = "Кол-во ваших побед: " + CoutUserWins.ToString();
                MessageBox.Show("Выйграли вы");
                flag = true;
                ResetGame();
            }
        }
        public void CheckBotWin()
        {
            if (B1.Content == "0" && B2.Content == "0" && B3.Content == "0" ||
                B4.Content == "0" && B5.Content == "0" && B6.Content == "0" ||
                B7.Content == "0" && B8.Content == "0" && B9.Content == "0" ||
                B1.Content == "0" && B5.Content == "0" && B9.Content == "0" ||
                B3.Content == "0" && B5.Content == "0" && B7.Content == "0" ||
                B1.Content == "0" && B4.Content == "0" && B7.Content == "0" ||
                B2.Content == "0" && B5.Content == "0" && B8.Content == "0" ||
                B3.Content == "0" && B6.Content == "0" && B9.Content == "0")
            {
                CoutBotWins += 1;
                BotWins.Text = "Кол-во побед бота: " + CoutBotWins.ToString();
                MessageBox.Show("Выйграл ботик");
                flag = true;
                ResetGame();
            }
        }
        public void CheckDraw()
        {
            countDisabled = AvailableButtons.Count(btn => btn == "disabled");
            if (countDisabled == 9)
            {
                CoutDraws += 1;
                Draws.Text = "Кол-во ничьих: " + CoutDraws.ToString();
                MessageBox.Show("Ничья");
                flag = true;
                ResetGame();
            }
        }
        public void DisableButtons()
        {
            GetChar = NameButton[1];
            GetNum = (int)Char.GetNumericValue(GetChar);
            AvailableButtons[GetNum - 1] = "disabled";
        }
        private void RestartButton_Click(object sender, RoutedEventArgs e)
        {
            CoutUserWins = 0;
            UserWins.Text = "Кол-во ваших побед: " + CoutUserWins.ToString();
            CoutBotWins = 0;
            BotWins.Text = "Кол-во побед бота: " + CoutBotWins.ToString();
            CoutDraws = 0;
            Draws.Text = "Кол-во ничьих: " + CoutDraws.ToString();
            ResetGame();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            flag = false;
            (sender as Button).Content = "X";
            (sender as Button).IsEnabled = false;
            NameButton = (sender as Button).Name;
            DisableButtons();
            CheckUserWin();
            CheckDraw();
            Botik();
        }

    }
}
