using System.Text.RegularExpressions;

namespace NetPC_Rekrutacja.Models
{
    public class ContactEntity
    {
        //Wszystkie elementy dodane zgodnie z listą podaną w zadaniu
        public Guid Id { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Email { get; set; }
        public string Haslo { get; set; }
        public CKategoria Kategoria { get; set; }
        public string Podkategoria { get; set; }
        public string Telefon { get; set; }
        public DateTime DataUrodzenia { get; set; }

        //Enum CKategoria (nazewnictwo ze wzgledu na kolidujace Kategorie) pozwalający wybrać jedną z trzech wartości
        public enum CKategoria
        {
            Sluzbowy,
            Prywatny,
            Inny
        }

        //Konstruktor przypisujący dane według wytycznych
        public ContactEntity(string imie, string nazwisko, string email, string haslo, CKategoria kategoria, string podkategoria, string telefon, DateTime dataUrodzenia)
        {
            Id = Guid.NewGuid(); // Przyjmuję, że chcesz generować nowy GUID dla każdego nowego kontaktu
            Imie = imie;
            Nazwisko = nazwisko;
            Email = email;
            Haslo = haslo;
            Kategoria = CKategoria.Inny; // Przypisanie domyślnej wartości
            Podkategoria = string.Empty; // Przypisanie domyślnej wartości
            Telefon = telefon;
            DataUrodzenia = dataUrodzenia;
            Kategoria = kategoria; // Przypisanie wartości po przypisaniu domyślnych wartości
            Podkategoria = podkategoria;
        }

        public ContactEntity() { }

        //Prosta funkcja sprawdzająca poprawność hasła podczas rejestracji
        public static bool CheckPassword(string haslo)
        {
            // Minimalna długość hasła to 8 znaków
            if (haslo.Length < 8)
            {
                return false;
            }

            // Sprawdzenie, czy hasło zawiera co najmniej jedną cyfrę, jedną literę wielką i jedną literę małą
            Regex regex = new Regex(@"^(?=.*[0-9])(?=.*[A-Z])(?=.*[a-z]).{8,}$");
            return regex.IsMatch(haslo);
        }
    }


}
