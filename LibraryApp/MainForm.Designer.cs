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

        #region Windows-Forms Designer generated code
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridViewBooks = new System.Windows.Forms.DataGridView();
            this.groupBorrow = new System.Windows.Forms.GroupBox();
            this.textCopyId = new System.Windows.Forms.TextBox();
            this.comboCards = new System.Windows.Forms.ComboBox();
            this.buttonBorrow = new System.Windows.Forms.Button();
            this.buttonReturn = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.groupAdd = new System.Windows.Forms.GroupBox();
            this.textNewTitle = new System.Windows.Forms.TextBox();
            this.textNewAuthor = new System.Windows.Forms.TextBox();
            this.textNewIsbn = new System.Windows.Forms.TextBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.groupCards = new System.Windows.Forms.GroupBox();
            this.textNewCardName = new System.Windows.Forms.TextBox();
            this.buttonAddCard = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonLoad = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBooks)).BeginInit();
            this.groupBorrow.SuspendLayout();
            this.groupAdd.SuspendLayout();
            this.groupCards.SuspendLayout();
            this.SuspendLayout();

            // --------  DATA GRID  --------
            this.dataGridViewBooks.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewBooks.Name = "dataGridViewBooks";
            this.dataGridViewBooks.Size = new System.Drawing.Size(760, 250);
            this.dataGridViewBooks.TabIndex = 0;

            // --------  GROUP: BORROW  --------
            this.groupBorrow.Controls.Add(this.textCopyId);
            this.groupBorrow.Controls.Add(this.comboCards);
            this.groupBorrow.Controls.Add(this.buttonBorrow);
            this.groupBorrow.Controls.Add(this.buttonReturn);
            this.groupBorrow.Controls.Add(this.buttonDelete);
            this.groupBorrow.Location = new System.Drawing.Point(12, 270);
            this.groupBorrow.Name = "groupBorrow";
            this.groupBorrow.Size = new System.Drawing.Size(760, 100);
            this.groupBorrow.TabIndex = 1;
            this.groupBorrow.Text = "Borrow / Return / Delete";

            // Copy ID
            this.textCopyId.Location = new System.Drawing.Point(15, 30);
            this.textCopyId.Name = "textCopyId";
            this.textCopyId.PlaceholderText = "Copy ID (8 chars)";
            this.textCopyId.Size = new System.Drawing.Size(120, 23);
            this.textCopyId.TabIndex = 0;

            // Combo Cards
            this.comboCards.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboCards.Location = new System.Drawing.Point(150, 30);
            this.comboCards.Name = "comboCards";
            this.comboCards.Size = new System.Drawing.Size(250, 23);
            this.comboCards.TabIndex = 1;

            // Borrow
            this.buttonBorrow.Location = new System.Drawing.Point(420, 29);
            this.buttonBorrow.Name = "buttonBorrow";
            this.buttonBorrow.Size = new System.Drawing.Size(75, 25);
            this.buttonBorrow.TabIndex = 2;
            this.buttonBorrow.Text = "Borrow";
            this.buttonBorrow.UseVisualStyleBackColor = true;
            this.buttonBorrow.Click += new System.EventHandler(this.buttonBorrow_Click);

            // Return
            this.buttonReturn.Location = new System.Drawing.Point(510, 29);
            this.buttonReturn.Name = "buttonReturn";
            this.buttonReturn.Size = new System.Drawing.Size(75, 25);
            this.buttonReturn.TabIndex = 3;
            this.buttonReturn.Text = "Return";
            this.buttonReturn.UseVisualStyleBackColor = true;
            this.buttonReturn.Click += new System.EventHandler(this.buttonReturn_Click);

            // Delete
            this.buttonDelete.Location = new System.Drawing.Point(600, 29);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 25);
            this.buttonDelete.TabIndex = 4;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);

            // --------  GROUP: ADD COPY  --------
            this.groupAdd.Controls.Add(this.textNewTitle);
            this.groupAdd.Controls.Add(this.textNewAuthor);
            this.groupAdd.Controls.Add(this.textNewIsbn);
            this.groupAdd.Controls.Add(this.buttonAdd);
            this.groupAdd.Location = new System.Drawing.Point(12, 380);
            this.groupAdd.Name = "groupAdd";
            this.groupAdd.Size = new System.Drawing.Size(500, 120);
            this.groupAdd.TabIndex = 2;
            this.groupAdd.Text = "Add new copy";

            this.textNewTitle.Location = new System.Drawing.Point(15, 30);
            this.textNewTitle.Name = "textNewTitle";
            this.textNewTitle.PlaceholderText = "Title";
            this.textNewTitle.Size = new System.Drawing.Size(200, 23);
            this.textNewTitle.TabIndex = 0;

            this.textNewAuthor.Location = new System.Drawing.Point(15, 60);
            this.textNewAuthor.Name = "textNewAuthor";
            this.textNewAuthor.PlaceholderText = "Author";
            this.textNewAuthor.Size = new System.Drawing.Size(200, 23);
            this.textNewAuthor.TabIndex = 1;

            this.textNewIsbn.Location = new System.Drawing.Point(230, 30);
            this.textNewIsbn.Name = "textNewIsbn";
            this.textNewIsbn.PlaceholderText = "ISBN";
            this.textNewIsbn.Size = new System.Drawing.Size(150, 23);
            this.textNewIsbn.TabIndex = 2;

            this.buttonAdd.Location = new System.Drawing.Point(230, 60);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(150, 25);
            this.buttonAdd.TabIndex = 3;
            this.buttonAdd.Text = "Add copy";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);

            // --------  GROUP: CARDS  --------
            this.groupCards.Controls.Add(this.textNewCardName);
            this.groupCards.Controls.Add(this.buttonAddCard);
            this.groupCards.Location = new System.Drawing.Point(520, 380);
            this.groupCards.Name = "groupCards";
            this.groupCards.Size = new System.Drawing.Size(252, 120);
            this.groupCards.TabIndex = 3;
            this.groupCards.Text = "Cards";

            this.textNewCardName.Location = new System.Drawing.Point(15, 30);
            this.textNewCardName.Name = "textNewCardName";
            this.textNewCardName.PlaceholderText = "Student name";
            this.textNewCardName.Size = new System.Drawing.Size(220, 23);
            this.textNewCardName.TabIndex = 0;

            this.buttonAddCard.Location = new System.Drawing.Point(15, 60);
            this.buttonAddCard.Name = "buttonAddCard";
            this.buttonAddCard.Size = new System.Drawing.Size(220, 25);
            this.buttonAddCard.TabIndex = 1;
            this.buttonAddCard.Text = "Add card";
            this.buttonAddCard.UseVisualStyleBackColor = true;
            this.buttonAddCard.Click += new System.EventHandler(this.buttonAddCard_Click);

            // --------  SAVE / LOAD  --------
            this.buttonSave.Location = new System.Drawing.Point(12, 510);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(120, 30);
            this.buttonSave.TabIndex = 4;
            this.buttonSave.Text = "Save JSON";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);

            this.buttonLoad.Location = new System.Drawing.Point(150, 510);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(120, 30);
            this.buttonLoad.TabIndex = 5;
            this.buttonLoad.Text = "Load JSON";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);

            // --------  MAIN FORM  --------
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.groupCards);
            this.Controls.Add(this.groupAdd);
            this.Controls.Add(this.groupBorrow);
            this.Controls.Add(this.dataGridViewBooks);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Library Manager";

            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBooks)).EndInit();
            this.groupBorrow.ResumeLayout(false);
            this.groupBorrow.PerformLayout();
            this.groupAdd.ResumeLayout(false);
            this.groupAdd.PerformLayout();
            this.groupCards.ResumeLayout(false);
            this.groupCards.PerformLayout();
            this.ResumeLayout(false);
        }
        #endregion

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }
    }
}
