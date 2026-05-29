using System;
using System.Collections.Generic;

namespace CyberBotWPF
{
    public class ResponseManager
    {
        private static Random random = new Random();

        public static Dictionary<string, List<string>> Responses =
            new Dictionary<string, List<string>>()
        {
            {
                "password",
                new List<string>()
                {
                    "Use strong passwords with symbols and numbers.",
                    "Never reuse passwords across accounts.",
                    "Password managers help create secure passwords."
                }
            },

            {
                "phishing",
                new List<string>()
                {
                    "Avoid suspicious emails requesting personal information.",
                    "Always inspect links before clicking.",
                    "Banks rarely ask for passwords through email."
                }
            },

            {
                "scam",
                new List<string>()
                {
                    "Scammers often create fake urgency.",
                    "Be careful of deals that seem too good to be true.",
                    "Verify identities before sending information."
                }
            },

            {
                "privacy",
                new List<string>()
                {
                    "Review your privacy settings regularly.",
                    "Avoid oversharing online.",
                    "Protect sensitive information."
                }
            }
        };

        public static string GetRandomResponse(string topic)
        {
            return Responses[topic]
                [random.Next(Responses[topic].Count)];
        }
    }
}