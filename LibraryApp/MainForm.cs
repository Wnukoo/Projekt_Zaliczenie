using System;
using System.Linq;
using System.Windows.Forms;
using LibraryCore;

namespace LibraryApp
{
    public partial class MainForm : Form
    {
        private readonly Library _library = new();

        private readonly BindingSource _cardBinding = new();

        public MainForm()
        {
            InitializeComponent();    
            InitializeGrid();        
            InitializeCardControls();
            LoadSampleData();
        }

        // ========  KONFIGURACJA TABELI KSIĄŻEK (DataGridView)  ========
        private void InitializeGrid()
        {
            dataGridViewBooks.AutoGenerateColumns = false; 
            dataGridViewBooks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; 

            dataGridViewBooks.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Book ID",
                DataPropertyName = "CopyId"  
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
                DataPropertyName = "BorrowerName" 
            });
        }

        // ========  KONFIGURACJA LISTY KART W COMBOBOXIE ========
        private void InitializeCardControls()
        {
            comboCards.DataSource = _cardBinding;
            comboCards.DisplayMember = nameof(LibraryCard.StudentName); 

            RefreshCards(); 
        }

        // ========  PRZYKŁADOWE DANE (do testów i demonstracji)  ========
        private void LoadSampleData()
        {
            _library.AddNewCopy("Wiedźmin", "Andrzej Sapkowski", "978-83-89011-67-4");
            _library.AddNewCopy("Pan Tadeusz", "Adam Mickiewicz", "978-83-240-3100-5");
            _library.AddNewCopy("Lalka", "Bolesław Prus", "978-83-08-04201-0");
            _library.AddNewCopy("Zbrodnia i kara", "Fiodor Dostojewski", "978-83-08-04202-7");

            _library.AddNewCard("Robert Kubica");
            _library.AddNewCard("Max Verstappen");
            _library.AddNewCard("Lewis Hamilton");
            _library.AddNewCard("Fernando Alonso");

            RefreshGrid();
            RefreshCards();
        }

        // ========  ODŚWIEŻANIE DANYCH W UI  ========
        private void RefreshGrid() => dataGridViewBooks.DataSource = _library.Copies.ToList();

        private void RefreshCards()
        {
            _cardBinding.DataSource = null;            
            _cardBinding.DataSource = _library.Cards.ToList(); 
        }

        // ========  OBSŁUGA WYPOŻYCZENIA KSIĄŻKI ========
        private void buttonBorrow_Click(object? sender, EventArgs e)
        {
            var id = textCopyId.Text.Trim().ToUpper();
            var card = comboCards.SelectedItem as LibraryCard; 

            if (id.Length != 4)
            {
                MessageBox.Show("Podaj poprawny 4-znakowy Copy ID.");
                return;
            }
            if (card is null) 
            {
                MessageBox.Show("Wybierz kartę biblioteczną.");
                return;
            }
            try
            {
                _library.Borrow(id, card); 
                RefreshGrid();            
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); 
            }
        }

        // ========  OBSŁUGA ZWROTU KSIĄŻKI ========
        private void buttonReturn_Click(object? sender, EventArgs e)
        {
            var id = textCopyId.Text.Trim().ToUpper(); 

            try
            {
                _library.Return(id); 
                RefreshGrid();     
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); 
            }
        }

        // ========  OBSŁUGA USUWANIA KOPII KSIĄŻKI ========
        private void buttonDelete_Click(object? sender, EventArgs e)
        {
            var id = textCopyId.Text.Trim().ToUpper(); 
            if (_library.RemoveCopy(id)) 
                RefreshGrid();           
            else
                MessageBox.Show("Nie znaleziono ksiązki."); 
        }

        // ========  DODAWANIE NOWEJ KOPII KSIĄŻKI ========
        private void buttonAdd_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textNewTitle.Text) ||
                string.IsNullOrWhiteSpace(textNewAuthor.Text) ||
                string.IsNullOrWhiteSpace(textNewIsbn.Text))
            {
                MessageBox.Show("Wypełnij tytuł, autora i numer ISBN.");
                return;
            }

            _library.AddNewCopy(
                textNewTitle.Text.Trim(),
                textNewAuthor.Text.Trim(),
                textNewIsbn.Text.Trim());

            textNewTitle.Clear();
            textNewAuthor.Clear();
            textNewIsbn.Clear();

            RefreshGrid();
        }

        // ========  DODAWANIE NOWEJ KARTY CZYTELNIKA ========
        private void buttonAddCard_Click(object? sender, EventArgs e)
        {
            var name = textNewCardName.Text.Trim();

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Wprowadź imię i nazwisko.");
                return;
            }

            _library.AddNewCard(name);

            textNewCardName.Clear();

            RefreshCards();
        }

        // ========  ZAPIS DANYCH DO PLIKU JSON ========
        private void buttonSave_Click(object? sender, EventArgs e)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            using var sfd = new SaveFileDialog
            {
                Filter = "JSON files (*.json)|*.json",
                InitialDirectory = desktopPath
            };

            if (sfd.ShowDialog() == DialogResult.OK) 
            {
                _library.Save(sfd.FileName); 
            }
        }

        // ========  WCZYTANIE DANYCH Z PLIKU JSON ========
        private void buttonLoad_Click(object? sender, EventArgs e)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            using var ofd = new OpenFileDialog
            {
                Filter = "JSON files (*.json)|*.json",
                InitialDirectory = desktopPath
            };

            if (ofd.ShowDialog() == DialogResult.OK) 
            {
                _library.Load(ofd.FileName); 
                RefreshGrid();              
                RefreshCards();              
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
