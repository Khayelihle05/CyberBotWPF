using System.Collections.Generic;

namespace CyberBotWPF
{
    public class ChatbotEngine
    {
        public static string GetResponse(
            string input,
            UserMemory memory)
        {
            input = input.ToLower();
            //Keyword Recognition System
            foreach (
                KeyValuePair<string, List<string>> entry
                in ResponseManager.Responses)
            {
                if (input.Contains(entry.Key))
                {
                    memory.FavouriteTopic =
                        entry.Key;

                    return ResponseManager
                        .GetRandomResponse(entry.Key);
                }
            }

            if (input.Contains("help"))
            {
                return "Try: password, phishing, privacy, scam, worried, favourite topic, tell me more, another tip.";
            }

            if (input.Contains("tell me more"))
            {
                return "Cybersecurity protects your accounts, devices and personal information from digital threats.";
            }

            if (input.Contains("another tip"))
            {
                return "Use two-factor authentication whenever possible.";
            }
            //Sentiment Detection
            if (input.Contains("worried")
                || input.Contains("anxious")
                || input.Contains("scared"))
            {
                return $"I understand you're worried, {memory.Name}. Learning safe online habits helps a lot.";
            }

            if (input.Contains("frustrated")
                || input.Contains("angry"))
            {
                return $"Sorry you're frustrated, {memory.Name}. I'm here to help.";
            }
            //Memory Recall System
            if (input.Contains("favourite topic"))
            {
                if (!string.IsNullOrEmpty(
                    memory.FavouriteTopic))
                {
                    return $"Your favourite topic appears to be {memory.FavouriteTopic}, {memory.Name}.";
                }

                return "You haven't explored a favourite topic yet.";
            }

            return "I didn't understand that. Type HELP to see available topics.";
        }
    }
}