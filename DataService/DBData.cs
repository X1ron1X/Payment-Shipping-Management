using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using Models;

namespace DataService
{
    public class DBData : IData
    {
        private readonly string connectionString =
                @"Server=localhost\SQLEXPRESS;Database=dbpayship;Trusted_Connection=True;TrustServerCertificate=True;";

        private SqlConnection sqlConnection;

        public DBData()
        {
            sqlConnection = new SqlConnection(connectionString);
            AddSeeds();

        }


        public void InsertAddress(ADD add)
        {
            string query = @"INSERT INTO Address (Name, Address, Phone_Number, Postal_Code)
                                 VALUES (@Name, @Address, @PNumber, @Pcode)";
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            {
                cmd.Parameters.AddWithValue("@Name", add.Name);
                cmd.Parameters.AddWithValue("@Address", add.Address);
                cmd.Parameters.AddWithValue("@PNumber", add.PNumber);
                cmd.Parameters.AddWithValue("@Pcode", add.Pcode);
                sqlConnection.Open();
                cmd.ExecuteNonQuery();
                sqlConnection.Close();
            }

        }



        public void InsertCard(Card card)
        {
            string query = @"INSERT INTO Card (Name, Card_Number, Expiration, cvv)
                                 VALUES (@Name, @CNumber, @EDate, @CVV)";
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            {
                cmd.Parameters.AddWithValue("@Name", card.Name);
                cmd.Parameters.AddWithValue("@CNumber", card.CNumber);
                cmd.Parameters.AddWithValue("@EDate", card.EDate);
                cmd.Parameters.AddWithValue("@CVV", card.CVV);
                sqlConnection.Open();
                cmd.ExecuteNonQuery();
                sqlConnection.Close();
            }

        }


        public void InsertBank(Bank bank)
        {
            string query = @"INSERT INTO Bank (HOLDER, Bank_Number, Bank_Name)
                                 VALUES (@Holder, @BNumber, @BName)";
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            {
                cmd.Parameters.AddWithValue("@Holder", bank.Holder);
                cmd.Parameters.AddWithValue("@BNumber", bank.BNumber);
                cmd.Parameters.AddWithValue("@BName", bank.BName);
                sqlConnection.Open();
                cmd.ExecuteNonQuery();
                sqlConnection.Close();
            }

        }

        public void InsertGcash(Gcash gcash)
        {
            string query = @"INSERT INTO Gcash (Name, Gcash_Number)
                                 VALUES (@Name, @GNumber)";
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            {
                cmd.Parameters.AddWithValue("@Name", gcash.Name);
                cmd.Parameters.AddWithValue("@GNumber", gcash.GNumber);
                sqlConnection.Open();
                cmd.ExecuteNonQuery();
                sqlConnection.Close();
            }

        }


        public void AddSeeds()
        {
            var exAdd = GetAddresses();
            if (exAdd.Count == 0)
            {
                ADD a = new ADD
                {
                    Name = "Ronelito T. Llaguno",
                    Address = "1556, Kaimito st., brgy. San Antonio, Binan City, Laguna, Calabarzon",
                    PNumber = "09914687722",
                    Pcode = "4024"
                };
                InsertAddress(a);
            }

            var exCard = GetCards();
            if (exCard.Count == 0)
            {
                Card c = new Card
                {
                    Name = "Ronelito T. Llaguno",
                    CNumber = "123456789",
                    EDate = "2030",
                    CVV = "1234"
                };
                InsertCard(c);
            }

            var exBank = GetBanks();
            if (exBank.Count == 0)
            {
                Bank b = new Bank
                {
                    Holder = "Ronelito T. Llaguno",
                    BNumber = "123456789",
                    BName = "BDO"
                };
                InsertBank(b);
            }

            var exGcash = GetGcash();
            if (exGcash.Count == 0)
            {
                Gcash g = new Gcash
                {
                    Name = "Ronelito T. Llaguno",
                    GNumber = "123456789"
                };
                InsertGcash(g);
            }
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
                    Name = reader["Name"].ToString(),
                    Address = reader["Address"].ToString(),
                    PNumber = reader["Phone_Number"].ToString(),
                    Pcode = reader["Postal_Code"].ToString()
                });
            }

            sqlConnection.Close();
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
                    Name = reader["Name"].ToString(),
                    CNumber = reader["Card_Number"].ToString(),
                    EDate = reader["Expiration"].ToString(),
                    CVV = reader["cvv"].ToString()
                });
            }

            sqlConnection.Close();
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
                    Holder = reader["HOLDER"].ToString(),
                    BNumber = reader["Bank_Name"].ToString(),
                    BName = reader["Bank_Name"].ToString()
                });
            }

            sqlConnection.Close();
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
                    Name = reader["Name"].ToString(),
                    GNumber = reader["Gcash_Number"].ToString()
                });
            }

            sqlConnection.Close();
            return gcash;
        }

    }
}