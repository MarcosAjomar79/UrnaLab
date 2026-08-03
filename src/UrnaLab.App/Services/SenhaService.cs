using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace UrnaLab.App.Services
{
    public static class SenhaService
    {

        private const int TamanhoSalt = 16;
        private const int TamanhoHash = 32;
        private const int Iteracoes = 100_000;

        public static string CriarHash(string senha)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(TamanhoSalt);
            byte[] hash = Rfc2898DeriveBytes.Pbkdf2(senha, salt, Iteracoes, HashAlgorithmName.SHA256, TamanhoHash);

            return string.Join(".", Iteracoes, Convert.ToBase64String(salt), Convert.ToBase64String(hash));
        }

        public static bool VerificarSenha(string senhaDigitada, string senhaArmanezada)
        {
            string[] partes = senhaArmanezada.Split(".");

            if (partes.Length != 3)
            {
                return false;
            }

            int iteracoes = int.Parse(partes[0]);
            byte[] salt = Convert.FromBase64String(partes[1]);
            byte[] hashEsperado = Convert.FromBase64String(partes[2]);

            byte[] hashCalculado = Rfc2898DeriveBytes.Pbkdf2(senhaDigitada, salt, iteracoes, HashAlgorithmName.SHA256, hashEsperado.Length);

            return CryptographicOperations.FixedTimeEquals(hashCalculado, hashEsperado);
        }
    }
}
