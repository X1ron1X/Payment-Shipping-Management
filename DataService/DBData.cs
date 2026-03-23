using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using Models;

namespace DataService
{
    public class DBData : IData
    {
        private string connectionString = @"Server=localhost\SQLEXPRESS;Database=dbpayship;Trusted_Connection=True;TrustServerCertificate=True;";

        private SqlConnection sqlConnection;

        public DBData()
        {
            sqlConnection = new SqlConnection(connectionString);

            
            AddSeeds(); 
        }

        private void AddSeeds() {
            var existADD = GetAddresses();
            if (existADD.Count == 0) 
            {
                ADD add = new ADD 
                {
                    Name = "Ronelito T. Llaguno",
                    Address = "1556, Kaimito st., brgy. San Antonio, Binan City, Laguna, Calabarzon",
                    PNumber = "09914687722",
                    Pcode = "4024"
                };
                InsertAddress(add);
            }
            var existCard = GetCards();
            if (existADD.Count == 0)
            {
                Card card = new Card
                {
                    Name = "Ronelito T. Llaguno",
                    CNumber = "123456789",
                    EDate = "2030",
                    CVV = "1234"
                };
                InsertCard(card);
            }
            var existBank = GetBanks();
            if (existADD.Count == 0)
            {
                Bank bank = new Bank
                {
                    Holder = "Ronelito T. Llaguno",
                    BNumber = "94725739206",
                    BName = "BDO"
                };
                InsertBank(bank);
            }
            var existGcash = GetGcash();
            if (existADD.Count == 0)
            {
                Gcash gcash = new Gcash
                {
                    Name = "Ronelito T. Llaguno",
                    GNumber = "09914687722"
                };
                InsertGcash(gcash);
            }
        }

        public void InsertAddress(ADD add)
        {
            var insertStatement = "INSERT INTO Address VALUES (@Name, @Address, @PNumber, @Pcode)";
            SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection);

            insertCommand.Parameters.AddWithValue("@Name", add.Name);
            insertCommand.Parameters.AddWithValue("@Address", add.Address);
            insertCommand.Parameters.AddWithValue("@PNumber", add.PNumber);
            insertCommand.Parameters.AddWithValue("@Pcode", add.Pcode);
            sqlConnection.Open();
            insertCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public void InsertCard(Card card)
        {
            var insertStatement = "INSERT INTO Card VALUES (@Name, @CNumber, @EDate, @CVV)";
            SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection);

            insertCommand.Parameters.AddWithValue("@Name", card.Name);
            insertCommand.Parameters.AddWithValue("@CNumber", card.CNumber);
            insertCommand.Parameters.AddWithValue("@EDate", card.EDate);
            insertCommand.Parameters.AddWithValue("@CVV", card.CVV);
            sqlConnection.Open();
            insertCommand.ExecuteNonQuery();
            sqlConnection.Close();

        }

        public void InsertBank(Bank bank)
        {
            var insertStatement = "INSERT INTO Bank VALUES (@Holder, @BNumber, @BName)";
            SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection);

            insertCommand.Parameters.AddWithValue("@Holder", bank.Holder);
            insertCommand.Parameters.AddWithValue("@BNumber", bank.BNumber);
            insertCommand.Parameters.AddWithValue("@BName", bank.BName);
            sqlConnection.Open();
            insertCommand.ExecuteNonQuery();
            sqlConnection.Close();

        }

        public void InsertGcash(Gcash gcash)
        {
            var insertStatement = "INSERT INTO  VALUES (@Name, @GNumber)";
            SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection);

            insertCommand.Parameters.AddWithValue("@Name", gcash.Name);
            insertCommand.Parameters.AddWithValue("@GNumber", gcash.GNumber);
            sqlConnection.Open();
            insertCommand.ExecuteNonQuery();
            sqlConnection.Close();

        }



        public List<ADD> GetAddresses()
        {
            var add = new List<ADD>();

            var selectStatement = "SELECT Name, Address, Phone_Number, Postal_Code FROM Address";
            SqlCommand command = new SqlCommand(selectStatement, sqlConnection);

            sqlConnection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                add.Add(new ADD
                {
                    Name = reader["Name"]?.ToString(),
                    Address = reader["Address"]?.ToString(),
                    PNumber = reader["PNumber"]?.ToString(),
                    Pcode = reader["Pcode"]?.ToString()
                });
            }
            

            return add;
        }

        public List<Card> GetCards()
        {
            var card = new List<Card>();

            var selectStatement = "SELECT Name, Card_Number, Expiration, cvv FROM Card";
            SqlCommand command = new SqlCommand(selectStatement, sqlConnection);

            sqlConnection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                card.Add(new Card
                {
                    Name = reader["Name"]?.ToString(),
                    CNumber = reader["CNumber"]?.ToString(),
                    EDate = reader["EDate"]?.ToString(),
                    CVV = reader["CVV"]?.ToString()
                });
            }

            return card;
        }

        public List<Bank> GetBanks()
        {
            var bank = new List<Bank>();

            var selectStatement = "SELECT HOLDER, Bank_Number, Bank_Name FROM Bank";
            SqlCommand command = new SqlCommand(selectStatement, sqlConnection);

            sqlConnection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                bank.Add(new Bank
                {
                    Holder = reader["Holder"]?.ToString(),
                    BNumber = reader["BNumber"]?.ToString(),
                    BName = reader["BName"]?.ToString()
                });
            }

            return bank;
        }

        public List<Gcash> GetGcash()
        {
            var gcash = new List<Gcash>();

            var selectStatement = "SELECT Name, Gcash_Number FROM Gcash";
            SqlCommand command = new SqlCommand(selectStatement, sqlConnection);

            sqlConnection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                gcash.Add(new Gcash
                {
                    Name = reader["Name"]?.ToString(),
                    GNumber = reader["GNumber"]?.ToString()
                });
            }

            return gcash;
        }

        public void Add(ADD add)
        {
            throw new NotImplementedException();
        }

        public void AddCard(Card card)
        {
            throw new NotImplementedException();
        }

        public void AddBank(Bank bank)
        {
            throw new NotImplementedException();
        }

        public void AddGcash(Gcash gcash)
        {
            throw new NotImplementedException();
        }

        public List<ADD> GetAddress()
        {
            throw new NotImplementedException();
        }
    }
}