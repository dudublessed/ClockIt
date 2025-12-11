using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using ClockIt.src.Core.Domain.ValueObjects;
using ClockIt.src.Shared.DTOs.EmployeeDTOs.ScheduleDTOs;

namespace ClockIt.src.Shared.DTOs.EmployeeDTOs
{
    public class EmployeeDTO
    {
        public int UserId { get; }
        public string FullName { get; }
        public string CPF { get; }
        public DateTime BirthDate { get; }
        public Email Email { get; }
        public int PositionId { get; }

        public EmployeeDTO(int userId, string fullName, string cpf, DateTime birthDate, string email, int positionId)
        {
            ValidateUserIdInput(userId);
            ValidateNameInput(fullName);
            ValidateCPFInput(cpf);
            ValidateBirthDateInput(birthDate);
            ValidatePositionIdInput(positionId);

            UserId = userId;
            FullName = fullName;
            CPF = SanitizeCPF(cpf);
            BirthDate = birthDate;
            Email = new Email(email);
            PositionId = positionId;
        }

        private void ValidateUserIdInput(int userId)
        {
            if (userId <= 0 || userId == null)
            {
                throw new ArgumentException("Por favor, selecione um usuário.");
            }
        }

        private void ValidateNameInput(string fullName)
        {
            if (string.IsNullOrEmpty(fullName))
            {
                throw new ArgumentException("Por favor, informe o nome do funcionário.");
            }
        }

        private void ValidateCPFInput(string cpf)
        {
            if (string.IsNullOrEmpty(cpf))
            {
                throw new ArgumentException("Por favor, insira o CPF do funcionário.");
            }

            var digits = new string(cpf.Where(char.IsDigit).ToArray());
            if (digits.Length != 11)
            {
                throw new ArgumentException("CPF inválido.");
            }

            if (digits.Distinct().Count() == 1)
            {
                throw new ArgumentException("CPF inválido.");
            }

            if (!IsValidCPF(digits))
            {
                throw new ArgumentException("CPF inválido.");
            }
        }

        private static bool IsValidCPF(string digits)
        {
            var nums = digits.Select(c => c - '0').ToArray();

            int sum = 0;
            for (int i = 0; i < 9; i++)
                sum += nums[i] * (10 - i);

            int remainder = sum % 11;
            int firstVerifier = remainder < 2 ? 0 : 11 - remainder;
            if (nums[9] != firstVerifier)
                return false;

            sum = 0;
            for (int i = 0; i < 10; i++)
                sum += nums[i] * (11 - i);

            remainder = sum % 11;
            int secondVerifier = remainder < 2 ? 0 : 11 - remainder;
            if (nums[10] != secondVerifier)
                return false;

            return true;
        }

        private string SanitizeCPF(string cpf)
        {
            string sanitizedCPF = Regex.Replace(cpf, @"\D", "");

            return sanitizedCPF;
        }

        private void ValidateBirthDateInput(DateTime birthDate)
        {
            if (birthDate == default(DateTime) || birthDate == DateTime.MinValue)
            {
                throw new ArgumentException("Por favor, informe a data de nascimento.");
            }

            if (birthDate.Date > DateTime.Today)
            {
                throw new ArgumentException("A data de nascimento não pode ser no futuro.");
            }

            var oldestAllowed = DateTime.Today.AddYears(-120);
            if (birthDate.Date < oldestAllowed)
            {
                throw new ArgumentException("Data de nascimento inválida.");
            }
        }

        private void ValidatePositionIdInput(int positionId)
        {
            if (positionId <= 0 || positionId == null)
            {
                throw new ArgumentException("Por favor, selecione um cargo.");
            }
        }
    }
}
