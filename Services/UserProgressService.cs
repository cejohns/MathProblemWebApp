using MathProblemWebApp.Models;
using System.Collections.Generic;

namespace MathProblemWebApp.Services
{
    public class UserProgressService
    {
        private readonly Dictionary<string, UserProfile> _userProfiles = new Dictionary<string, UserProfile>();

        // Get user profile
        public UserProfile GetUserProfile(string userId)
        {
            if (!_userProfiles.ContainsKey(userId))
            {
                _userProfiles[userId] = new UserProfile { UserId = userId };
            }
            return _userProfiles[userId];
        }

        // Update user progress
        public void UpdateProgress(string userId, bool correctAnswer)
        {
            var userProfile = GetUserProfile(userId);
            userProfile.TotalProblemsSolved++;

            if (correctAnswer)
            {
                userProfile.CorrectAnswers++;
            }
            else
            {
                userProfile.IncorrectAnswers++;
            }

            // Adjust difficulty based on performance
            if (userProfile.CorrectAnswers > userProfile.TotalProblemsSolved * 0.8)
            {
                userProfile.CurrentDifficulty = DifficultyLevel.Medium;
            }
            else if (userProfile.CorrectAnswers > userProfile.TotalProblemsSolved * 0.6)
            {
                userProfile.CurrentDifficulty = DifficultyLevel.Easy;
            }
            else
            {
                userProfile.CurrentDifficulty = DifficultyLevel.Hard;
            }
        }
    }
}
