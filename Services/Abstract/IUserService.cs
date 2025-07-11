﻿using QuizGame.Entities;
namespace QuizGame.Services.Abstract;

public interface IUserService
{
    public User? Login(string username, string password);
    public void Register(string username, string password, DateTime birthdate);
    public User? GetUserById(string userId);
    public void UpdateSettings(string userId, string? username = null, string? password = null, DateTime? birthdate = null);
    public void DeleteUser(string userId);
    public bool ValidateUsername(string username);
    public bool ValidatePassword(string password);
    public bool ValidateBirthdate(DateTime birthdate);
}
