﻿namespace TicTacToe.Common
{
    public interface IHashService
    {
        string Hash(string password);
        string Hash(string password, int iterations);
        bool Verify(string password, string hashedPassword);
    }
}