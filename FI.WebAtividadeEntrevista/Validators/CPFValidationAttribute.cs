using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace FI.WebAtividadeEntrevista.Validators
{
    public class CPFValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || !IsCPFValid(value.ToString()))
                return new ValidationResult("CPF inválido.");

            return ValidationResult.Success;
        }

        private bool IsCPFValid(string cpf)
        {
            cpf = Regex.Replace(cpf, "[^0-9]", string.Empty);
            if (cpf.Length != 11 || Regex.IsMatch(cpf, @"^(\d)\1{10}$"))
                return false;

            int[] multiplicadores = new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma = 0, resto;
            for (int i = 0; i < 9; i++)
                soma += int.Parse(cpf[i].ToString()) * multiplicadores[i];

            resto = (soma * 10) % 11;
            if (resto == 10 || resto == 11)
                resto = 0;

            if (resto != int.Parse(cpf[9].ToString()))
                return false;

            soma = 0;
            int[] multiplicadoresSegundoDigito = new int[] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            for (int i = 0; i < 10; i++)
                soma += int.Parse(cpf[i].ToString()) * multiplicadoresSegundoDigito[i];

            resto = (soma * 10) % 11;
            if (resto == 10 || resto == 11)
                resto = 0;

            return resto == int.Parse(cpf[10].ToString());
        }
    }
}

