namespace LibraryApp
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dataGridViewBooks;
        private System.Windows.Forms.GroupBox groupBorrow;
        private System.Windows.Forms.TextBox textCopyId;
        private System.Windows.Forms.ComboBox comboCards;
        private System.Windows.Forms.Button buttonBorrow;
        private System.Windows.Forms.Button buttonReturn;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.GroupBox groupAdd;
        private System.Windows.Forms.TextBox textNewTitle;
        private System.Windows.Forms.TextBox textNewAuthor;
        private System.Windows.Forms.TextBox textNewIsbn;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.GroupBox groupCards;
        private System.Windows.Forms.TextBox textNewCardName;
        private System.Windows.Forms.Button buttonAddCard;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonLoad;

        private void InitializeComponent()
        {
            dataGridViewBooks = new DataGridView();
            groupBorrow = new GroupBox();
            textCopyId = new TextBox();
            comboCards = new ComboBox();
            buttonBorrow = new Button();
            buttonReturn = new Button();
            buttonDelete = new Button();
            groupAdd = new GroupBox();
            textNewTitle = new TextBox();
            textNewAuthor = new TextBox();
            textNewIsbn = new TextBox();
            buttonAdd = new Button();
            groupCards = new GroupBox();
            textNewCardName = new TextBox();
            buttonAddCard = new Button();
            buttonSave = new Button();
            buttonLoad = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewBooks).BeginInit();
            groupBorrow.SuspendLayout();
            groupAdd.SuspendLayout();
            groupCards.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridViewBooks
            // 
            dataGridViewBooks.Location = new Point(12, 12);
            dataGridViewBooks.Name = "dataGridViewBooks";
            dataGridViewBooks.Size = new Size(760, 250);
            dataGridViewBooks.TabIndex = 0;
            // 
            // groupBorrow
            // 
            groupBorrow.Controls.Add(textCopyId);
            groupBorrow.Controls.Add(comboCards);
            groupBorrow.Controls.Add(buttonBorrow);
            groupBorrow.Controls.Add(buttonReturn);
            groupBorrow.Controls.Add(buttonDelete);
            groupBorrow.Location = new Point(12, 270);
            groupBorrow.Name = "groupBorrow";
            groupBorrow.Size = new Size(760, 100);
            groupBorrow.TabIndex = 1;
            groupBorrow.TabStop = false;
            groupBorrow.Text = "Borrow / Return / Delete";
            // 
            // textCopyId
            // 
            textCopyId.Location = new Point(15, 30);
            textCopyId.Name = "textCopyId";
            textCopyId.PlaceholderText = "Book ID (4 chars)";
            textCopyId.Size = new Size(120, 23);
            textCopyId.TabIndex = 0;
            // 
            // comboCards
            // 
            comboCards.DropDownStyle = ComboBoxStyle.DropDownList;
            comboCards.Location = new Point(150, 30);
            comboCards.Name = "comboCards";
            comboCards.Size = new Size(250, 23);
            comboCards.TabIndex = 1;
            // 
            // buttonBorrow
            // 
            buttonBorrow.Location = new Point(420, 29);
            buttonBorrow.Name = "buttonBorrow";
            buttonBorrow.Size = new Size(75, 25);
            buttonBorrow.TabIndex = 2;
            buttonBorrow.Text = "Borrow";
            buttonBorrow.UseVisualStyleBackColor = true;
            buttonBorrow.Click += buttonBorrow_Click;
            // 
            // buttonReturn
            // 
            buttonReturn.Location = new Point(510, 29);
            buttonReturn.Name = "buttonReturn";
            buttonReturn.Size = new Size(75, 25);
            buttonReturn.TabIndex = 3;
            buttonReturn.Text = "Return";
            buttonReturn.UseVisualStyleBackColor = true;
            buttonReturn.Click += buttonReturn_Click;
            // 
            // buttonDelete
            // 
            buttonDelete.Location = new Point(600, 29);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(75, 25);
            buttonDelete.TabIndex = 4;
            buttonDelete.Text = "Delete";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // groupAdd
            // 
            groupAdd.Controls.Add(textNewTitle);
            groupAdd.Controls.Add(textNewAuthor);
            groupAdd.Controls.Add(textNewIsbn);
            groupAdd.Controls.Add(buttonAdd);
            groupAdd.Location = new Point(12, 380);
            groupAdd.Name = "groupAdd";
            groupAdd.Size = new Size(500, 120);
            groupAdd.TabIndex = 2;
            groupAdd.TabStop = false;
            groupAdd.Text = "Add new copy";
            // 
            // textNewTitle
            // 
            textNewTitle.Location = new Point(15, 30);
            textNewTitle.Name = "textNewTitle";
            textNewTitle.PlaceholderText = "Title";
            textNewTitle.Size = new Size(200, 23);
            textNewTitle.TabIndex = 0;
            // 
            // textNewAuthor
            // 
            textNewAuthor.Location = new Point(15, 60);
            textNewAuthor.Name = "textNewAuthor";
            textNewAuthor.PlaceholderText = "Author";
            textNewAuthor.Size = new Size(200, 23);
            textNewAuthor.TabIndex = 1;
            // 
            // textNewIsbn
            // 
            textNewIsbn.Location = new Point(230, 30);
            textNewIsbn.Name = "textNewIsbn";
            textNewIsbn.PlaceholderText = "ISBN";
            textNewIsbn.Size = new Size(150, 23);
            textNewIsbn.TabIndex = 2;
            // 
            // buttonAdd
            // 
            buttonAdd.Location = new Point(230, 60);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(150, 25);
            buttonAdd.TabIndex = 3;
            buttonAdd.Text = "Add book";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // groupCards
            // 
            groupCards.Controls.Add(textNewCardName);
            groupCards.Controls.Add(buttonAddCard);
            groupCards.Location = new Point(520, 380);
            groupCards.Name = "groupCards";
            groupCards.Size = new Size(252, 120);
            groupCards.TabIndex = 3;
            groupCards.TabStop = false;
            groupCards.Text = "Cards";
            // 
            // textNewCardName
            // 
            textNewCardName.Location = new Point(15, 30);
            textNewCardName.Name = "textNewCardName";
            textNewCardName.PlaceholderText = "Student name";
            textNewCardName.Size = new Size(220, 23);
            textNewCardName.TabIndex = 0;
            // 
            // buttonAddCard
            // 
            buttonAddCard.Location = new Point(15, 60);
            buttonAddCard.Name = "buttonAddCard";
            buttonAddCard.Size = new Size(220, 25);
            buttonAddCard.TabIndex = 1;
            buttonAddCard.Text = "Add card";
            buttonAddCard.UseVisualStyleBackColor = true;
            buttonAddCard.Click += buttonAddCard_Click;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(12, 510);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(120, 30);
            buttonSave.TabIndex = 4;
            buttonSave.Text = "Save JSON";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // buttonLoad
            // 
            buttonLoad.Location = new Point(150, 510);
            buttonLoad.Name = "buttonLoad";
            buttonLoad.Size = new Size(120, 30);
            buttonLoad.TabIndex = 5;
            buttonLoad.Text = "Load JSON";
            buttonLoad.UseVisualStyleBackColor = true;
            buttonLoad.Click += buttonLoad_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 561);
            Controls.Add(buttonLoad);
            Controls.Add(buttonSave);
            Controls.Add(groupCards);
            Controls.Add(groupAdd);
            Controls.Add(groupBorrow);
            Controls.Add(dataGridViewBooks);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Library Manager";
            ((System.ComponentModel.ISupportInitialize)dataGridViewBooks).EndInit();
            groupBorrow.ResumeLayout(false);
            groupBorrow.PerformLayout();
            groupAdd.ResumeLayout(false);
            groupAdd.PerformLayout();
            groupCards.ResumeLayout(false);
            groupCards.PerformLayout();
            ResumeLayout(false);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }
    }
}
