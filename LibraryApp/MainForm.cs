using System;
using System.Linq;
using System.Windows.Forms;
using LibraryCore;

namespace LibraryApp
{
    // Główna klasa formularza aplikacji WinForms.
    // Odpowiada za interakcję użytkownika z biblioteką.
    public partial class MainForm : Form
    {
        // Obiekt biblioteki, który zarządza danymi książek i kart.
        private readonly Library _library = new();

        // BindingSource to pośrednik między danymi (kartami) a kontrolką ComboBox.
        private readonly BindingSource _cardBinding = new();

        // Konstruktor formularza - to tu inicjalizujemy UI i dane.
        public MainForm()
        {
            InitializeComponent();    // Automatycznie wygenerowana metoda inicjująca kontrolki z pliku .Designer.cs
            InitializeGrid();         // Konfiguracja DataGridView - czyli tabeli książek
            InitializeCardControls(); // Konfiguracja ComboBox z kartami czytelników
            LoadSampleData();         // Załaduj przykładowe dane (kilka książek i kart)
        }

        // ========  KONFIGURACJA TABELI KSIĄŻEK (DataGridView)  ========
        private void InitializeGrid()
        {
            dataGridViewBooks.AutoGenerateColumns = false; // Wyłącz automatyczne generowanie kolumn - tworzymy własne
            dataGridViewBooks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Kolumny dopasowują się do szerokości tabeli

            // Dodajemy kolumny do tabeli - określamy co ma się wyświetlać i z jakiej właściwości obiektu
            dataGridViewBooks.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Book ID",
                DataPropertyName = "CopyId"  // Powiązanie z właściwością CopyId obiektu BookCopy
            });
            dataGridViewBooks.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Title",
                DataPropertyName = "Title"
            });
            dataGridViewBooks.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Author",
                DataPropertyName = "Author"
            });
            dataGridViewBooks.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Number ISBN",
                DataPropertyName = "Isbn"
            });
            dataGridViewBooks.Columns.Add(new DataGridViewCheckBoxColumn
            {
                HeaderText = "Borrowed",
                DataPropertyName = "IsBorrowed"
            });
            dataGridViewBooks.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Borrower",
                DataPropertyName = "BorrowerName" // Nazwa osoby, która wypożyczyła książkę (lub pusta)
            });
        }

        // ========  KONFIGURACJA LISTY KART W COMBOBOXIE ========
        private void InitializeCardControls()
        {
            comboCards.DataSource = _cardBinding; // Ustawiamy źródło danych combo boxa na BindingSource
            comboCards.DisplayMember = nameof(LibraryCard.StudentName); // Wyświetlaj tylko nazwę studenta

            RefreshCards(); // Załaduj aktualną listę kart do kontrolki
        }

        // ========  PRZYKŁADOWE DANE (do testów i demonstracji)  ========
        private void LoadSampleData()
        {
            // Dodajemy kilka przykładowych książek
            _library.AddNewCopy("Wiedźmin", "Andrzej Sapkowski", "978-83-89011-67-4");
            _library.AddNewCopy("Pan Tadeusz", "Adam Mickiewicz", "978-83-240-3100-5");
            _library.AddNewCopy("Lalka", "Bolesław Prus", "978-83-08-04201-0");
            _library.AddNewCopy("Zbrodnia i kara", "Fiodor Dostojewski", "978-83-08-04202-7");

            // Dodajemy kilka przykładowych kart czytelników
            _library.AddNewCard("Robert Kubica");
            _library.AddNewCard("Max Verstappen");
            _library.AddNewCard("Lewis Hamilton");
            _library.AddNewCard("Fernando Alonso");

            // Odświeżamy widoki, aby pokazać dane na UI
            RefreshGrid();
            RefreshCards();
        }

        // ========  ODŚWIEŻANIE DANYCH W UI  ========
        // Ustaw dane źródłowe tabeli na aktualną listę książek z biblioteki
        private void RefreshGrid() => dataGridViewBooks.DataSource = _library.Copies.ToList();

        // Odśwież źródło danych kart (BindingSource) i wymuś aktualizację ComboBox
        private void RefreshCards()
        {
            _cardBinding.DataSource = null;              // Resetujemy, aby wymusić odświeżenie
            _cardBinding.DataSource = _library.Cards.ToList(); // Ustawiamy aktualną listę kart
        }

        // ========  OBSŁUGA WYPOŻYCZENIA KSIĄŻKI ========
        private void buttonBorrow_Click(object? sender, EventArgs e)
        {
            var id = textCopyId.Text.Trim().ToUpper(); // Pobierz wpisany ID książki (usuń spacje, na wielkie litery)
            var card = comboCards.SelectedItem as LibraryCard; // Pobierz wybraną kartę z combo boxa

            if (id.Length != 4) // Sprawdź, czy ID ma dokładnie 4 znaki
            {
                MessageBox.Show("Podaj poprawny 4-znakowy Copy ID.");
                return;
            }
            if (card is null) // Sprawdź, czy wybrano kartę
            {
                MessageBox.Show("Wybierz kartę biblioteczną.");
                return;
            }
            try
            {
                _library.Borrow(id, card); // Wypożycz książkę na wskazaną kartę
                RefreshGrid();             // Odśwież tabelę, żeby pokazać zmiany (np. kto wypożyczył)
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); // Pokaż błąd, jeśli coś pójdzie nie tak (np. książka jest już wypożyczona)
            }
        }

        // ========  OBSŁUGA ZWROTU KSIĄŻKI ========
        private void buttonReturn_Click(object? sender, EventArgs e)
        {
            var id = textCopyId.Text.Trim().ToUpper(); // Pobierz ID książki

            try
            {
                _library.Return(id); // Zwróć książkę o podanym ID
                RefreshGrid();      // Odśwież widok tabeli
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); // Obsłuż błąd, np. gdy książka nie była wypożyczona
            }
        }

        // ========  OBSŁUGA USUWANIA KOPII KSIĄŻKI ========
        private void buttonDelete_Click(object? sender, EventArgs e)
        {
            var id = textCopyId.Text.Trim().ToUpper(); // Pobierz ID książki do usunięcia
            if (_library.RemoveCopy(id)) // Spróbuj usunąć
                RefreshGrid();           // Jeśli usunięto, odśwież tabelę
            else
                MessageBox.Show("Nie znaleziono ksiązki."); // Jeśli nie znaleziono ID, pokaż komunikat
        }

        // ========  DODAWANIE NOWEJ KOPII KSIĄŻKI ========
        private void buttonAdd_Click(object? sender, EventArgs e)
        {
            // Sprawdź, czy wszystkie pola (tytuł, autor, ISBN) zostały wypełnione
            if (string.IsNullOrWhiteSpace(textNewTitle.Text) ||
                string.IsNullOrWhiteSpace(textNewAuthor.Text) ||
                string.IsNullOrWhiteSpace(textNewIsbn.Text))
            {
                MessageBox.Show("Wypełnij tytuł, autora i numer ISBN.");
                return;
            }

            // Dodaj nową książkę do biblioteki
            _library.AddNewCopy(
                textNewTitle.Text.Trim(),
                textNewAuthor.Text.Trim(),
                textNewIsbn.Text.Trim());

            // Wyczyść pola tekstowe po dodaniu
            textNewTitle.Clear();
            textNewAuthor.Clear();
            textNewIsbn.Clear();

            // Odśwież tabelę, aby zobaczyć nową książkę
            RefreshGrid();
        }

        // ========  DODAWANIE NOWEJ KARTY CZYTELNIKA ========
        private void buttonAddCard_Click(object? sender, EventArgs e)
        {
            var name = textNewCardName.Text.Trim(); // Pobierz imię i nazwisko

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Wprowadź imię i nazwisko.");
                return;
            }

            // Dodaj nową kartę do biblioteki
            _library.AddNewCard(name);

            // Wyczyść pole tekstowe
            textNewCardName.Clear();

            // Odśwież ComboBox z kartami
            RefreshCards();
        }

        // ========  ZAPIS DANYCH DO PLIKU JSON ========
        private void buttonSave_Click(object? sender, EventArgs e)
        {
            // Ścieżka do pulpitu użytkownika
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            // Konfiguracja okna zapisu pliku z filtrem na pliki JSON
            using var sfd = new SaveFileDialog
            {
                Filter = "JSON files (*.json)|*.json",
                InitialDirectory = desktopPath
            };

            if (sfd.ShowDialog() == DialogResult.OK) // Jeśli użytkownik wybrał plik i potwierdził
            {
                _library.Save(sfd.FileName); // Zapisz dane biblioteki do wskazanego pliku
            }
        }

        // ========  WCZYTANIE DANYCH Z PLIKU JSON ========
        private void buttonLoad_Click(object? sender, EventArgs e)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            // Okno wyboru pliku do otwarcia (filtr na JSON)
            using var ofd = new OpenFileDialog
            {
                Filter = "JSON files (*.json)|*.json",
                InitialDirectory = desktopPath
            };

            if (ofd.ShowDialog() == DialogResult.OK) // Jeśli wybrano plik
            {
                _library.Load(ofd.FileName); // Wczytaj dane biblioteki z pliku
                RefreshGrid();               // Odśwież tabelę
                RefreshCards();              // Odśwież listę kart
            }
        }

        // Pusta metoda, może być wywołana przy ładowaniu formularza
        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
