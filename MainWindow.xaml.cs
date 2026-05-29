using System.Windows;
using System.Windows.Input;

namespace CyberBotWPF
{
    public partial class MainWindow : Window
    {
        private UserMemory memory = new UserMemory();

        private bool nameCaptured = false;

        public MainWindow()
        {
            InitializeComponent();

            AudioService.PlayGreeting();

            AddBotMessage(
                "Hello! Welcome to the Cybersecurity Awareness Bot!");

            AddBotMessage(
                "I'm here to help you learn about passwords, phishing, scams, privacy and online safety.");

            AddBotMessage(
                "First things first — what is your name?");
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            ProcessMessage();
        }

        private void UserInputBox_KeyDown(
            object sender,
            KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                ProcessMessage();
            }
        }

        private void ProcessMessage()
        {
            string input = UserInputBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(input))
            {
                MessageBox.Show(
                    "Please enter something first.");
                return;
            }

            ChatBox.AppendText(
                $"YOU: {input}\n");

            if (!nameCaptured)
            {
                memory.Name = input;

                nameCaptured = true;

                AddBotMessage(
                    $"Nice to meet you, {memory.Name}!");

                AddBotMessage(
                    "You can ask me about passwords, phishing, scams, privacy, or type HELP.");

                UserInputBox.Clear();

                AutoScroll();

                return;
            }

            string response =
                ChatbotEngine.GetResponse(
                    input,
                    memory);

            AddBotMessage(response);

            UserInputBox.Clear();

            AutoScroll();
        }

        private void AddBotMessage(string message)
        {
            ChatBox.AppendText(
                $"BOT: {message}\n");
        }

        private void AutoScroll()
        {
            ChatBox.ScrollToEnd();
        }
    }
}