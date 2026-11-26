using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryLib
{
    public class LibraryFunctions
    {
        private const string LibraryName = "Городская библиотека г. Чита";
        private string _chiefLibrarian = "Иванова Мария Петровна";

        private readonly List<string> _staff = new List<string>
        {
            "Петров П.С.",
            "Сидорова А.В.",
            "Козлов И.Д.",
            "Иванова М.П."
        };

        public string GetChiefLibrarian()
        {
            return _chiefLibrarian;
        }

        public string GetLibraryName()
        {
            return LibraryName;
        }

        public void SetChiefLibrarian(string fullname)
        {
            if (string.IsNullOrWhiteSpace(fullname))
                return;

            var normalized = Normalize(fullname);
            if (_staff.Any(s => Normalize(s) == normalized))
            {
                _chiefLibrarian = fullname.Trim();
            }
        }

        public string GenerateBookCode(string category, int number)
        {
            if (string.IsNullOrWhiteSpace(category))
                throw new ArgumentException("Категория не может быть пустой.", nameof(category));

            return $"{category}_{number}";
        }

        public IReadOnlyList<string> GetStaff()
        {
            return _staff.AsReadOnly();
        }

        public void AddStaff(string fullname)
        {
            if (string.IsNullOrWhiteSpace(fullname))
                return;

            var trimmed = fullname.Trim();
            if (!_staff.Any(s => Normalize(s) == Normalize(trimmed)))
            {
                _staff.Add(trimmed);
            }
        }

        private static string Normalize(string value)
        {
            return string.Join(" ", value.Split(' ', StringSplitOptions.RemoveEmptyEntries)).ToLowerInvariant();
        }
    }
}